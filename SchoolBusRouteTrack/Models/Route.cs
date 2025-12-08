
//This class will be manipulated in the RouteView Form and USControlRouteView (part of Route registration) - Patricia
namespace SchoolBusRouteTrack.Data
{
    internal class Route
    {
        public int RouteID { get; set; }
        public string RouteNumber { get; set; }
        public string Description { get; set; }
        public int SchoolID { get; set; }
        public int? DriverID { get; set; }
        public int? VehicleID { get; set; }
    }
}
