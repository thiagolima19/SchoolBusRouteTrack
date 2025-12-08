using System;
using System.Collections.Generic;
using System.Data;


namespace SchoolBusRouteTrack.Models
{
    //This class will be manipulated in the RouteView Form and USControlRouteView (part of Route registration) - Patricia
    public class Stop
    {
        public int StopID { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public override string ToString()
        {
            return $"{Address}";
        }

        public static List<Stop> FromDataTable(DataTable dt)
        {
            var list = new List<Stop>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Stop
                {
                    StopID = Convert.ToInt32(row["StopID"]),
                    Address = row["Address"].ToString(),
                    Latitude = Convert.ToDouble(row["Latitude"]),
                    Longitude = Convert.ToDouble(row["Longitude"])
                });
            }
            return list;
        }
    }
}
