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

        GMapOverlay routeOverlay; // overlay principal -- patricia teste linha azul
                                  // caminho completo para o ônibus seguir (pontos da rota pelas ruas)
        private List<PointLatLng> busPathPoints = new List<PointLatLng>(); // patricia teste linha azul
        private int busPathIndex = 0; // patricia teste linha azu


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
            //busTimer.Interval = 200;
            busTimer.Interval = 1200;
            busTimer.Tick += BusTimer_Tick;       
        }

        // Load all routes
        //creates new BusRoute objects with a list of BusStops objects and its values for name, latitude and longitude
        private void LoadRoutes()
        {
           RouteRepository repository = new RouteRepository();
           allRoutes.Clear(); // Clear existing routes before loading

           var dt = repository.GetRoutesAndStops(); // dt = DataTable Patricia

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
                        RouteName = routeNumber,
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
            //loops withim the combobox route options
            foreach (var route in allRoutes)
                comboBoxRoutes.Items.Add(route);
            //gets the value select and call the method to display the route
            comboBoxRoutes.DisplayMember = "RouteName";
            comboBoxRoutes.SelectedIndexChanged += comboBoxRoutes_SelectedIndexChanged;

            // Clear labels when loading
            ClearRouteInfo();
        }

        // Clear route info labels
        private void ClearRouteInfo()
        {
            lbl_school.Text = "School:";
            lbl_driver.Text = "Driver:";
            lbl_plate.Text = "Plate:";
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

            //sets the stops to a route and its current index position
            // routeStops = selectedRoute.Stops; patricia teste linha azul
            routeStops = selectedRoute.Stops ?? new List<BusStop>(); // Patricia
            currentStopIndex = 0;
            // zera o caminho do ônibus para a nova rota - patricia linha azul
            busPathPoints.Clear(); //patricia linha azul
            busPathIndex = 0;//patricia linha azul

            // Clear old map drawings to allow new draw
            //gMapControl1.Overlays.Clear(); // comentado por Patricia linha azul
            ////gMapControl1.Refresh();
            ////gMapControl1.Update();
            //gMapControl1.ReloadMap();
            ////Application.DoEvents();

            //// Center map on first stop
            //gMapControl1.Position = new PointLatLng(
            //    routeStops[0].Latitude,
            //    routeStops[0].Longitude
            //);

            //// calls the methods to draw the selected route on the map            
            //DrawRouteLightPolyline();
            //DrawRoutePolylineAlongRoads();
            //AddRouteStopsToMap();
            //DrawRoutePolyline();
            //AddBusMarker();

            // Clear old map drawings to allow new draw
            gMapControl1.Overlays.Clear();
            gMapControl1.ReloadMap();

            // Cria um overlay único para tudo dessa rota
            routeOverlay = new GMapOverlay("route_main");
            gMapControl1.Overlays.Add(routeOverlay);

            // Center map on first stop
            gMapControl1.Position = new PointLatLng(
                routeStops[0].Latitude,
                routeStops[0].Longitude
            );

            // Desenha TUDO usando o mesmo overlay
            DrawRouteLightPolyline();
            DrawRoutePolylineAlongRoads();
            AddRouteStopsToMap();
         //   DrawRoutePolyline();
            AddBusMarker();

            // Restart bus movement
            busTimer.Stop();
            busTimer.Start();
        }

        // Draws stop markers
        //private void AddRouteStopsToMap() // Patricia - linha azul - original
        //{
        //    //creates an overlay object to draw the stop point
        //    GMapOverlay stopsOverlay = new GMapOverlay("stops");
        //    int stopNumber = 1;

        //    //loops into each stop and sets latitude, logitude, a marker, a stop tip when hovered
        //    foreach (var stop in routeStops)
        //    {
        //        var marker = new GMarkerGoogle(
        //            new PointLatLng(stop.Latitude, stop.Longitude),
        //            GMarkerGoogleType.green_small);

        //        marker.ToolTipText = $"{stopNumber}. {stop.Name}";
        //        marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;

        //        stopsOverlay.Markers.Add(marker);
        //        stopNumber++;
        //    }

        //    gMapControl1.Overlays.Add(stopsOverlay); //adds a new stop overlay
        //}

        // Draws stop markers
        //private void AddRouteStopsToMap() // primeiro teste patricia
        //{
        //    if (routeStops == null || routeStops.Count == 0 || routeOverlay == null)
        //        return;

        //    int stopNumber = 1;

        //    //loops into each stop and sets latitude, longitude, a marker, a stop tip when hovered
        //    foreach (var stop in routeStops)
        //    {
        //        var marker = new GMarkerGoogle(
        //            new PointLatLng(stop.Latitude, stop.Longitude),
        //            GMarkerGoogleType.green_small);

        //        marker.ToolTipText = $"{stopNumber}. {stop.Name}";
        //        marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;

        //        routeOverlay.Markers.Add(marker);
        //        stopNumber++;
        //    }
        //}
        //private void AddRouteStopsToMap() // segundo teste Patricia
        //{
        //    if (routeStops == null || routeStops.Count == 0 || routeOverlay == null)
        //        return;

        //    int stopNumber = 1;

        //    for (int i = 0; i < routeStops.Count; i++)
        //    {
        //        // pula o primeiro stop, porque o ônibus já marca esse ponto
        //        if (i == 0)
        //            continue;

        //        var stop = routeStops[i];

        //        var marker = new GMarkerGoogle(
        //            new PointLatLng(stop.Latitude, stop.Longitude),
        //            GMarkerGoogleType.green_small);

        //        marker.ToolTipText = $"{stopNumber}. {stop.Name}";
        //        marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;

        //        routeOverlay.Markers.Add(marker);
        //        stopNumber++;
        //    }
        //}


        // Draws stop markers
        private void AddRouteStopsToMap()
        {
            if (routeStops == null || routeStops.Count == 0 || routeOverlay == null)
                return;

            // vamos numerar os stops a partir de 1, mas pular o primeiro (onde já tem o ônibus)
            int stopNumber = 1;

            for (int i = 0; i < routeStops.Count; i++)
            {
                // pula o primeiro stop, porque o ônibus vermelho já marca esse ponto
                if (i == 0)
                {
                    stopNumber++;
                    continue;
                }

                var stop = routeStops[i];

                // escolhe o tipo de marcador:
                // - verde para paradas intermediárias
                // - azul para a última parada
                GMarkerGoogleType markerType;

                if (i == routeStops.Count - 1)
                    markerType = GMarkerGoogleType.green_small;   // última parada
                else
                    markerType = GMarkerGoogleType.green_small;  // paradas intermediárias

                var marker = new GMarkerGoogle(
                    new PointLatLng(stop.Latitude, stop.Longitude),
                    markerType
                );

                marker.ToolTipText = $"{stopNumber}. {stop.Name}";
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;

                routeOverlay.Markers.Add(marker);
                stopNumber++;
            }
        }



        //private void DrawRoutePolylineAlongRoads() //Patricia - linha azul original
        //{
        //    GMapOverlay routeOverlay = new GMapOverlay("route_roads");

        //    // Vamos criar um segmento de rota entre cada par de paradas
        //    for (int i = 0; i < routeStops.Count - 1; i++)
        //    {
        //        var stopA = routeStops[i];
        //        var stopB = routeStops[i + 1];

        //        PointLatLng pointA = new PointLatLng(stopA.Latitude, stopA.Longitude);
        //        PointLatLng pointB = new PointLatLng(stopB.Latitude, stopB.Longitude);

        //        // Pede para o provider calcular rota pelas ruas
        //        MapRoute segmentRoute =
        //            OpenStreetMapProvider.Instance.GetRoute(pointA, pointB, false, false, 15);

        //        if (segmentRoute != null && segmentRoute.Points.Count > 1)
        //        {
        //            // Usa os pontos calculados (que seguem a estrada)
        //            GMapRoute routeLine = new GMapRoute(segmentRoute.Points, $"segment_{i}")
        //            {
        //                Stroke = new Pen(Color.Blue, 3)  // mesma cor que você já usava
        //            };

        //            routeOverlay.Routes.Add(routeLine);
        //        }
        //    }

        //    gMapControl1.Overlays.Add(routeOverlay);
        //}

        //private void DrawRoutePolylineAlongRoads() // tentativa linha azul
        //{
        //    if (routeStops == null || routeStops.Count < 2 || routeOverlay == null)
        //        return;

        //    // cria um segmento de rota entre cada par de paradas
        //    for (int i = 0; i < routeStops.Count - 1; i++)
        //    {
        //        var stopA = routeStops[i];
        //        var stopB = routeStops[i + 1];

        //        PointLatLng pointA = new PointLatLng(stopA.Latitude, stopA.Longitude);
        //        PointLatLng pointB = new PointLatLng(stopB.Latitude, stopB.Longitude);

        //        // pede para o provider calcular rota pelas ruas
        //        MapRoute segmentRoute =
        //            OpenStreetMapProvider.Instance.GetRoute(pointA, pointB, false, false, 15);

        //        if (segmentRoute != null && segmentRoute.Points.Count > 1)
        //        {
        //            // usa os pontos calculados (que seguem a estrada)
        //            GMapRoute routeLine = new GMapRoute(segmentRoute.Points, $"segment_{i}")
        //            {
        //                Stroke = new Pen(Color.Blue, 3)  // mesma cor que você já usava
        //            };

        //            routeOverlay.Routes.Add(routeLine);
        //        }
        //    }
        //}

        private void DrawRoutePolylineAlongRoads()
        {
            if (routeStops == null || routeStops.Count < 2 || routeOverlay == null)
                return;

            // vamos também montar o caminho que o ônibus vai seguir
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
                    // desenha a linha nas ruas
                    GMapRoute routeLine = new GMapRoute(segmentRoute.Points, $"segment_{i}")
                    {
                        Stroke = new Pen(Color.Blue, 3)
                    };
                    routeOverlay.Routes.Add(routeLine);

                    // monta o caminho do ônibus:
                    // primeiro segmento: adiciona todos os pontos
                    // próximos segmentos: pula o primeiro para não duplicar o ponto de junção
                    if (busPathPoints.Count == 0)
                        busPathPoints.AddRange(segmentRoute.Points);
                    else
                        busPathPoints.AddRange(segmentRoute.Points.Skip(1));
                }
            }
        }



        //private void DrawRouteLightPolyline() // comentado por Patricia - linha azul
        //{
        //    // overlay próprio para a linha clara
        //    GMapOverlay routeLightOverlay = new GMapOverlay("route_light");
        //    List<PointLatLng> points = new List<PointLatLng>();

        //    foreach (var stop in routeStops)
        //        points.Add(new PointLatLng(stop.Latitude, stop.Longitude));

        //    GMapRoute routeLight = new GMapRoute(points, "RouteLight");

        //    // cor clara com transparência
        //    routeLight.Stroke = new Pen(Color.FromArgb(120, Color.LightSkyBlue), 6);
        //    // se quiser, pode deixar a linha tracejada:
        //    // routeLight.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

        //    routeLightOverlay.Routes.Add(routeLight);

        //    // adiciona ANTES da rota azul, pra ficar “debaixo”
        //    gMapControl1.Overlays.Add(routeLightOverlay);
        //}

        private void DrawRouteLightPolyline()
        {
            // precisa de pelo menos dois pontos para desenhar linha
            if (routeStops == null || routeStops.Count < 2 || routeOverlay == null)
                return;

            List<PointLatLng> points = new List<PointLatLng>();

            foreach (var stop in routeStops)
                points.Add(new PointLatLng(stop.Latitude, stop.Longitude));

            GMapRoute routeLight = new GMapRoute(points, "RouteLight");

            // cor clara com transparência e linha grossa
            routeLight.Stroke = new Pen(Color.FromArgb(180, Color.LightSkyBlue), 6);
            // opcional: linha tracejada
            // routeLight.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            // adiciona no overlay principal
            routeOverlay.Routes.Add(routeLight);
        }


        // Draw straight lines connecting the stop of the route
        //private void DrawRoutePolyline() - Patricia Linha azul
        //{
        //    //creates a overlay object and list of points for latidude and longitude
        //    GMapOverlay routeOverlay = new GMapOverlay("route");
        //    List<PointLatLng> points = new List<PointLatLng>();

        //    //loops through the route stops adding the points
        //    foreach (var stop in routeStops)
        //        points.Add(new PointLatLng(stop.Latitude, stop.Longitude));

        //    //creates the map route object, sets its color and adds to route overlay
        //    GMapRoute routeLine = new GMapRoute(points, "Route");
        //    routeLine.Stroke = new Pen(Color.Blue, 3);
        //    routeOverlay.Routes.Add(routeLine);

        //    gMapControl1.Overlays.Add(routeOverlay);
        //}

        // Draw straight lines connecting the stop of the route
        //private void DrawRoutePolyline()
        //{
        //    if (routeStops == null || routeStops.Count < 2 || routeOverlay == null)
        //        return;

        //    //creates a list of points for latitude and longitude
        //    List<PointLatLng> points = new List<PointLatLng>();

        //    //loops through the route stops adding the points
        //    foreach (var stop in routeStops)
        //        points.Add(new PointLatLng(stop.Latitude, stop.Longitude));

        //    //creates the map route object, sets its color and adds to route overlay
        //    GMapRoute routeLine = new GMapRoute(points, "RouteStraight");
        //    routeLine.Stroke = new Pen(Color.Blue, 3);

        //    routeOverlay.Routes.Add(routeLine);
        //}


        // Add bus marker (simulation)
        //private void AddBusMarker() Patricia - linha azul original
        //{
        //    //gets the first stop index position
        //    var first = routeStops[0];
        //    //creates a simple marker
        //    busMarker = new GMarkerGoogle(
        //    new PointLatLng(first.Latitude, first.Longitude),
        //    GMarkerGoogleType.red_small
        //    );
        //    //creates a new overlay object and adds it to the list
        //    GMapOverlay busOverlay = new GMapOverlay("bus");
        //    busOverlay.Markers.Add(busMarker);

        //    gMapControl1.Overlays.Add(busOverlay);
        //}

        // Add bus marker (simulation)
        //private void AddBusMarker() tentativa linha azul
        //{
        //    if (routeStops == null || routeStops.Count == 0 || routeOverlay == null)
        //        return;

        //    //gets the first stop index position
        //    var first = routeStops[0];

        //    //creates a simple marker
        //    busMarker = new GMarkerGoogle(
        //        new PointLatLng(first.Latitude, first.Longitude),
        //        GMarkerGoogleType.red_small
        //    );

        //    //adds bus marker to the main overlay
        //    routeOverlay.Markers.Add(busMarker);
        //}

        // Add bus marker (simulation)
        private void AddBusMarker() // patricia linha azul
        {
            if (routeOverlay == null)
                return;

            PointLatLng startPosition;

            if (busPathPoints != null && busPathPoints.Count > 0)
                startPosition = busPathPoints[0];          // início da rota pelas ruas
            else
                startPosition = new PointLatLng(
                    routeStops[0].Latitude,
                    routeStops[0].Longitude);              // fallback

            busMarker = new GMarkerGoogle(
                startPosition,
                GMarkerGoogleType.red_small
            );

            routeOverlay.Markers.Add(busMarker);
        }


        // Moves the bus each tick from point A to B
        //private void BusTimer_Tick(object sender, EventArgs e) // comentaeo por Patricia linha azul
        //{
        //    //if is at the end returns
        //    if (currentStopIndex >= routeStops.Count - 1)
        //        return;

        //    var a = routeStops[currentStopIndex];
        //    var b = routeStops[currentStopIndex + 1];

        //    MoveBusTowards(a, b); //calls the method to move the bus

        //    if (IsBusAtStop(b)) //if the b pointis reached it move foward by 1
        //        currentStopIndex++;
        //}

        private void BusTimer_Tick(object sender, EventArgs e)
        {
            if (busMarker == null || busPathPoints == null || busPathPoints.Count == 0)
                return;

            // se chegou no último ponto, para
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
                MessageBox.Show("Please select a route to edit.", "No Route Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected route
            if (!(comboBoxRoutes.SelectedItem is BusRoute selectedRoute))
            {
                MessageBox.Show("Please select a valid route.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Please select a route to remove.", "No Route Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected route
            if (!(comboBoxRoutes.SelectedItem is BusRoute selectedRoute))
            {
                MessageBox.Show("Please select a valid route.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
