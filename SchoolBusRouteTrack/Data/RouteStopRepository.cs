using System;

using System.Data;

using System.Text;


namespace SchoolBusRouteTrack.Data
{
    
    internal class RouteStopRepository
    {
        private DBHelper _db = new DBHelper();

        public DataTable GetRouteStops() 
        {
            try
            {
                var sql = new StringBuilder();

                
                sql.AppendLine("SELECT StopID,StopOrder ");
                sql.AppendLine("FROM RouteStop ");
                sql.AppendLine("WHERE RouteID=5 ");

                var dt = _db.ExecuteSelect(sql.ToString(), null);

                return dt;
            }
            catch (Exception ex) { throw ex; }

        }


    }
}
