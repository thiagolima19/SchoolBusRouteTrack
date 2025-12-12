using SchoolBusRouteTrack.AdministratorSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusRouteTrack
{
    public class BusStopCheckin
    {
        public int BusStopID { get; set; }
        public BusStop BusStop {  get; set; }
        public DateTime CheckinTime { get; set; }
    }
}
