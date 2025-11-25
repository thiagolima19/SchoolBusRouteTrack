namespace SchoolBusRouteTrack.AdministratorSystem
{
    internal class Driver
    {
        public string _name { get; private set; }
        public int _driverID { get; private set; }
        public string _address { get; private set; }
        public string _phoneNumber { get; private set; }
        public string _assignedVehicle { get; private set; }
        
        public Driver(string name, string address, string phoneNumber, string assignedVehicle)
        {
            _name = name;
            _address = address;
            _phoneNumber = phoneNumber;
            _assignedVehicle = assignedVehicle;
        }

    }
}