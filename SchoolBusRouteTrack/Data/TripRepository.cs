using SchoolBusRouteTrack.AdministratorSystem;
using SchoolBusRouteTrack.Models;
using System;
using System.Collections.Generic;
using System.Data;

using System.Text;


namespace SchoolBusRouteTrack.Data
{
    internal class TripRepository
    {
        private DBHelper _db = new DBHelper();

        public List<Trip> GetActiveTrips(int driverID)
        {
            try
            {
                var sql = new StringBuilder();

                sql.AppendLine("SELECT t.TripID, t.RouteID, t.DriverID, t.Status, r.Description");
                sql.AppendLine("FROM Trip t ");
                sql.AppendLine("JOIN Route r ON t.RouteID = r.RouteID ");
                sql.AppendFormat("WHERE t.Status = 'In Progress' and t.DriverID = {0} ", driverID);

                DataTable activeTrips = _db.ExecuteSelect(sql.ToString(), null);

                List<Trip> tripsList = new List<Trip>();

                foreach (DataRow activeTrip in activeTrips.Rows)
                {
                    tripsList.Add(new Trip
                    {
                        TripID = Convert.ToInt32(activeTrip["TripID"]),
                        RouteID = Convert.ToInt32(activeTrip["RouteID"]),
                        DriverID = Convert.ToInt32(activeTrip["DriverID"]),
                        Status = activeTrip["Status"].ToString(),
                        RouteDescription = activeTrip["Description"].ToString()
                    });
                }

                return tripsList;
            }
            catch (Exception ex) { throw ex; }

        }
    }
}
