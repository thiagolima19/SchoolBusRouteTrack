using SchoolBusRouteTrack.Data;
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

        public UserControlRoute(int driverId)
        {
            InitializeComponent();
            _driverId = driverId;
            LoadRouteData();
        }

        private void LoadRouteData()
        {
            RouteStopRepository repo = new RouteStopRepository();
            var stops = new List <RouteStop>();
            DataTable dt = repo.GetRouteStops();


            foreach (DataRow stop in dt.Rows)
            {
                stops.Add(new RouteStop
                {
                    StopID = Convert.ToInt32 (stop["StopId"]),
                    StopOrder = Convert.ToInt32 (stop["StopOrder"]),
                 });
            }

            checkedListBoxBusStop.Items.Clear();
            foreach (var stop in stops.OrderBy(s => s.StopOrder))
            {
                checkedListBoxBusStop.Items.Add($"Stop {stop.StopOrder} - ID: {stop.StopID}");
            }

        }

        private void UserControlRoute_Load(object sender, EventArgs e)
        {

        }
    }
}
