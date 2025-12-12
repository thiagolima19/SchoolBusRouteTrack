using System;
using System.Data;
using System.Text;


namespace SchoolBusRouteTrack.Data
{
    //This class will be manipulated in the RouteView Form and USControlRouteView (part of Route registration) - Patricia
    internal class VehicleRepository
    {
        private DBHelper _db = new DBHelper();

        public DataTable GetVehicle() // Bring all vehicles to associate one to a Route
        {
            try
            {
                var sql = new StringBuilder();

                sql.AppendLine("Select v.VehicleID, v.Available, v.Company , v.NumberOfSeats, v.Plate, v.Type");
                sql.AppendLine("From Vehicle v ");
                sql.AppendLine("order by 1 ");

                var dt = _db.ExecuteSelect(sql.ToString(), null);

                return dt;
            }
            catch (Exception ex) { throw ex; }

        }
    }
}
