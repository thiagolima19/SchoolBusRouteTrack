namespace SchoolBusRouteTrack
{
    internal class Driver
    {
        public int _driverID { get; private set; }
        public string _name { get; private set; }
        public MapLocation _address { get; private set; }
        public string _phoneNumber { get; private set; }
        public string _assignedVehicle { get; private set; }
        
        public Driver(int driverID, string name, MapLocation address, string phoneNumber, string assignedVehicle)
        {
            _driverID = driverID;
            _name = name;
            _address = address;
            _phoneNumber = phoneNumber;
            _assignedVehicle = assignedVehicle;
        }

    }
}