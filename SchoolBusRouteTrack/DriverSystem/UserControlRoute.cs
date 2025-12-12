using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
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
        private List<BusStop> _busStops;
        private List<BusStopCheckin> _checkins = new List<BusStopCheckin>();

        public UserControlRoute(int driverId)
        {
            InitializeComponent();
            _driverId = driverId;
            LoadActiveRoutes();
            InitializeGMap();



        }

        private void LoadActiveRoutes()
        {
            TripRepository trip = new TripRepository();


            List<Trip> activeRoutes = trip.GetActiveTrips(_driverId);

            comboBoxRoutes.Items.Clear();

            comboBoxRoutes.DataSource = activeRoutes;
            comboBoxRoutes.DisplayMember = "RouteDescription";
            comboBoxRoutes.ValueMember = "RouteID";
            comboBoxRoutes.Tag = "RouteID";

            if (activeRoutes.Count > 0)
            {
                _selectedRouteId = activeRoutes[0].RouteID;
                LoadRouteData(_selectedRouteId.Value);
            }

        }

        private void LoadRouteData(int routeID)
        {
            RouteStopRepository repo = new RouteStopRepository();
            List<BusStop> stops = new List<BusStop>();

            if (_selectedRouteId == null) return;

            BusRoute busRoute = repo.GetActiveRouteStops(routeID);


            foreach (BusStop stop in busRoute.Stops)
            {
                var wasAlreadyChecked = _checkins.Find(busStops => busStops.BusStopID == stop.StopID);

                if (wasAlreadyChecked != null)
                {
                    stop.CheckedIn = true;
                }

                stops.Add(stop);
            }

            checkedListBoxBusStop.Items.Clear();
            checkedListBoxBusStop.Items.AddRange(stops.ToArray());
            checkedListBoxBusStop.DisplayMember = "Name";

            //Prevent triggering ItemCheck event while setting checked items
            checkedListBoxBusStop.ItemCheck -= checkedListBoxBusStop_ItemCheck;
            //Mark already checked in stops
            for (int i = 0; i < stops.Count; i++)
            {
                if (stops[i].CheckedIn == true)
                {
                    checkedListBoxBusStop.SetItemChecked(i, true);
                }
            }
            //Reattach the event handler
            checkedListBoxBusStop.ItemCheck += checkedListBoxBusStop_ItemCheck;


            _busStops = stops;
        }

        private void UserControlRoute_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxRoutes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selectedRouteId == null) return;

            int selectedRouteTag = (int)comboBoxRoutes.SelectedValue;

            LoadRouteData(selectedRouteTag);
        }

        private void checkedListBoxBusStop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selectedRouteId == null) return;

            int selectedStopIndex = checkedListBoxBusStop.SelectedIndex;

            BusStop busStop = _busStops[selectedStopIndex];

            DrawBusStopMarker(busStop.Latitude, busStop.Longitude);
            gMapControlRoute.Position = new PointLatLng(busStop.Latitude, busStop.Longitude);
            gMapControlRoute.Visible = true;

        }

        private void checkedListBoxBusStop_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int selectedStopIndex = e.Index;

            BusStop busStop = _busStops[selectedStopIndex];

            if (e.NewValue == CheckState.Checked)
            {
                _checkins.Add(new BusStopCheckin
                {
                    BusStopID = busStop.StopID,
                    BusStop = busStop,
                    CheckinTime = DateTime.Now
                });
            }
        }

        private void InitializeGMap()
        {
            gMapControlRoute.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = AccessMode.ServerOnly;

            //zoom in and out and drag map
            gMapControlRoute.MinZoom = 4;
            gMapControlRoute.MaxZoom = 20;
            gMapControlRoute.Zoom = 13;
            gMapControlRoute.MouseWheelZoomType = MouseWheelZoomType.ViewCenter;
            gMapControlRoute.CanDragMap = false;
            gMapControlRoute.IgnoreMarkerOnMouseWheel = false;
            // remove red cross from the map
            gMapControlRoute.ShowCenter = false;

            // initial center position based on calgary's latitude and longitude
            gMapControlRoute.Position = new PointLatLng(51.0501, -114.08529);
            gMapControlRoute.Visible = false;
        }

        private void DrawBusStopMarker(double lat, double lng)
        {
            gMapControlRoute.Overlays.Clear();

            GMarkerGoogle driverMarker = new GMarkerGoogle(
                new PointLatLng(lat, lng),
                GMarkerGoogleType.red_small
            );

            GMapOverlay driverOverlay = new GMapOverlay("driver");
            driverOverlay.Markers.Add(driverMarker);

            gMapControlRoute.Overlays.Add(driverOverlay);
        }


    }
}
