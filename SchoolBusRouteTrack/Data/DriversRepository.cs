using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Patricia
namespace SchoolBusRouteTrack.Data
{
    //This class will be manipulated in the RouteView Form and USControlRouteView (part of Route registration) - Patricia
    internal class DriversRepository
    {
        private DBHelper _db = new DBHelper();

        public DataTable GetDrivers() // From DB
        {
            try
            {
                var sql = new StringBuilder();

                sql.AppendLine("Select d.DriverID, d.FullName, d.Phone, d.Status ");
                sql.AppendLine(" From Driver d ");
                sql.AppendLine(" order by 1 ");

                var dt = _db.ExecuteSelect(sql.ToString(), null);

                return dt;
            }
            catch (Exception ex) { throw ex; }            
        }
    }
}
