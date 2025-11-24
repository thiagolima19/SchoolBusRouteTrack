using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusRouteTrack.AdministratorSystem
{
    public class Bus
    {
        public string BusID {  get; private set; }
        public BusRoute Route { get; private set; }
        public int CurrentStopIndex {  get; private set; }
    }
}
