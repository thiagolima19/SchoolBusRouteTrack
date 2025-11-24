using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusRouteTrack.AdministratorSystem
{
    public class BusRoute
    {
        public string RouteName { get;set; }
        public List<BusStop> Stops { get; set; } = new List<BusStop>();

    }
}
