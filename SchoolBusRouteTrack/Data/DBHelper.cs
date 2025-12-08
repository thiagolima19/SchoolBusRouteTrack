using Microsoft.Data.SqlClient;
using SchoolBusRouteTrack.TripModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using SchoolBusRouteTrack.UserModel;

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

        //checks and validates the login for a given user id
        public LoginUser ValidateLoginSP(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ValidateLogin", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new LoginUser
                    {
                        UserID = Convert.ToInt32(reader["UserID"]),
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        Role = reader["Role"].ToString(),
                        DriverID = reader["DriverID"] != DBNull.Value ? (int?)Convert.ToInt32(reader["DriverID"]) : null
                    };
                }
            }
            return null;
        }

        //get all students from studentRepository.cs
        public DataTable ExecuteDataTable(string procName, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(procName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        //insert/update/delete student
        public int ExecuteNonQuerySP(string procName, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(procName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        //Execute without using Store Procedures - Patricia
        public DataTable ExecuteSelect(string sql, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;   // it's not Stored Procedure

                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        
                        adapter.Fill(dt);
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.ToString());
                        throw ex;
                    } // fulfill Data table with SELECT result
                    return dt;
                }
            }
        }

        //gets all the trips on DB for a driver ID
        public List<Trip> GetTrips(int driverId)
        {
            List<Trip> trips = new List<Trip>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetTripsByDriver", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DriverID", driverId);

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        trips.Add(new Trip
                        {
                            TripID = (int)reader["TripID"],
                            RouteID = (int)reader["RouteID"],
                            DriverID = (int)reader["DriverID"],
                            StartTime = reader["StartTime"] as DateTime?,
                            EndTime = reader["EndTime"] as DateTime?,
                            Status = reader["Status"].ToString(),
                            RouteNumber = reader["RouteNumber"].ToString(),        
                            RouteDescription = reader["RouteDescription"].ToString(), 
                            SchoolName = reader["SchoolName"].ToString()           
                        });
                    }
                    reader.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"SQL Error: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return trips;
        }

        //add the time and date when the trip is started
        public bool StartTrip(int tripId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand("sp_StartTrip", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TripID", tripId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        //add the time and date when the trip is ended
        public bool EndTrip(int tripId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand("sp_EndTrip", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TripID", tripId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}