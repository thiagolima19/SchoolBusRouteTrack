
using System;
using System.Collections.Generic;
using System.Data;

namespace SchoolBusRouteTrack.Models
{
    public class School
    {
        public int SchoolID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Board { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }


        public static List<School> FromDataTable(DataTable dt)
        {
            var list = new List<School>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new School
                {
                    SchoolID = Convert.ToInt32(row["SchoolID"]),
                    Name = row["Name"].ToString(),
                    Address = row["Address"].ToString(),
                    PostalCode = row["PostalCode"].ToString(),
                    PhoneNumber = row["PhoneNumber"].ToString(),
                    Board = row["Board"]?.ToString(),
                    Latitude = row["Latitude"] == DBNull.Value ? (double?)null : Convert.ToDouble(row["Latitude"]),
                    Longitude = row["Longitude"] == DBNull.Value ? (double?)null : Convert.ToDouble(row["Longitude"]),
                });
            }

            return list;
        }
    }
}
