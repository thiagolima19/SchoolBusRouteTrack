using SchoolBusRouteTrack.AdministratorSystem;
using System;

using System.Data;

using System.Text;


namespace SchoolBusRouteTrack.Data
{

    internal class RouteStopRepository
    {
        private DBHelper _db = new DBHelper();

        public BusRoute GetActiveRouteStops(int routeID)
        {
            try
            {
                var sql = new StringBuilder();

                sql.AppendLine("SELECT rt.Description, r.RouteStopID, s.Address, s.Latitude, s.Longitude, s.StopID ");
                sql.AppendLine("FROM RouteStop r ");
                sql.AppendLine("JOIN Trip t ON r.RouteID = t.RouteID ");
                sql.AppendLine("JOIN Stop s ON r.StopID = s.StopID ");
                sql.AppendLine("join Route rt on r.RouteID = rt.RouteID ");
                sql.AppendFormat("WHERE t.Status = 'In Progress' AND r.RouteID = {0} ", routeID);
                sql.AppendLine("ORDER BY r.StopOrder ASC ");

                DataTable routeStops = _db.ExecuteSelect(sql.ToString(), null);

                BusRoute routeInfo = new BusRoute();

                foreach (DataRow routeStop in routeStops.Rows)
                {
                    if (routeInfo.RouteName == null)
                    {
                        routeInfo.RouteName = routeStop["Description"].ToString();
                    }

                    routeInfo.Stops.Add(new BusStop
                    {
                        Latitude = Convert.ToDouble(routeStop["Latitude"]),
                        Longitude = Convert.ToDouble(routeStop["Longitude"]),
                        Name = routeStop["Address"].ToString(),
                        StopID = Convert.ToInt32(routeStop["StopID"])
                    });
                }

                return routeInfo;
            }
            catch (Exception ex) { throw ex; }

        }


    }
}
