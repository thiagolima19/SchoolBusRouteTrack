namespace SchoolBusRouteTrack
{
    internal class MapLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string FullAddress { get; set; }
        public int UserID { get; set; }
        public MapLocation(double latitude, double longitude, string fullAddress, int userID) {
            Latitude = latitude;
            Longitude = longitude;
            FullAddress = fullAddress;
            UserID = userID;
        }
    }
}
