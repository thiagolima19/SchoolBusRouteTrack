using SchoolBusRouteTrack.Data;
using SchoolBusRouteTrack.TripModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SchoolBusRouteTrack.DriverSystem
{
    public partial class UserControlTrip : UserControl
    {
        private int _driverId;
        private DBHelper db = new DBHelper();
        public UserControlTrip(int driverId)
        {
            InitializeComponent();
            _driverId = driverId;
            LoadTrips();
        }
       
        //this method creates a card dinamically on the usercontroltrip
        private Panel CreateTripCard(Trip trip, string direction)
        {
            Panel card = new Panel();
            card.Width = 350;
            card.Height = 200; 
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Margin = new Padding(10);

            // Title (Inbound / Outbound)
            Label lblDirection = new Label();
            lblDirection.Text = direction;
            lblDirection.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblDirection.Location = new Point(10, 10);
            lblDirection.AutoSize = true;

            // Trip ID
            Label lblTrip = new Label();
            lblTrip.Text = $"Trip ID: {trip.TripID}";
            lblTrip.Location = new Point(10, 40);
            lblTrip.AutoSize = true;

            // Route Number and Description
            Label lblRouteInfo = new Label();
            lblRouteInfo.Text = $"{trip.RouteNumber}: {trip.RouteDescription}";
            lblRouteInfo.Location = new Point(10, 65);
            lblRouteInfo.AutoSize = true;
            lblRouteInfo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblRouteInfo.ForeColor = Color.DarkBlue;

            // School Name
            Label lblSchool = new Label();
            lblSchool.Text = $"School: {trip.SchoolName}";
            lblSchool.Location = new Point(10, 90);
            lblSchool.AutoSize = true;

            // Route ID 
            Label lblRoute = new Label();
            lblRoute.Text = $"Route ID: {trip.RouteID}";
            lblRoute.Location = new Point(10, 115);
            lblRoute.AutoSize = true;

            // Status
            Label lblStatus = new Label();
            lblStatus.Location = new Point(10, 140);
            lblStatus.AutoSize = true;
            lblStatus.Text = $"Status: {trip.Status}";

            // Status color coding change when the start button is clicked
            switch (trip.Status)
            {
                case "Pending":
                case "Scheduled":
                    card.BackColor = Color.FromArgb(255, 244, 214); 
                    break;
                case "In Progress":
                    card.BackColor = Color.FromArgb(220, 255, 220); 
                    break;
                case "Completed":
                    card.BackColor = Color.FromArgb(235, 235, 235); 
                    break;
            }

            // Start Button
            Button btnStart = new Button();
            btnStart.Text = trip.StartTime == null ? "Start Trip" : $"Started: {trip.StartTime?.ToString("hh:mm tt")}";
            btnStart.Location = new Point(10, 170);
            btnStart.Width = 150;
            btnStart.Tag = trip;
            btnStart.Click += BtnStart_Click;

            // End Button
            Button btnEnd = new Button();
            btnEnd.Text = trip.EndTime == null ? "End Trip" : $"Ended: {trip.EndTime?.ToString("hh:mm tt")}";
            btnEnd.Location = new Point(180, 170);
            btnEnd.Width = 150;
            btnEnd.Tag = trip;
            btnEnd.Click += BtnEnd_Click;

            // Button State Control 
            if (trip.StartTime != null)              
            {
                btnStart.Enabled = false;
                btnStart.BackColor = Color.LightGray;
            }

            if (trip.EndTime != null)                 
            {
                btnEnd.Enabled = false;
                btnEnd.BackColor = Color.LightGray;
            }

            if (trip.StartTime == null)
            {
                btnEnd.Enabled = false;
                btnEnd.BackColor = Color.LightGray;
            }

            card.Controls.Add(lblDirection);
            card.Controls.Add(lblTrip);
            card.Controls.Add(lblRouteInfo);
            card.Controls.Add(lblSchool);
            card.Controls.Add(lblRoute);
            card.Controls.Add(lblStatus);
            card.Controls.Add(btnStart);
            card.Controls.Add(btnEnd);

            return card;
        }
        //loads the trip from the DB using the driver id
        private void LoadTrips()
        {
            try
            {
                flowTripsPanel.Controls.Clear();

                List<Trip> trips = db.GetTrips(_driverId);

                if (trips.Count == 0)
                {
                    Label noTripsLabel = new Label();
                    noTripsLabel.Text = $"No trips found for driver {_driverId}.\nPlease contact administrator.";
                    noTripsLabel.Font = new Font("Segoe UI", 14);
                    noTripsLabel.AutoSize = true;
                    noTripsLabel.ForeColor = Color.Red;
                    flowTripsPanel.Controls.Add(noTripsLabel);
                    return;
                }

                foreach (var trip in trips)
                {
                    string direction = trip.RouteID % 2 == 0 ? "Outbound" : "Inbound";
                    var card = CreateTripCard(trip, direction);
                    flowTripsPanel.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading trips: {ex.Message}");
            }
        }

        //starts the trip and sends a message and reloads the UI
        private void BtnStart_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Trip trip = btn.Tag as Trip;

            if (db.StartTrip(trip.TripID))
            {
                MessageBox.Show("Trip started successfully!");
                LoadTrips(); 
            }
        }
        //ends the trip and sends a message and reloads the UI
        private void BtnEnd_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Trip trip = btn.Tag as Trip;

            if (db.EndTrip(trip.TripID))
            {
                MessageBox.Show("Trip ended successfully!");
                LoadTrips(); 
            }
        }
    }
}
