using System;

using System.Data;

using System.Text;


namespace SchoolBusRouteTrack.Data
{
    //This class will be manipulated in the RouteView Form and USControlRouteView (part of Route registration) - Patricia
    internal class SchoolRepository
    {
        private DBHelper _db = new DBHelper();

        public DataTable GetSchools() // Bring all Schools from DB to associate one to a Route
        {
            try
            {
                var sql = new StringBuilder();

                sql.AppendLine("select s.SchoolID, s.Name, s.Address, s.PostalCode, s.PhoneNumber, s.Board, s.Latitude, s.Longitude ");
                sql.AppendLine("from School s ");
                sql.AppendLine("order by 1 ");

                var dt = _db.ExecuteSelect(sql.ToString(), null);

                return dt;
            }
            catch (Exception ex) { throw ex; }
    
        }


    }
}
