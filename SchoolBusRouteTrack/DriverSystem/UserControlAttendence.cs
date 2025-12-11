using GMap.NET;
using SchoolBusRouteTrack.AdministratorSystem;
using SchoolBusRouteTrack.Data;
using SchoolBusRouteTrack.Models;
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

            studentsAttendancePanel.Controls.Clear();
            try
            {
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
                        comboBoxStops.Text = "Choose route";
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

            if (comboBoxRoutes.Text != "Choose below")
            {
                string stringRouteId = comboBoxRoutes.Text.Split(' ')[0];
                int _routeId = int.Parse(stringRouteId);

                try
                {
                    List<Stop> stops = db.GetStopsByRoute(_routeId);

                    if (stops.Count == 0)
                    {
                        comboBoxStops.Text = "No stops";
                    }

                    else
                    {
                        comboBoxStops.Text = stops[0].StopID + " - " + stops[0].Address;
                        foreach (var stop in stops)
                        {
                            comboBoxStops.Items.Add(stop.StopID + " - " + stop.Address);
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading stops: {ex.Message}");
                }
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
