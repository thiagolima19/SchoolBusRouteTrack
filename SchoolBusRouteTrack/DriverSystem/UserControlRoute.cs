using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using SchoolBusRouteTrack.AdministratorSystem;
using SchoolBusRouteTrack.Data;
using SchoolBusRouteTrack.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolBusRouteTrack.DriverSystem
{
    public partial class UserControlRoute : UserControl
    {
        private int _driverId;
        private int? _selectedRouteId;
        private List<BusRoute> _allRoutes = new List<BusRoute>();
        private List<BusStop> _busStops;
        private Dictionary<int, List<BusStopCheckin>> _routeCheckins = new Dictionary<int, List<BusStopCheckin>>();

        // Route visualization variables
        private GMarkerGoogle busMarker;
        private Timer busTimer = new Timer();
        private GMapOverlay routeOverlay;
        private List<PointLatLng> busPathPoints = new List<PointLatLng>();
        private int busPathIndex = 0;

        public UserControlRoute(int driverId)
        {
            InitializeComponent();
            _driverId = driverId;
            InitializeGMap();
            SetupTimer();
            LoadDriverRoutes();
        }
        private void SetupTimer()
        {
            busTimer.Interval = 1200;
            busTimer.Tick += BusTimer_Tick;
        }
        //Load routes like UserControlRouteView filtered by driver
        private void LoadDriverRoutes()
        {
            try
            {
                // Clear existing data
                _allRoutes.Clear();
                comboBoxRoutes.Items.Clear();

                // Get routes for this specific driver
                RouteRepository repository = new RouteRepository();
                var dt = repository.GetRoutesAndStops();

                // Filter routes by driver ID and build BusRoute objects
                foreach (DataRow row in dt.Rows)
                {
                    int routeId = Convert.ToInt32(row["RouteID"]);
                    string routeNumber = row["RouteNumber"].ToString();
                    string description = row["Description"].ToString();
                    int? driverIdFromDB = row["DriverID"] != DBNull.Value ?
                        (int?)Convert.ToInt32(row["DriverID"]) : null;

                    // Only process routes assigned to this driver
                    if (driverIdFromDB != _driverId)
                        continue;

                    // Check if this route exists
                    var existingRoute = _allRoutes
                        .FirstOrDefault(r => r.RouteID == routeId);

                    // If route doesn't exist, Add Route!
                    if (existingRoute == null)
                    {
                        existingRoute = new BusRoute
                        {
                            RouteID = routeId,
                            RouteNumber = routeNumber,
                            RouteName = description,
                            SchoolName = row["SchoolName"] != DBNull.Value ? row["SchoolName"].ToString() : "",
                            DriverName = row["DriverName"] != DBNull.Value ? row["DriverName"].ToString() : "",
                            Plate = row["Plate"] != DBNull.Value ? row["Plate"].ToString() : "",
                            Stops = new List<BusStop>()
                        };
                        _allRoutes.Add(existingRoute);
                    }

                    // use StopID to match with checkins
                    BusStop stop = new BusStop
                    {
                        StopID = Convert.ToInt32(row["StopID"]),
                        Name = row["Address"].ToString(),
                        Latitude = Convert.ToDouble(row["Latitude"]),
                        Longitude = Convert.ToDouble(row["Longitude"])
                    };

                    // Link Stop(s) to Route
                    existingRoute.Stops.Add(stop);
                }

                // Set up ComboBox like in RouteView
                comboBoxRoutes.Items.Add("-- Select Route --");
                comboBoxRoutes.SelectedIndex = 0;

                foreach (var route in _allRoutes)
                    comboBoxRoutes.Items.Add(route);

                comboBoxRoutes.DisplayMember = "DisplayName";

                // Only attach event handler once
                comboBoxRoutes.SelectedIndexChanged -= ComboBoxRoutes_SelectedIndexChanged;
                comboBoxRoutes.SelectedIndexChanged += ComboBoxRoutes_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading routes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // route selection handler
        private void ComboBoxRoutes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxRoutes.SelectedIndex == 0)
                {
                    ClearMap();
                    return;
                }

                if (!(comboBoxRoutes.SelectedItem is BusRoute selectedRoute))
                    return;

                // Store the selected route ID
                _selectedRouteId = selectedRoute.RouteID;

                // Update the bus stops list
                _busStops = selectedRoute.Stops ?? new List<BusStop>();

                // Reset animation
                busPathPoints.Clear();
                busPathIndex = 0;

                // Clear map and draw the new route
                ClearMap();
                DrawFullRoute(selectedRoute);
                LoadStopChecklist(selectedRoute);

                // Start bus simulation
                busTimer.Stop();
                busTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading route: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DrawFullRoute(BusRoute route)
        {
            try
            {
                if (route.Stops == null || route.Stops.Count == 0)
                    return;

                routeOverlay = new GMapOverlay("route_main");
                gMapControlRoute.Overlays.Add(routeOverlay);

                // Make map visible
                gMapControlRoute.Visible = true;

                // Center on first stop
                gMapControlRoute.Position = new PointLatLng(
                    route.Stops[0].Latitude,
                    route.Stops[0].Longitude
                );

                // Draw everything using the same overlay 
                DrawRoutePolylineAlongRoads(route.Stops);
                AddRouteStopsToMap(route.Stops);
                AddBusMarker(route.Stops);

                gMapControlRoute.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error drawing route: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        // Draws road-following polyline
        private void DrawRoutePolylineAlongRoads(List<BusStop> stops)
        {
            if (stops == null || stops.Count < 2 || routeOverlay == null)
                return;

            busPathPoints.Clear();
            busPathIndex = 0;

            // Use OpenStreetMap to get actual road paths between stops
            for (int i = 0; i < stops.Count - 1; i++)
            {
                var stopA = stops[i];
                var stopB = stops[i + 1];

                PointLatLng pointA = new PointLatLng(stopA.Latitude, stopA.Longitude);
                PointLatLng pointB = new PointLatLng(stopB.Latitude, stopB.Longitude);

                // Get actual road route
                MapRoute segmentRoute = OpenStreetMapProvider.Instance
                    .GetRoute(pointA, pointB, false, false, 15);

                if (segmentRoute != null && segmentRoute.Points.Count > 1)
                {
                    // Draw blue lines on streets
                    GMapRoute routeLine = new GMapRoute(segmentRoute.Points, $"segment_{i}")
                    {
                        Stroke = new Pen(Color.Blue, 3)
                    };
                    routeOverlay.Routes.Add(routeLine);

                    // Build bus path for animation
                    // First segment: add all points
                    // Next segments: skip first point to avoid duplication
                    if (busPathPoints.Count == 0)
                        busPathPoints.AddRange(segmentRoute.Points);
                    else
                        busPathPoints.AddRange(segmentRoute.Points.Skip(1));
                }
                else
                {
                    // Fallback: draw straight line if road routing fails
                    List<PointLatLng> fallbackPoints = new List<PointLatLng> { pointA, pointB };
                    GMapRoute fallbackRoute = new GMapRoute(fallbackPoints, $"fallback_{i}")
                    {
                        Stroke = new Pen(Color.Blue, 3)
                    };
                    routeOverlay.Routes.Add(fallbackRoute);

                    if (busPathPoints.Count == 0)
                        busPathPoints.AddRange(fallbackPoints);
                    else
                        busPathPoints.Add(pointB);
                }
            }
        }

        private void AddRouteStopsToMap(List<BusStop> stops)
        {
            if (stops == null || stops.Count == 0 || routeOverlay == null)
                return;

            int stopNumber = 1;

            for (int i = 0; i < stops.Count; i++)
            {
                var stop = stops[i];
                var marker = new GMarkerGoogle(
                    new PointLatLng(stop.Latitude, stop.Longitude),
                    GMarkerGoogleType.green_small
                );

                marker.ToolTipText = $"{stopNumber}. {stop.Name}";
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                routeOverlay.Markers.Add(marker);
                stopNumber++;
            }
        }

        private void AddBusMarker(List<BusStop> stops)
        {
            if (routeOverlay == null || stops == null || stops.Count == 0)
                return;

            PointLatLng startPosition;

            if (busPathPoints != null && busPathPoints.Count > 0)
                startPosition = busPathPoints[0]; // Bus starts at first point of route
            else
                startPosition = new PointLatLng(stops[0].Latitude, stops[0].Longitude);

            busMarker = new GMarkerGoogle(startPosition, GMarkerGoogleType.red_small);
            routeOverlay.Markers.Add(busMarker);
        }

        // Load checkins for specific route (KEEP ONLY THIS ONE)
        private void LoadStopChecklist(BusRoute route)
        {
            if (route.Stops == null) return;

            checkedListBoxBusStop.Items.Clear();
            checkedListBoxBusStop.Items.AddRange(route.Stops.ToArray());
            checkedListBoxBusStop.DisplayMember = "Name";

            // Get checkins for this specific route
            List<BusStopCheckin> routeCheckins = GetCheckinsForRoute(route.RouteID);

            // Mark already checked stops for THIS route only
            checkedListBoxBusStop.ItemCheck -= checkedListBoxBusStop_ItemCheck;
            for (int i = 0; i < route.Stops.Count; i++)
            {
                // Check if this stop is in checkins FOR THIS ROUTE
                var wasChecked = routeCheckins.Any(c => c.BusStopID == route.Stops[i].StopID);
                checkedListBoxBusStop.SetItemChecked(i, wasChecked);
                route.Stops[i].CheckedIn = wasChecked;
            }
            checkedListBoxBusStop.ItemCheck += checkedListBoxBusStop_ItemCheck;
        }
        //Get checkins for a specific route
        private List<BusStopCheckin> GetCheckinsForRoute(int routeId)
        {
            if (!_routeCheckins.ContainsKey(routeId))
            {
                _routeCheckins[routeId] = new List<BusStopCheckin>();
            }
            return _routeCheckins[routeId];
        }

        // Track checkins per route (FIXED VERSION)
        private void checkedListBoxBusStop_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_selectedRouteId == null || _busStops == null || e.Index < 0 || e.Index >= _busStops.Count)
                return;

            int selectedStopIndex = e.Index;
            BusStop busStop = _busStops[selectedStopIndex];

            // Get checkins for the current route
            var routeCheckins = GetCheckinsForRoute(_selectedRouteId.Value);

            if (e.NewValue == CheckState.Checked)
            {
                // Add checkin to THIS route's checkins
                routeCheckins.Add(new BusStopCheckin
                {
                    BusStopID = busStop.StopID,
                    BusStop = busStop,
                    CheckinTime = DateTime.Now,
                    RouteID = _selectedRouteId.Value // Store which route this belongs to
                });
                busStop.CheckedIn = true;
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                // Remove checkin from THIS route's checkins
                var checkin = routeCheckins.FirstOrDefault(c => c.BusStopID == busStop.StopID);
                if (checkin != null)
                    routeCheckins.Remove(checkin);
                busStop.CheckedIn = false;
            }
        }

        private void BusTimer_Tick(object sender, EventArgs e)
        {
            if (busMarker == null || busPathPoints == null || busPathPoints.Count == 0)
                return;

            if (busPathIndex >= busPathPoints.Count - 1)
            {
                busTimer.Stop();
                return;
            }

            busPathIndex++;
            busMarker.Position = busPathPoints[busPathIndex];
            gMapControlRoute.Refresh();
        }

        private void ClearMap()
        {
            gMapControlRoute.Overlays.Clear();
            gMapControlRoute.Refresh();
        }

        private void checkedListBoxBusStop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selectedRouteId == null || _busStops == null)
                return;

            if (checkedListBoxBusStop.SelectedIndex < 0 ||
                checkedListBoxBusStop.SelectedIndex >= _busStops.Count)
                return;

            int selectedStopIndex = checkedListBoxBusStop.SelectedIndex;
            BusStop busStop = _busStops[selectedStopIndex];

            // Highlight the selected stop on the map
            HighlightSelectedStop(busStop.Latitude, busStop.Longitude);
            gMapControlRoute.Position = new PointLatLng(busStop.Latitude, busStop.Longitude);
            gMapControlRoute.Visible = true;
        }
        private void HighlightSelectedStop(double lat, double lng)
        {
            if (routeOverlay == null) return;

            // Clear any existing highlight marker
            var highlightMarkers = routeOverlay.Markers
                .Where(m => m.Tag?.ToString() == "highlight")
                .ToList();

            foreach (var marker in highlightMarkers)
                routeOverlay.Markers.Remove(marker);

            // Add highlight marker
            GMarkerGoogle highlightMarker = new GMarkerGoogle(
                new PointLatLng(lat, lng),
                GMarkerGoogleType.blue_pushpin
            );
            highlightMarker.Tag = "highlight";
            routeOverlay.Markers.Add(highlightMarker);
        }

        
        private void InitializeGMap()
        {
            // Set the map provider to OpenStreetMap for routing
            gMapControlRoute.MapProvider = GMapProviders.OpenStreetMap;
            gMapControlRoute.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = AccessMode.ServerOnly;

            // Zoom in and out and drag map
            gMapControlRoute.MinZoom = 4;
            gMapControlRoute.MaxZoom = 20;
            gMapControlRoute.Zoom = 13;
            gMapControlRoute.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            gMapControlRoute.CanDragMap = true;
            gMapControlRoute.DragButton = MouseButtons.Left;
            gMapControlRoute.IgnoreMarkerOnMouseWheel = true;
            gMapControlRoute.ShowCenter = false;

            // Initial center position based on Calgary's latitude and longitude
            gMapControlRoute.Position = new PointLatLng(51.0501, -114.08529);
            gMapControlRoute.Visible = false;
        }
    }
}
