using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusRouteTrack.AdministratorSystem
{
    public class BusRoute
    {
        public int RouteID { get; set; }
        public string RouteName { get; set; }
        public string SchoolName { get; set; }
        public string DriverName { get; set; }
        public string Plate { get; set; }
        public List<BusStop> Stops { get; set; } = new List<BusStop>();
    }
}
