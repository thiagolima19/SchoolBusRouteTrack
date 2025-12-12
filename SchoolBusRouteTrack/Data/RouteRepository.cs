using Microsoft.Data.SqlClient;
using SchoolBusRouteTrack.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

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
            sql.AppendLine("SELECT r.RouteID, r.RouteNumber, r.Description, s.Address, s.Latitude, s.Longitude, ");
            sql.AppendLine("       sc.Name AS SchoolName, d.FullName AS DriverName, v.Plate ");
            sql.AppendLine("FROM RouteStop rs ");
            sql.AppendLine("INNER JOIN Route r ON r.RouteID = rs.RouteID ");
            sql.AppendLine("INNER JOIN Stop s ON s.StopID = rs.StopID ");
            sql.AppendLine("LEFT JOIN School sc ON sc.SchoolID = r.SchoolID ");
            sql.AppendLine("LEFT JOIN Driver d ON d.DriverID = r.DriverID ");
            sql.AppendLine("LEFT JOIN Vehicle v ON v.VehicleID = r.VehicleID ");
            sql.AppendLine("ORDER BY r.RouteID, rs.StopOrder ");

            var dt = _db.ExecuteSelect(sql.ToString(), null);

            return dt;
        }

        // Get a specific route by ID with all its details
        public Route GetRouteById(int routeId)
        {
            var sql = "SELECT RouteID, RouteNumber, Description, SchoolID, DriverID, VehicleID FROM Route WHERE RouteID = @RouteID";
            var dt = _db.ExecuteSelect(sql, new SqlParameter[] { new SqlParameter("@RouteID", routeId) });

            if (dt.Rows.Count == 0)
                return null;

            var row = dt.Rows[0];
            return new Route
            {
                RouteID = Convert.ToInt32(row["RouteID"]),
                RouteNumber = row["RouteNumber"].ToString(),
                Description = row["Description"]?.ToString(),
                SchoolID = Convert.ToInt32(row["SchoolID"]),
                DriverID = row["DriverID"] != DBNull.Value ? (int?)Convert.ToInt32(row["DriverID"]) : null,
                VehicleID = row["VehicleID"] != DBNull.Value ? (int?)Convert.ToInt32(row["VehicleID"]) : null
            };
        }

        public string GetNextRouteNumber() // Patricia - testes
        {
            var sql = @"SELECT RouteNumber FROM Route ORDER BY RouteNumber DESC";

            var dt = _db.ExecuteSelect(sql, null);

            // if there is no route number
            if (dt.Rows.Count == 0)
                return "R001";

            string lastRouteNum = dt.Rows[0]["RouteNumber"].ToString();

            // Expected format R + number (ex: R012)
            if (lastRouteNum.StartsWith("R") && int.TryParse(lastRouteNum.Substring(1), out int num))
            {
                int next = num + 1;
                return "R" + next.ToString("000"); // 3 digits
            }

            // fallback if something is wrong in the DB
            return "R001";
        }


        // Get all stops for a specific route ordered by StopOrder
        public List<Stop> GetStopsByRouteId(int routeId)
        {
            var sql = new StringBuilder();
            sql.AppendLine("SELECT s.StopID, s.Address, s.Latitude, s.Longitude ");
            sql.AppendLine("FROM RouteStop rs ");
            sql.AppendLine("INNER JOIN Stop s ON s.StopID = rs.StopID ");
            sql.AppendLine("WHERE rs.RouteID = @RouteID ");
            sql.AppendLine("ORDER BY rs.StopOrder ");

            var dt = _db.ExecuteSelect(sql.ToString(), new SqlParameter[] { new SqlParameter("@RouteID", routeId) });

            return Stop.FromDataTable(dt);
        }

        // Check if RouteNumber already exists (excluding a specific RouteID for edit mode)
        public bool RouteNumberExists(string routeNumber, int? excludeRouteId = null)
        {
            var sql = "SELECT COUNT(*) FROM Route WHERE RouteNumber = @RouteNumber";
            if (excludeRouteId.HasValue)
            {
                sql += " AND RouteID <> @RouteID";
            }

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@RouteNumber", routeNumber)
            };

            if (excludeRouteId.HasValue)
            {
                parameters.Add(new SqlParameter("@RouteID", excludeRouteId.Value));
            }

            var dt = _db.ExecuteSelect(sql, parameters.ToArray());
            int count = Convert.ToInt32(dt.Rows[0][0]);
            return count > 0;
        }

        // Delete a route and its RouteStop entries
        public void DeleteRoute(int routeId)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        // First delete RouteStop entries
                        string deleteRouteStopSql = "DELETE FROM RouteStop WHERE RouteID = @RouteID";
                        using (var cmd = new SqlCommand(deleteRouteStopSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@RouteID", routeId);
                            cmd.ExecuteNonQuery();
                        }

                        // Then delete the Route
                        string deleteRouteSql = "DELETE FROM Route WHERE RouteID = @RouteID";
                        using (var cmd = new SqlCommand(deleteRouteSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@RouteID", routeId);
                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
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
                            OUTPUT INSERTED.RouteID
                            VALUES (@RouteNumber, @Description, @SchoolID, @DriverID, @VehicleID);";

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
                                OUTPUT INSERTED.StopID
                                VALUES (@Address, @Latitude, @Longitude);";

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
                        throw;
                    }
                }
            }
        }
    }
}
