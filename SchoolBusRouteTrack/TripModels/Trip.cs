using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusRouteTrack
{
    public class Trip
    {
        public int TripID { get; set; }
        public int RouteID { get; set; }
        public int DriverID { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Status { get; set; }
        public string RouteNumber { get; set; }      
        public string RouteDescription { get; set; } 
        public string SchoolName { get; set; }       
    }
}
