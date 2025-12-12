using System;
using System.Collections.Generic;
using System.Data;

namespace SchoolBusRouteTrack.Models
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public bool Available { get; set; }
        public string Company { get; set; }
        public int NumberOfSeats { get; set; }
        public string Plate { get; set; }
        public string Type { get; set; }

        public static List<Vehicle> FromDataTable(DataTable dt)
        {
            var list = new List<Vehicle>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Vehicle
                {
                    VehicleID = Convert.ToInt32(row["VehicleID"]),
                    Available = Convert.ToBoolean(row["Available"]),
                    Company = row["Company"].ToString(),
                    NumberOfSeats = Convert.ToInt32(row["NumberOfSeats"]),
                    Plate = row["Plate"].ToString(),
                    Type = row["Type"].ToString()
                });
            }

            return list;
        }
    }
}
