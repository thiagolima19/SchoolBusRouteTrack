using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusRouteTrack.Data
{
    //checks the current user and sets its information
    public static class CurrentUser
    {
        public static int UserID { get; set; }
        public static string Username { get; set; }
        public static string Role { get; set; }
        public static int? DriverID { get; set; }

        public static void SetUser(int userId, string username, string role, int? driverId = null)
        {
            UserID = userId;
            Username = username;
            Role = role;
            DriverID = driverId;
        }

        public static void Clear()
        {
            UserID = 0;
            Username = string.Empty;
            Role = string.Empty;
            DriverID = null;
        }
    }
}
