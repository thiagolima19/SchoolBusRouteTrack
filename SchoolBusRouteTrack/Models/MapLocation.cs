//namespace SchoolBusRouteTrack
//{
//    internal class MapLocation
//    {
//        public double Latitude { get; set; }
//        public double Longitude { get; set; }
//        public string FullAddress { get; set; }
//        public int UserID { get; set; }
//        public MapLocation(double latitude, double longitude, string fullAddress, int userID) {
//            Latitude = latitude;
//            Longitude = longitude;
//            FullAddress = fullAddress;
//            UserID = userID;
//        }
//    }
//}

using System;

namespace SchoolBusRouteTrack
{
    public class MapLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string FullAddress { get; set; }
        public int UserID { get; set; }

        public MapLocation(double latitude, double longitude, string fullAddress, int userID)
        {
            Latitude = latitude;
            Longitude = longitude;
            FullAddress = fullAddress;
            UserID = userID;
        }

        public MapLocation(double latitude, double longitude, string fullAddress)
        {
            Latitude = latitude;
            Longitude = longitude;
            FullAddress = fullAddress;
            UserID = 0;
        }

        // ⭐ FIXED: Required constructor (2 parameters)
        public MapLocation(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            FullAddress = "";
            UserID = 0;
        }

        public MapLocation(object latitude, object longitude, object fullAddress, object userID = null)
        {
            Latitude = latitude != DBNull.Value ? Convert.ToDouble(latitude) : 0;
            Longitude = longitude != DBNull.Value ? Convert.ToDouble(longitude) : 0;
            FullAddress = fullAddress != DBNull.Value ? fullAddress.ToString() : "";
            UserID = userID != null && userID != DBNull.Value ? Convert.ToInt32(userID) : 0;
        }
    }
}