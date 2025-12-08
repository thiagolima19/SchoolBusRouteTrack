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
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }

        public static List<Driver> FromDataTable(DataTable dt)
        {
            var list = new List<Driver>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Driver
                {
                    DriverID = Convert.ToInt32(row["DriverID"]),
                    FullName = row["FullName"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Status = row["Status"].ToString()
                });
            }

            return list;
        }
    }
}
