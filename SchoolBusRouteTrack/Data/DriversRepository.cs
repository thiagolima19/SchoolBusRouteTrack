using Microsoft.Data.SqlClient;
using SchoolBusRouteTrack.AdministratorSystem;
using SchoolBusRouteTrack.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SchoolBusRouteTrack.Data
{
    internal class DriversRepository
    {
        private DBHelper _db = new DBHelper();

        public DataTable GetDrivers()
        {
            try
            {
                var sql = new StringBuilder();

                sql.AppendLine("Select d.DriverID, d.FullName, d.Phone, d.Status, d.Latitude, d.Longitude,d.Address, d.VehicleID ");
                sql.AppendLine(" From Driver d ");
                sql.AppendLine(" order by 1 ");

                var dt = _db.ExecuteSelect(sql.ToString(), null);

                return dt;
            }
            catch (Exception ex) { throw ex; }
        }

        //insert a driver
        public bool InsertDriver(Driver driver)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@FullName", driver.Name),
                new SqlParameter("@Phone", driver.Phone),
                new SqlParameter("@Latitude", driver.Address.Latitude),
                new SqlParameter("@Longitude", driver.Address.Longitude),
                new SqlParameter("@Address", driver.Address.FullAddress)
            };

            return _db.ExecuteNonQuerySP("sp_InsertDriver", parameters) > 0;
        }

        // get all drivers
        public List<Driver> GetAllDrivers()
        {
            DataTable dt = _db.ExecuteDataTable("sp_GetAllDrivers");
            List<Driver> drivers = new List<Driver>();

            foreach (DataRow row in dt.Rows)
            {
                var location = new MapLocation(
                    row["Latitude"] != DBNull.Value ? Convert.ToSingle(row["Latitude"]) : 0,
                    row["Longitude"] != DBNull.Value ? Convert.ToSingle(row["Longitude"]) : 0,
                    row["Address"]?.ToString()
                );

                drivers.Add(new Driver(
                    Convert.ToInt32(row["DriverID"]),
                    row["FullName"].ToString(),
                    row["Phone"].ToString(),
                    row["Status"].ToString(),
                    location,
                    row["AssignedVehicle"]?.ToString(),
                    row["AssignedRoute"]?.ToString()
                ));
            }

            return drivers;
        }

        // update driver
        public bool UpdateDriver(Driver driver)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DriverID", driver.DriverID),
                new SqlParameter("@FullName", driver.Name),
                new SqlParameter("@Phone", driver.Phone),
                new SqlParameter("@Latitude", driver.Address.Latitude),
                new SqlParameter("@Longitude", driver.Address.Longitude),
                new SqlParameter("@Address", driver.Address.FullAddress)
            };

            return _db.ExecuteNonQuerySP("sp_UpdateDriver", parameters) > 0;
        }

        // delete driver
        public bool DeleteDriver(int driverID)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@DriverID", driverID)
            };

            return _db.ExecuteNonQuerySP("sp_DeleteDriver", parameters) > 0;
        }

        // get driver by ID
        public Driver GetDriverById(int driverID)
        {
            SqlParameter[] parameters = { new SqlParameter("@DriverID", driverID) };
            DataTable dt = _db.ExecuteDataTable("sp_GetDriverById", parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                var location = new MapLocation(
                    row["Latitude"] != DBNull.Value ? Convert.ToSingle(row["Latitude"]) : 0,
                    row["Longitude"] != DBNull.Value ? Convert.ToSingle(row["Longitude"]) : 0,
                    row["Address"]?.ToString()
                );

                return new Driver(
                    Convert.ToInt32(row["DriverID"]),
                    row["FullName"].ToString(),
                    row["Phone"].ToString(),
                    row["Status"].ToString(),
                    location,
                    row["AssignedVehicle"]?.ToString()
                );
            }

            return null;
        }

        //get vehicle avalaiable
        public List<Vehicle> GetAvailableVehicles()
        {
            DataTable dt = _db.ExecuteDataTable("sp_GetAvailableVehicles");
            List<Vehicle> vehicles = new List<Vehicle>();

            foreach (DataRow row in dt.Rows)
            {
                vehicles.Add(new Vehicle
                {
                    VehicleID = Convert.ToInt32(row["VehicleID"]),
                    Plate = row["Plate"].ToString(),
                    Company = row["Company"]?.ToString(),
                    Type = row["Type"].ToString(),
                    NumberOfSeats = Convert.ToInt32(row["NumberOfSeats"])
                });
            }
            return vehicles;
        }

        //get all routes
        public List<Route> GetAllRoutes()
        {
            DataTable dt = _db.ExecuteDataTable("sp_GetAllRoutes");
            List<Route> routes = new List<Route>();

            foreach (DataRow row in dt.Rows)
            {
                routes.Add(new Route
                {
                    RouteID = Convert.ToInt32(row["RouteID"]),
                    RouteNumber = row["RouteNumber"].ToString(),
                    Description = row["Description"].ToString(),
                    SchoolName = row["SchoolName"].ToString(),
                    AssignedDriver = row["AssignedDriver"]?.ToString(),
                    AssignedVehicle = row["AssignedVehicle"]?.ToString()
                });
            }
            return routes;
        }

        //assign a vehicle to a route
        public bool AssignVehicleToRoute(int routeId, int vehicleId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@RouteID", routeId),
            new SqlParameter("@VehicleID", vehicleId)
            };

            return _db.ExecuteNonQuerySP("sp_AssignVehicleToRoute", parameters) > 0;
        }

        //assign driver to a route
        public bool AssignDriverToRoute(int routeId, int driverId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@RouteID", routeId),
            new SqlParameter("@DriverID", driverId)
            };

            return _db.ExecuteNonQuerySP("sp_AssignDriverToRoute", parameters) > 0;
        }
    }
}


