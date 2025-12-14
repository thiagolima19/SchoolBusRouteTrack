using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusRouteTrack.Models
{
    internal class StudentTrip
    {
        public int _tripId {  get; set; }
        public int _studentId { get; set; }
        public int _stopId { get; set; }
        public DateTime? _pickUpTime { get; set; }
        public DateTime? _dropOffTime { get; set; }
        public string _status { get; set; }

        public StudentTrip()
        {
        }

        internal StudentTrip(int tripId, int studentId, int stopId, DateTime? pickUpTime, DateTime? dropOffTime, string status)
        {
            _tripId = tripId;
            _studentId = studentId;
            _stopId = stopId;
            _pickUpTime = pickUpTime;
            _dropOffTime = dropOffTime;
            _status = status;
        }
    }
}
