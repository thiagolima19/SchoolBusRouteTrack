using GMap.NET;
using SchoolBusRouteTrack.AdministratorSystem;
using SchoolBusRouteTrack.Data;
using SchoolBusRouteTrack.TripModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolBusRouteTrack.DriverSystem
{
    public partial class UserControlAttendence : UserControl
    {
        private int _driverId;
        private DBHelper db = new DBHelper();

        public UserControlAttendence(int driverId)
        {
            InitializeComponent();
            _driverId = driverId;
            LoadAttendanceData();
        }

        private void LoadAttendanceData()
        {
            try
            {
                studentsAttendancePanel.Controls.Clear();
                List<Trip> trips = db.GetTrips(_driverId);

                if (trips.Count == 0)
                {
                    comboBoxRoutes.Text = "No routes";
                }

                else
                {
                    string status = "";
                    foreach (var trip in trips)
                    {
                        if(trip.Status == "In Progress")
                        {
                            status = trip.Status;
                            string direction1 = trip.RouteID % 2 == 0 ? "Outbound" : "Inbound";
                            comboBoxRoutes.Text = trip.RouteID + " - " + direction1;
                        }   
                    }

                    if(status == "")
                    {
                        comboBoxRoutes.Text = "Choose below";
                    }
                    
                    foreach (var trip in trips)
                    {
                        string direction2 = trip.RouteID % 2 == 0 ? "Outbound" : "Inbound";
                        comboBoxRoutes.Items.Add(trip.RouteID + " - " + direction2);
                    }
                }
                    
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error loading trips: {ex.Message}");
            }
        }

        private void UserControlAttendence_Load(object sender, EventArgs e)
        {

        }

        private void buttonSaveAttendance_Click(object sender, EventArgs e)
        {

        }

    }
}
