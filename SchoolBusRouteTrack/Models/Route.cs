
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
        public string SchoolName { get; set; }
        public string AssignedDriver { get; set; }
        public string AssignedVehicle { get; set; }
        public string AssignedRoute { get; set; }

        public override string ToString()
        {
            return $"{RouteNumber}: {Description} ({SchoolName})";
        }
    }
}
