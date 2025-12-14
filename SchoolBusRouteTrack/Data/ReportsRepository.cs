using Microsoft.Data.SqlClient;
using SchoolBusRouteTrack.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace SchoolBusRouteTrack.Reports
{
    internal class ReportRepository
    {
        private DBHelper _db = new DBHelper();

        /// <summary>
        /// Retrieves daily attendance report data for a specific route and date using a stored procedure.
        /// </summary>
        public DataTable GetDailyRouteAttendance(int routeId, DateTime reportDate)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@RouteID", routeId),
                    new SqlParameter("@ReportDate", reportDate.Date)
                };
                return _db.ExecuteSelectSP("sp_GetDailyRouteAttendance", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving daily route attendance report.", ex);
            }
        }

        /// <summary>
        /// Retrieves a summary of all completed trips for a given route using a stored procedure.
        /// </summary>
        public DataTable GetRouteTripSummary(int routeId)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@RouteID", routeId)
                };
                return _db.ExecuteSelectSP("sp_GetTripSummary", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving trip summary report.", ex);
            }
        }

        /// <summary>
        /// Retrieves a list of all available routes for report selection.
        /// </summary>
        public List<(int id, string number, string description)> GetRouteList()
        {
            List<(int id, string number, string description)> routes = new List<(int id, string number, string description)>();
            try
            {
                DataTable dt = _db.ExecuteSelectSP("sp_GetRouteList", null);

                foreach (DataRow row in dt.Rows)
                {
                    int id = Convert.ToInt32(row["RouteID"]);
                    string number = row["RouteNumber"].ToString();
                    string description = row["Description"].ToString();
                    routes.Add((id, number, description));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving route list for report selection.", ex);
            }
            return routes;
        }
    }
}