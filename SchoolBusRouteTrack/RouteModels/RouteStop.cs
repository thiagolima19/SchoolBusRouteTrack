using SchoolBusRouteTrack.AdministratorSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusRouteTrack
{
    public class RouteStop
    {
        public int StopID {  get;  set; }
        public BusStop BusStop { get; set; }
        public int StopOrder { get; set; }
       
    }
}
