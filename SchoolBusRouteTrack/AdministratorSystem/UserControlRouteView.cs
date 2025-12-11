using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using SchoolBusRouteTrack.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SchoolBusRouteTrack.AdministratorSystem
{
    public partial class UserControlRouteView : UserControl
    {
        // Current route stops
        List<BusStop> routeStops = new List<BusStop>();

        // List of all routes
        List<BusRoute> allRoutes = new List<BusRoute>();

        // Simulate the bus running
        GMarkerGoogle busMarker;

        //Set a timer for draw the bus
        Timer busTimer = new Timer();

        //sets the current stop index
        int currentStopIndex = 0;

        GMapOverlay routeOverlay; // main overlay to draw complete route (route spots) to bus follows
                                 
        private List<PointLatLng> busPathPoints = new List<PointLatLng>(); // to draw blue line between routes
        private int busPathIndex = 0;


        public UserControlRouteView()
        {
            InitializeComponent();
            this.Load += UserControlRouteView_Load; //load the User control route view together with the main controler
        }

        private void UserControlRouteView_Load(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.OpenStreetMap;

            LoadRoutes(); //loads all routes from DB
            //creates a map object using the gMap package
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = AccessMode.ServerOnly;

            //zoom in and out and drag map
            gMapControl1.MinZoom = 4;
            gMapControl1.MaxZoom = 20;
            gMapControl1.Zoom = 13;
            gMapControl1.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            gMapControl1.CanDragMap = true;
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.IgnoreMarkerOnMouseWheel = true;

            // Initial center position based on Calgary latitude and longitude
            gMapControl1.Position = new PointLatLng(51.0501, -114.08529);

            // sets the timer value
            busTimer.Interval = 1200;  // slower
            busTimer.Tick += BusTimer_Tick;       
        }

        // Load all routes
        //creates new BusRoute objects with a list of BusStops objects and its values for name, latitude and longitude
        private void LoadRoutes()
        {
           RouteRepository repository = new RouteRepository();
           allRoutes.Clear(); // Clear existing routes before loading

           var dt = repository.GetRoutesAndStops();

            foreach (DataRow row in dt.Rows)
            {
                int routeId = Convert.ToInt32(row["RouteID"]);
                string routeNumber = row["RouteNumber"].ToString();
                string description = row["Description"].ToString();

                // check of this route exists
                var existingRoute = allRoutes
                    .FirstOrDefault(r => r.RouteID == routeId);

                // if route does not exist, Add Route !
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
                    allRoutes.Add(existingRoute);
                }

                // Add Stop
                BusStop stop = new BusStop
                {
                    Name = row["Address"].ToString(),
                    Latitude = Convert.ToDouble(row["Latitude"]),
                    Longitude = Convert.ToDouble(row["Longitude"])
                };

                // Link Stop(s) to Route
                existingRoute.Stops.Add(stop);
            }

            comboBoxRoutes.Items.Clear();

            // sets the ComboBox with placeholder value
            comboBoxRoutes.Items.Add("-- Select Route --");
            comboBoxRoutes.SelectedIndex = 0;

            //loops within the Combobox route options
            foreach (var route in allRoutes)
                comboBoxRoutes.Items.Add(route);

            //gets the value select and call the method to display the route
            comboBoxRoutes.DisplayMember = "DisplayName";
            comboBoxRoutes.SelectedIndexChanged += comboBoxRoutes_SelectedIndexChanged;

            // Clear labels when loading
            ClearRouteInfo();
        }

        // Clear route info labels
        private void ClearRouteInfo()
        {
            lbl_school.Text = "School: ";
            lbl_driver.Text = "Driver: ";
            lbl_plate.Text = "Plate: ";
        }

        // The User selects a value on the combobox
        private void comboBoxRoutes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if the index is 0 ignores the placeholder
            if (comboBoxRoutes.SelectedIndex == 0)
            {
                ClearRouteInfo();
                return;
            }
            //if none value is select it returns
            if (!(comboBoxRoutes.SelectedItem is BusRoute selectedRoute))
                return;

            // Update route info labels
            lbl_school.Text = $"School: {selectedRoute.SchoolName}";
            lbl_driver.Text = $"Driver: {selectedRoute.DriverName}";
            lbl_plate.Text = $"Plate: {selectedRoute.Plate}";

            routeStops = selectedRoute.Stops ?? new List<BusStop>(); // Check if it's null, otherwise (??) create a new list
            currentStopIndex = 0;
            // Clear bus route to a new route
            busPathPoints.Clear(); 
            busPathIndex = 0;

       
            // Clear old map drawings to allow new draw
            gMapControl1.Overlays.Clear();
            gMapControl1.ReloadMap();

            // Create an unique overlay for everything in this route
            routeOverlay = new GMapOverlay("route_main");
            gMapControl1.Overlays.Add(routeOverlay);

            // Center map on first stop
            gMapControl1.Position = new PointLatLng(
                routeStops[0].Latitude,
                routeStops[0].Longitude
            );

            // Draw everything using the same overlay
            DrawRouteLightPolyline();
            DrawRoutePolylineAlongRoads();
            AddRouteStopsToMap();
            // DrawRoutePolyline();
            AddBusMarker();

            // Restart bus movement
            busTimer.Stop();
            busTimer.Start();
        }

               
        // Draws stop markers (green and red)
        private void AddRouteStopsToMap()
        {
            if (routeStops == null || routeStops.Count == 0 || routeOverlay == null)
                return;

            int stopNumber = 1;

            for (int i = 0; i < routeStops.Count; i++)
            {
                var stop = routeStops[i];
                        
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


        private void DrawRoutePolylineAlongRoads()
        {
            if (routeStops == null || routeStops.Count < 2 || routeOverlay == null)
                return;

            busPathPoints.Clear();
            busPathIndex = 0;

            for (int i = 0; i < routeStops.Count - 1; i++)
            {
                var stopA = routeStops[i];
                var stopB = routeStops[i + 1];

                PointLatLng pointA = new PointLatLng(stopA.Latitude, stopA.Longitude);
                PointLatLng pointB = new PointLatLng(stopB.Latitude, stopB.Longitude);

                MapRoute segmentRoute =
                    OpenStreetMapProvider.Instance.GetRoute(pointA, pointB, false, false, 15);

                if (segmentRoute != null && segmentRoute.Points.Count > 1)
                {
                    // draw lines on streets
                    GMapRoute routeLine = new GMapRoute(segmentRoute.Points, $"segment_{i}")
                    {
                        Stroke = new Pen(Color.Blue, 3)
                    };
                    routeOverlay.Routes.Add(routeLine);

                    // Mount bus route
                    // first segment: add all points
                    // next segments: jump first stop to avoid duplicating the junction point
                    if (busPathPoints.Count == 0)
                        busPathPoints.AddRange(segmentRoute.Points);
                    else
                        busPathPoints.AddRange(segmentRoute.Points.Skip(1));
                }
            }
        }

        private void DrawRouteLightPolyline()
        {
            // at least 2 points to draw the light route line
            if (routeStops == null || routeStops.Count < 2 || routeOverlay == null)
                return;

            List<PointLatLng> points = new List<PointLatLng>();

            foreach (var stop in routeStops)
                points.Add(new PointLatLng(stop.Latitude, stop.Longitude));

            GMapRoute routeLight = new GMapRoute(points, "RouteLight");

            //set color
            routeLight.Stroke = new Pen(Color.FromArgb(180, Color.LightSkyBlue), 6);
            
            // add it on main overlay
            routeOverlay.Routes.Add(routeLight);
        }


        // Add bus marker (simulation)
        private void AddBusMarker()
        {
            if (routeOverlay == null)
                return;

            PointLatLng startPosition;

            if (busPathPoints != null && busPathPoints.Count > 0)
                startPosition = busPathPoints[0];    // bus starts first position of the route
            else
                startPosition = new PointLatLng(
                    routeStops[0].Latitude,
                    routeStops[0].Longitude);

            busMarker = new GMarkerGoogle(
                startPosition,
                GMarkerGoogleType.red_small
            );
            routeOverlay.Markers.Add(busMarker);
        }


        // Moves the bus each tick from point A to B       
        private void BusTimer_Tick(object sender, EventArgs e)
        {
            if (busMarker == null || busPathPoints == null || busPathPoints.Count == 0)
                return;

            // stop the timer if the bus gor last stop
            if (busPathIndex >= busPathPoints.Count - 1)
                return;

            busPathIndex++;
            busMarker.Position = busPathPoints[busPathIndex];

            gMapControl1.Refresh();
        }

        private void MoveBusTowards(BusStop a, BusStop b)
        {
            double lat = busMarker.Position.Lat;
            double lng = busMarker.Position.Lng;
            //this will make the maker run on the top of the line
            double newLat = lat + (b.Latitude - lat) * 0.05;
            double newLng = lng + (b.Longitude - lng) * 0.05;

            busMarker.Position = new PointLatLng(newLat, newLng);
            gMapControl1.Refresh();
        }

        private bool IsBusAtStop(BusStop stop)
        {
            //checks the delta difference between two points and returns if true or false if the result is lesser than 0.0003 degrees ≈ 33m, as 1 degree of latitude ≈ 111km
            double distance = Math.Sqrt(
                Math.Pow(busMarker.Position.Lat - stop.Latitude, 2) +
                Math.Pow(busMarker.Position.Lng - stop.Longitude, 2)
            );

            return distance < 0.0003;
        }
        
        private void btn_addRoute_Click(object sender, EventArgs e)
        {
            using (var dialog = new FormAddRoute())  // Open Form "Add Route" to register new Route (modal)
            {
                var result = dialog.ShowDialog(this);


            if (result == DialogResult.OK)
            {
                LoadRoutes();
            }

            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            // Check if a route is selected
            if (comboBoxRoutes.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a route to edit!", "No Route Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected route
            if (!(comboBoxRoutes.SelectedItem is BusRoute selectedRoute))
            {
                MessageBox.Show("Please select a valid route!", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Open Form in edit mode with the RouteID
            using (var dialog = new FormAddRoute(selectedRoute.RouteID))
            {
                var result = dialog.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    LoadRoutes();
                }
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            // Check if a route is selected
            if (comboBoxRoutes.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a route to remove!", "No Route Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected route
            if (!(comboBoxRoutes.SelectedItem is BusRoute selectedRoute))
            {
                MessageBox.Show("Please select a valid route!", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm deletion
            var confirmResult = MessageBox.Show(
                $"Are you sure you want to delete route '{selectedRoute.RouteName}'?\n\nThis action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    var repository = new RouteRepository();
                    repository.DeleteRoute(selectedRoute.RouteID);

                    MessageBox.Show("Route deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear map and reload routes
                    gMapControl1.Overlays.Clear();
                    busTimer.Stop();
                    LoadRoutes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting route: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
