using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusRouteTrack.AdministratorSystem
{
    public class BusStop
    {
        public int StopID { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public bool? CheckedIn { get; set; } = false;

    }
}
