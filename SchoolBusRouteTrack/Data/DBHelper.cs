using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SchoolBusRouteTrack.Data
{
    public class DBHelper
    {
        private static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["SchoolBusRouteTrackerDB"].ConnectionString;

        // Method to open a connection
        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        // Generic method to execute a query that returns a single object (like a count or a login check)
        public object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}