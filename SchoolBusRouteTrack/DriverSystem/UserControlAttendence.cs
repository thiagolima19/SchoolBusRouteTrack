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

        private Panel CreateAttendanceCard (Student student)
        {
            Panel attedCard = new Panel();
            attedCard.Width = 500;
            attedCard.Height = 30;
            attedCard.BackColor = Color.White;
            attedCard.BorderStyle = BorderStyle.FixedSingle;
            attedCard.Margin = new Padding(5);

            Label lblStudentName = new Label();
            lblStudentName.Text = student._name;
            lblStudentName.Font = new Font("Microsoft Sans Serif", 8);
            lblStudentName.Location = new Point(20, 9);
            lblStudentName.AutoSize = true;

            CheckBox cbPickUp = new CheckBox();
            cbPickUp.Text = "Picked up";
            cbPickUp.Font = new Font("Microsoft Sans Serif", 8);
            cbPickUp.Location = new Point(190, 7);

            CheckBox cbDropOff = new CheckBox();
            cbDropOff.Text = "Dropped Off";
            cbDropOff.Font = new Font("Microsoft Sans Serif", 8);
            cbDropOff.Location = new Point(295, 7);

            CheckBox cbAbsent = new CheckBox();
            cbAbsent.Text = "Absent";
            cbAbsent.Font = new Font("Microsoft Sans Serif", 8);
            cbAbsent.Location = new Point(408, 7);

            if (cbPickUp.Checked)
            {
                attedCard.BackColor = Color.Green;
                cbDropOff.Enabled = false;
                cbAbsent.Enabled = false;
            }

            else if (cbDropOff.Checked)
            {
                attedCard.BackColor = Color.LightGray;
                cbPickUp.Enabled = false;
                cbAbsent.Enabled = false;
            }

            else if(cbAbsent.Checked)
            {
                attedCard.BackColor = Color.Red;
                cbPickUp.Enabled = false;
                cbDropOff.Enabled = false;
            }
            
            return attedCard;
        }

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

        private void UserControlAttendence_Load(object sender, EventArgs e)
        {

        }

        private void buttonSaveAttendance_Click(object sender, EventArgs e)
        {

        }

        
    }
}
