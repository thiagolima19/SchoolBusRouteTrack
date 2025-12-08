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
        // Current route's stops
        List<BusStop> routeStops = new List<BusStop>();

        // List of all routes
        List<BusRoute> allRoutes = new List<BusRoute>();

        // simulates the bus running
        GMarkerGoogle busMarker;

        //sets a timer for draw the bus
        Timer busTimer = new Timer();

        //sets the current stop index
        int currentStopIndex = 0;

        public UserControlRouteView()
        {
            InitializeComponent();
            this.Load += UserControlRouteView_Load; //loads the User control route view together with the main controler
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

            // Initial center position based on calgary's latitude and longitude
            gMapControl1.Position = new PointLatLng(51.0501, -114.08529);

            // sets the timer value
            busTimer.Interval = 200;
            busTimer.Tick += BusTimer_Tick;
        }

        // Load all routes
        //creates new BusRoute objects with a list of BusStops objects and its values for name, latitude and longitude
        private void LoadRoutes()
        {
           RouteRepository repository = new RouteRepository();

           var dt = repository.GetRoutesAndStops(); // dt = DataTable Patricia

            foreach (DataRow row in dt.Rows)
            {
                string routeNumber = row["RouteNumber"].ToString();
                string description = row["Description"].ToString();

                // check of this route exists             
                var existingRoute = allRoutes
                    .FirstOrDefault(r => r.RouteName == routeNumber);

                // if route does not exist, Add Route !
                if (existingRoute == null)
                {
                    existingRoute = new BusRoute
                    {
                        RouteName = routeNumber,                        
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
            //loops withim the combobox route options
            foreach (var route in allRoutes)
                comboBoxRoutes.Items.Add(route);
            //gets the value select and call the method to display the route
            comboBoxRoutes.DisplayMember = "RouteName";
            comboBoxRoutes.SelectedIndexChanged += comboBoxRoutes_SelectedIndexChanged;

        }

        // The User selects a value on the combobox
        private void comboBoxRoutes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if the index is 0 ignores the placeholder
            if (comboBoxRoutes.SelectedIndex == 0)
                return;
            //if none value is select it returns
            if (!(comboBoxRoutes.SelectedItem is BusRoute selectedRoute))
                return;
            //sets the stops to a route and its current index position
            routeStops = selectedRoute.Stops;
            currentStopIndex = 0;

            // Clear old map drawings to allow new draw
            gMapControl1.Overlays.Clear();
            //gMapControl1.Refresh();
            //gMapControl1.Update();
            gMapControl1.ReloadMap();
            //Application.DoEvents();   

            // Center map on first stop
            gMapControl1.Position = new PointLatLng(
                routeStops[0].Latitude,
                routeStops[0].Longitude
            );

            // calls the methods to draw the selected route on the map
            //DrawRouteLightPolyline();
            DrawRoutePolylineAlongRoads();
            AddRouteStopsToMap();
            DrawRoutePolyline();
            AddBusMarker();

            // Restart bus movement
            busTimer.Stop();
            busTimer.Start();
        }

        // Draws stop markers
        private void AddRouteStopsToMap()
        {
            //creates an overlay object to draw the stop point
            GMapOverlay stopsOverlay = new GMapOverlay("stops");
            int stopNumber = 1;

            //loops into each stop and sets latitude, logitude, a marker, a stop tip when hovered
            foreach (var stop in routeStops)
            {
                var marker = new GMarkerGoogle(
                    new PointLatLng(stop.Latitude, stop.Longitude),
                    GMarkerGoogleType.green_small);

                marker.ToolTipText = $"{stopNumber}. {stop.Name}";
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;

                stopsOverlay.Markers.Add(marker);
                stopNumber++;
            }

            gMapControl1.Overlays.Add(stopsOverlay); //adds a new stop overlay
        }

        private void DrawRoutePolylineAlongRoads()
        {
            GMapOverlay routeOverlay = new GMapOverlay("route_roads");

            // Vamos criar um segmento de rota entre cada par de paradas
            for (int i = 0; i < routeStops.Count - 1; i++)
            {
                var stopA = routeStops[i];
                var stopB = routeStops[i + 1];

                PointLatLng pointA = new PointLatLng(stopA.Latitude, stopA.Longitude);
                PointLatLng pointB = new PointLatLng(stopB.Latitude, stopB.Longitude);

                // Pede para o provider calcular rota pelas ruas
                MapRoute segmentRoute =
                    OpenStreetMapProvider.Instance.GetRoute(pointA, pointB, false, false, 15);

                if (segmentRoute != null && segmentRoute.Points.Count > 1)
                {
                    // Usa os pontos calculados (que seguem a estrada)
                    GMapRoute routeLine = new GMapRoute(segmentRoute.Points, $"segment_{i}")
                    {
                        Stroke = new Pen(Color.Blue, 3)  // mesma cor que você já usava
                    };

                    routeOverlay.Routes.Add(routeLine);
                }
            }

            gMapControl1.Overlays.Add(routeOverlay);
        }


        private void DrawRouteLightPolyline()
        {
            // overlay próprio para a linha clara
            GMapOverlay routeLightOverlay = new GMapOverlay("route_light");
            List<PointLatLng> points = new List<PointLatLng>();

            foreach (var stop in routeStops)
                points.Add(new PointLatLng(stop.Latitude, stop.Longitude));

            GMapRoute routeLight = new GMapRoute(points, "RouteLight");

            // cor clara com transparência
            routeLight.Stroke = new Pen(Color.FromArgb(120, Color.LightSkyBlue), 6);
            // se quiser, pode deixar a linha tracejada:
            // routeLight.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            routeLightOverlay.Routes.Add(routeLight);

            // adiciona ANTES da rota azul, pra ficar “debaixo”
            gMapControl1.Overlays.Add(routeLightOverlay);
        }

        // Draw straight lines connecting the stop of the route
        private void DrawRoutePolyline()
        {
            //creates a overlay object and list of points for latidude and longitude
            GMapOverlay routeOverlay = new GMapOverlay("route");
            List<PointLatLng> points = new List<PointLatLng>();

            //loops through the route stops adding the points
            foreach (var stop in routeStops)
                points.Add(new PointLatLng(stop.Latitude, stop.Longitude));

            //creates the map route object, sets its color and adds to route overlay
            GMapRoute routeLine = new GMapRoute(points, "Route");
            routeLine.Stroke = new Pen(Color.Blue, 3);
            routeOverlay.Routes.Add(routeLine);

            gMapControl1.Overlays.Add(routeOverlay);
        }

        // Add bus marker (simulation)
        private void AddBusMarker()
        {
            //gets the first stop index position
            var first = routeStops[0];
            //creates a simple marker
            busMarker = new GMarkerGoogle(
            new PointLatLng(first.Latitude, first.Longitude),
            GMarkerGoogleType.red_small
            );
            //creates a new overlay object and adds it to the list
            GMapOverlay busOverlay = new GMapOverlay("bus");
            busOverlay.Markers.Add(busMarker);

            gMapControl1.Overlays.Add(busOverlay);
        }

        // Moves the bus each tick from point A to B
        private void BusTimer_Tick(object sender, EventArgs e)
        {
            //if is at the end returns
            if (currentStopIndex >= routeStops.Count - 1)
                return;

            var a = routeStops[currentStopIndex];
            var b = routeStops[currentStopIndex + 1];

            MoveBusTowards(a, b); //calls the method to move the bus

            if (IsBusAtStop(b)) //if the b points reached it move foward by 1
                currentStopIndex++;
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
    }
}
