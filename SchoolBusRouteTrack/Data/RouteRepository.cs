using SchoolBusRouteTrack.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusRouteTrack.Data
{
    //This class will be manipulated in the RouteView Form and USControlRouteView (part of Route registration) - Patricia
    //Route, Stops and RouteStops CRUDS
    internal class RouteRepository
    {
        private DBHelper _db = new DBHelper();

        private static readonly string ConnectionString =
           ConfigurationManager.ConnectionStrings["SchoolBusRouteTrackerDB"].ConnectionString;

        public DataTable GetRoutesAndStops() // Bring all routes with their stops
        {
            var sql = new StringBuilder();
            sql.AppendLine("select r.RouteID, r.RouteNumber , r.Description , s.Address, s.Latitude,s.Longitude ");
            sql.AppendLine("from RouteStop  rs ");
            sql.AppendLine("inner join Route r on r.RouteID = rs.RouteID ");
            sql.AppendLine("inner join Stop s on s.StopID = rs.StopID ");
            sql.AppendLine("order by 1 ");

            var dt = _db.ExecuteSelect(sql.ToString(), null);

            return dt;
        }

        // Main Method: INSERT/UPDATE Route + Stops + RouteStop (IN TRANSACTION)
        public void SaveRouteWithStops(Route route, List<Stop> stops)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        // INSERT ROUTE
                        if (route.RouteID == 0)
                        {
                            string insertRouteSql = @"
                            INSERT INTO Route (RouteNumber, Description, SchoolID, DriverID, VehicleID)
                            VALUES (@RouteNumber, @Description, @SchoolID, @DriverID, @VehicleID);
                            SELECT SCOPE_IDENTITY();";

                            using (var cmd = new SqlCommand(insertRouteSql, conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@RouteNumber", route.RouteNumber);
                                cmd.Parameters.AddWithValue("@Description", (object)route.Description ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@SchoolID", route.SchoolID);
                                cmd.Parameters.AddWithValue("@DriverID", (object)route.DriverID ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@VehicleID", (object)route.VehicleID ?? DBNull.Value);
                                route.RouteID = Convert.ToInt32(cmd.ExecuteScalar());
                            }
                        }
                        // UPDATE ROUTE
                        else
                        {
                            string updateRouteSql = @"
                            UPDATE Route
                            SET RouteNumber = @RouteNumber,
                                Description = @Description,
                                SchoolID    = @SchoolID,
                                DriverID    = @DriverID,
                                VehicleID   = @VehicleID
                            WHERE RouteID   = @RouteID;";

                            using (var cmd = new SqlCommand(updateRouteSql, conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@RouteID", route.RouteID);
                                cmd.Parameters.AddWithValue("@RouteNumber", route.RouteNumber);
                                cmd.Parameters.AddWithValue("@Description", (object)route.Description ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@SchoolID", route.SchoolID);
                                cmd.Parameters.AddWithValue("@DriverID", (object)route.DriverID ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@VehicleID", (object)route.VehicleID ?? DBNull.Value);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        // INSERT STOPS
                        foreach (var stop in stops)
                        {
                            if (stop.StopID == 0)
                            {
                                string insertStopSql = @"
                                INSERT INTO Stop (Address, Latitude, Longitude)
                                VALUES (@Address, @Latitude, @Longitude);
                                SELECT SCOPE_IDENTITY();";

                                using (var cmd = new SqlCommand(insertStopSql, conn, tx))
                                {
                                    cmd.Parameters.AddWithValue("@Address", stop.Address);
                                    cmd.Parameters.AddWithValue("@Latitude", stop.Latitude);
                                    cmd.Parameters.AddWithValue("@Longitude", stop.Longitude);

                                    stop.StopID = Convert.ToInt32(cmd.ExecuteScalar());
                                }
                            }
                            //UPDATE STOPS
                            else
                            {
                                string updateStopSql = @"
                                UPDATE Stop
                                SET Address  = @Address,
                                    Latitude = @Latitude,
                                    Longitude = @Longitude
                                WHERE StopID = @StopID;";

                                using (var cmd = new SqlCommand(updateStopSql, conn, tx))
                                {
                                    cmd.Parameters.AddWithValue("@StopID", stop.StopID);
                                    cmd.Parameters.AddWithValue("@Address", stop.Address);
                                    cmd.Parameters.AddWithValue("@Latitude", stop.Latitude);
                                    cmd.Parameters.AddWithValue("@Longitude", stop.Longitude);

                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        // DELETE ROUTESTOP
                        string deleteRouteStopSql = @"DELETE FROM RouteStop WHERE RouteID = @RouteID;";
                        using (var cmdDel = new SqlCommand(deleteRouteStopSql, conn, tx))
                        {
                            cmdDel.Parameters.AddWithValue("@RouteID", route.RouteID);
                            cmdDel.ExecuteNonQuery();
                        }

                        // INSERT ROUTESTOP
                        string insertRouteStopSql = @"
                        INSERT INTO RouteStop (RouteID, StopID, StopOrder)
                        VALUES (@RouteID, @StopID, @StopOrder);";

                        for (int i = 0; i < stops.Count; i++)
                        {
                            using (var cmd = new SqlCommand(insertRouteStopSql, conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@RouteID", route.RouteID);
                                cmd.Parameters.AddWithValue("@StopID", stops[i].StopID);
                                cmd.Parameters.AddWithValue("@StopOrder", i + 1);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw; // tratar !!!
                    }
                }
            }
        }
    }
}
