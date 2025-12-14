using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusRouteTrack.Models
{
    public class Driver
    {
        public int DriverID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public string AssignedVehicle { get; set; }
        public string AssignedRoute { get; set; }
        public MapLocation Address { get; set; }  // Stores Latitude, Longitude, Address


        //Combobox/Listbox Display 
        public string FullName => Name;

        public override string ToString()
        {
            return Name;
        }

        //DEFAULT CONSTRUCTOR 
        public Driver()
        {
            Status = "Active";
        }

        //COMPLETE CONSTRUCTOR (Used by Repository)
        public Driver(
            int driverID,
            string name,
            string phone,
            string status,
            MapLocation address,
            string assignedVehicle,
            string assignedRoute = null
        )
        {
            DriverID = driverID;
            Name = name;
            Phone = phone;
            Status = status;
            Address = address;
            AssignedVehicle = assignedVehicle;
            AssignedRoute = assignedRoute;
        }


        //  LOAD FROM DATATABLE (Student Pattern) 

        public static List<Driver> FromDataTable(DataTable dt)
        {
            List<Driver> list = new List<Driver>();

            foreach (DataRow row in dt.Rows)
            {
                MapLocation loc = new MapLocation(
                    row["Latitude"] != DBNull.Value ? Convert.ToDouble(row["Latitude"]) : 0,
                    row["Longitude"] != DBNull.Value ? Convert.ToDouble(row["Longitude"]) : 0,
                    row["Address"]?.ToString()
                );

                list.Add(new Driver(
                    Convert.ToInt32(row["DriverID"]),
                    row["FullName"].ToString(),
                    row["Phone"].ToString(),
                    row["Status"].ToString(),
                    loc,
                    row.Table.Columns.Contains("AssignedVehicle")
                        ? row["AssignedVehicle"]?.ToString()
                        : null,
                    row.Table.Columns.Contains("AssignedRoute")
                        ? row["AssignedRoute"]?.ToString()
                        : null
                ));
            }

            return list;
        }

    }
}
