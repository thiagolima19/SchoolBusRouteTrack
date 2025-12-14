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

        //Load data from the DB to the combo boxes 
        private void LoadAttendanceData()
        {
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
                            comboBoxRoutes.Text = trip.RouteID + " - " + trip.TripID + " - " + direction1;
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
                        comboBoxRoutes.Items.Add(trip.RouteID + " - " + trip.TripID + " - " + direction2);
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

        //Create the cards to be added to the main panel
        private Panel CreateAttendanceCard (Student student)
        {
            Panel attendCard = new Panel();
            attendCard.Width = 528;
            attendCard.Height = 30;
            attendCard.BackColor = Color.AliceBlue;
            attendCard.BorderStyle = BorderStyle.FixedSingle;
            attendCard.Margin = new Padding(5);
            attendCard.Tag = student._studentID;

            Label lblStudentName = new Label();
            lblStudentName.Text = student._name + " - " + student._studentID;
            lblStudentName.Font = new Font("Microsoft Sans Serif", 8);
            lblStudentName.Location = new Point(20, 8);
            lblStudentName.AutoSize = true;

            CheckBox cbPickUp = new CheckBox();
            cbPickUp.Text = "Picked up";
            cbPickUp.Font = new Font("Microsoft Sans Serif", 8);
            cbPickUp.Location = new Point(190, 5);
            cbPickUp.Tag = "PickUp";

            CheckBox cbDropOff = new CheckBox();
            cbDropOff.Text = "Dropped Off";
            cbDropOff.Font = new Font("Microsoft Sans Serif", 8);
            cbDropOff.Location = new Point(295, 5);
            cbDropOff.Tag = "DropOff";

            CheckBox cbAbsent = new CheckBox();
            cbAbsent.Text = "Absent";
            cbAbsent.Font = new Font("Microsoft Sans Serif", 8);
            cbAbsent.Location = new Point(408, 5);
            cbAbsent.Tag = "Absent";

            cbPickUp.CheckedChanged += (s, e) =>
            UpdateAttendanceCardState(attendCard, cbPickUp, cbDropOff, cbAbsent);

            cbDropOff.CheckedChanged += (s, e) =>
            UpdateAttendanceCardState(attendCard, cbPickUp, cbDropOff, cbAbsent);

            cbAbsent.CheckedChanged += (s, e) =>
            UpdateAttendanceCardState(attendCard, cbPickUp, cbDropOff, cbAbsent);
                   
            attendCard.Controls.Add(lblStudentName);
            attendCard.Controls.Add(cbPickUp);
            attendCard.Controls.Add(cbDropOff);
            attendCard.Controls.Add(cbAbsent);

            return attendCard;
        }

        //Create a card to be used when there are no students registered to that specific bus stop
        private Panel CreateNoStudentsCard()
        {
            Panel noStudentsCard = new Panel();
            noStudentsCard.Width = 500;
            noStudentsCard.Height = 30;
            noStudentsCard.BackColor = Color.White;
            noStudentsCard.BorderStyle = BorderStyle.FixedSingle;
            noStudentsCard.Margin = new Padding(5);

            Label lblStudentName = new Label();
            lblStudentName.Text = "No students for this stop!";
            lblStudentName.Font = new Font("Microsoft Sans Serif", 8);
            lblStudentName.Location = new Point(20, 9);
            lblStudentName.AutoSize = true;

            return noStudentsCard;
        }

        //Adding functionality to the button that returns all the students registered for the bus stop selected in the combobox
        private void buttonShowStudents_Click(object sender, EventArgs e)
        {
            try
            {
                studentsAttendancePanel.Controls.Clear();
                string stringStopId = comboBoxStops.Text.Split(' ')[0];
                int _stopId = int.Parse(stringStopId);

                List<Student> students = db.GetStudentsByStop(_stopId);

                if(students.Count == 0)
                {
                    var card = CreateNoStudentsCard();
                    studentsAttendancePanel.Controls.Add(card);
                }
                else
                {
                    foreach(Student student in students)
                    {
                        var card = CreateAttendanceCard(student);
                        studentsAttendancePanel.Controls.Add(card);
                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}");
            }
        }

        //Auxiliar method to return the status selected per student
        private string GetAttendanceStatus(Panel attendCard)
        {
            var checkedBox = attendCard.Controls
                .OfType<CheckBox>()
                .FirstOrDefault(cb => cb.Checked);

            return checkedBox?.Tag?.ToString(); // PickUp | DropOff | Absent | null
        }

        //Saves the attendance data in the DB
        private void buttonSaveAttendance_Click(object sender, EventArgs e)
        {
            List<StudentTrip> attendance = new List<StudentTrip>();

            string stringStopId = comboBoxStops.Text.Split(' ')[0];
            int stopId = int.Parse(stringStopId);

            string stringTripId = comboBoxRoutes.Text.Split(' ')[2];
            int tripId = int.Parse(stringTripId);

            
            foreach (Panel attendCard in studentsAttendancePanel.Controls.OfType<Panel>())
            {
                int studentId = (int)attendCard.Tag;

                string status = GetAttendanceStatus(attendCard);

                if(status == null)
                {
                    MessageBox.Show("Please mark all student's attendance.");
                    return;
                }

                StudentTrip trip = new StudentTrip
                {
                    _tripId = tripId,
                    _studentId = studentId,
                    _stopId = stopId,
                    _status = status
                };

                if (status == "PickUp")
                {
                    trip._pickUpTime = DateTime.Now;
                    trip._dropOffTime = null;
                }
                else if (status == "DropOff")
                {
                    trip._pickUpTime = null;
                    trip._dropOffTime = DateTime.Now;
                }
                else if (status == "Absent")
                {
                    trip._pickUpTime = null;
                    trip._dropOffTime = null;
                }

                attendance.Add(trip);
            }

            bool success = true;

            foreach (var attend in attendance)
            {
                if (!db.InsertStudentAttendance(attend))
                {
                    success = false;
                    break;
                }
            }

            MessageBox.Show(success
                ? "Attendance recorded!"
                : "Error saving attendance.");

        }

        //Once one of the check boxes is checked, this method is called to update the card
        private void UpdateAttendanceCardState(Panel attendCard, CheckBox cbPickUp, CheckBox cbDropOff, CheckBox cbAbsent)
        {
            if (cbPickUp.Checked)
            {
                attendCard.BackColor = Color.LightGreen;
                cbDropOff.Enabled = false;
                cbAbsent.Enabled = false;
            }
            else if (cbDropOff.Checked)
            {
                attendCard.BackColor = Color.LightGray;
                cbPickUp.Enabled = false;
                cbAbsent.Enabled = false;
            }
            else if (cbAbsent.Checked)
            {
                attendCard.BackColor = Color.Salmon;
                cbPickUp.Enabled = false;
                cbDropOff.Enabled = false;
            }
            else
            {
                attendCard.BackColor = Color.AliceBlue;
                cbPickUp.Enabled = true;
                cbDropOff.Enabled = true;
                cbAbsent.Enabled = true;
            }
        }

    }
}
