using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SchoolBusRouteTrack.AdministratorSystem
{
    public partial class UserControlStudentRegister : UserControl
    {
        private const string googleApiKey = "AIzaSyCArvLZgooiF9BKD-2WlIZPdtHhbnYcDno"; // Replace with your actual Google Maps API key
        private List<Control> formFields;
        private BindingList<Student> students = new BindingList<Student>()
        {
            new Student(1, "Alice Brown", new MapLocation(53.4806233,-113.349991, "123 Maple Way NW, Calgary",1), "5", "Mary Brown", "Mother", "555-1111", 101, "None"),
            new Student(2, "Bob Smith", new MapLocation(51.05011,-114.08529, "456 Oak St, Calgary, AB",2), "6", "John Smith", "Father", "555-2222", 102, "Allergy to peanuts"),
            new Student(3, "Charlie Johnson", new MapLocation (51.0912546,-114.2239332, "789 Pine St, Calgary, AB",3), "4", "Linda Johnson", "Guardian", "555-3333", 103, "Asthma")

        };


        public UserControlStudentRegister()
        {

            InitializeComponent();

            GetFormFields();

            InitializeGMap();

            LoadStudentsList();


        }

        private void LoadStudentsList()
        {
            listBoxStudents.DataSource = students;

            listBoxStudents.DisplayMember = "_name";
            listBoxStudents.ValueMember = "_studentID";

            listBoxStudents.SelectedIndex = -1;

            listBoxStudents.SelectedIndexChanged += ListBoxStudents_SelectedIndexChanged;
        }

        private void ListBoxStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            Student selectedStudent = (Student)listBoxStudents.SelectedItem;

            if (selectedStudent!=null)
            {
                textBoxName.Text = selectedStudent._name;
                textBoxAddress.Text = selectedStudent._address.FullAddress;
                textBoxGrade.Text = selectedStudent._grade;
                textBoxGuardianName.Text = selectedStudent._guardianName;
                textBoxPhone.Text = selectedStudent._guardianPhone;
                textBoxRelationship.Text = selectedStudent._guardianRelationship;
                textBoxSchoolID.Text = selectedStudent._schoolID.ToString();
                textBoxSpecialCare.Text = selectedStudent._specialCare;

                DrawMarker(selectedStudent._address.Latitude, selectedStudent._address.Longitude);
                gMapControlStudent.Position = new PointLatLng(selectedStudent._address.Latitude, selectedStudent._address.Longitude);
                gMapControlStudent.Visible = true;
            }
        }
        private void GetFormFields ()
        {
            formFields = new List<Control> ();
            formFields.Add(textBoxName);
            formFields.Add(textBoxAddress);
            formFields.Add(textBoxGrade);
            formFields.Add(textBoxGuardianName);
            formFields.Add(textBoxPhone);
            formFields.Add(textBoxRelationship);
            formFields.Add(textBoxSchoolID);
            formFields.Add(textBoxSpecialCare);
 

        }

        private void InitializeGMap()
        {
            gMapControlStudent.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = AccessMode.ServerOnly;

            //zoom in and out and drag map
            gMapControlStudent.MinZoom = 4;
            gMapControlStudent.MaxZoom = 20;
            gMapControlStudent.Zoom = 13;
            gMapControlStudent.MouseWheelZoomType = MouseWheelZoomType.ViewCenter;
            gMapControlStudent.CanDragMap = false;
            gMapControlStudent.IgnoreMarkerOnMouseWheel = false;
            // remove red cross from the map
            gMapControlStudent.ShowCenter = false;

            // initial center position based on calgary's latitude and longitude
            gMapControlStudent.Position = new PointLatLng(51.0501, -114.08529);
            gMapControlStudent.Visible = false;
        }

        public async Task<Tuple<double, double>> GetCoordinatesFromAddress(string address)
        {
            string encodedAddress = Uri.EscapeDataString(address);
            string apiUrl = $"https://maps.googleapis.com/maps/api/geocode/json?address={encodedAddress}&key={googleApiKey}";

            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode(); // Throws an exception if the HTTP status is an error code

                string responseBody = await response.Content.ReadAsStringAsync();
                JObject jsonResponse = JObject.Parse(responseBody);

                if (jsonResponse["status"].ToString() == "OK")
                {
                    double latitude = (double)jsonResponse["results"][0]["geometry"]["location"]["lat"];
                    double longitude = (double)jsonResponse["results"][0]["geometry"]["location"]["lng"];
                    return Tuple.Create(latitude, longitude);
                }
                else
                {
                    // Handle error cases (e.g., address not found)
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error fetching coordinates: {ex.Message}");
                return null;
            }
        }


        private void DrawMarker(double lat, double lng)
        {
            gMapControlStudent.Overlays.Clear();

            GMarkerGoogle driverMarker = new GMarkerGoogle(
                new PointLatLng(lat, lng),
                GMarkerGoogleType.red_small
            );

            GMapOverlay driverOverlay = new GMapOverlay("student");
            driverOverlay.Markers.Add(driverMarker);

            gMapControlStudent.Overlays.Add(driverOverlay);
        }


        private void UserControlStudentRegister_Load(object sender, EventArgs e)
        {

        }

        private bool isFormValid()
        {
            bool isValid = true;          

            foreach (Control control in formFields) 
            {
                Control errorLabel = this.Controls.Find($"labelError{control.Tag}", true).FirstOrDefault();

                if (string.IsNullOrWhiteSpace(control.Text))
                {
                    isValid = false;

                    
                    if (errorLabel != null) 
                    { 
                        errorLabel.Text = $"{control.Tag} is required.";
                    }
                                      
                }
                else if (errorLabel != null)
                {
                    errorLabel.Text = "";
                }
                
            }

            return isValid;
        }

        private async void buttonStudentSave_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                var request = await GetCoordinatesFromAddress(textBoxAddress.Text);
                if (request != null)
                { 
                    double latitude = request.Item1;
                    double longitude = request.Item2;

                    int userID = students.Count + 1;
                    string studentName = textBoxName.Text;
                    MapLocation address = new MapLocation(latitude, longitude, textBoxAddress.Text, userID);
                    string grade = textBoxGrade.Text;
                    string guardianName = textBoxGuardianName.Text;
                    string phone = textBoxPhone.Text;
                    string relationship = textBoxRelationship.Text;
                    int schoolID = int.Parse(textBoxSchoolID.Text);
                    string specialCare = textBoxSpecialCare.Text;
                    
                    Student newStudent = new Student(userID, studentName, address, grade, guardianName, relationship, phone, schoolID, specialCare);

                    students.Add(newStudent);
                    listBoxStudents.SelectedIndex = -1;

                    clearForm();
                }
                else
                {                     
                    MessageBox.Show("Invalid address.");
                }

            }
            else
            { 
                MessageBox.Show("Please fill in all required fields!");
            }

        }

        private void clearForm()
        {
            textBoxName.Text = "";
            textBoxAddress.Text = "";
            textBoxGrade.Text = "";
            textBoxGuardianName.Text = "";
            textBoxPhone.Text = "";
            textBoxRelationship.Text = "";
            textBoxSchoolID.Text = "";
            textBoxSpecialCare.Text = "";
            gMapControlStudent.Overlays.Clear();
            gMapControlStudent.Visible = false;
            listBoxStudents.ClearSelected();

        }

        private void buttonStudentClear_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void textBoxSchoolID_TextChanged(object sender, EventArgs e)
        {

        }

        private void isNumericValue(KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void textBoxSchoolID_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumericValue(e);
        }

        private void textBoxStopID_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumericValue(e);
        }

        private async void  buttonSearchAddress_Click(object sender, EventArgs e)
        {
            var request = await GetCoordinatesFromAddress(textBoxAddress.Text);

            if (request != null)
            {
                double latitude = request.Item1;
                double longitude = request.Item2;
                DrawMarker(latitude, longitude);
                gMapControlStudent.Position = new PointLatLng(latitude, longitude);
                gMapControlStudent.Visible = true;
            }
        }

        private void ToggleSaveButtonState(bool enabled)
        {
            buttonStudentSave.Enabled = enabled;
        }
        private void HandleClickOutsideListBox(object sender, EventArgs e)
        {
            if (sender != null)
            {
                // Check if the click occurred outside the ListBox
                if (!listBoxStudents.Bounds.Contains(this.PointToClient(Cursor.Position)) && listBoxStudents.SelectedIndex >= 0)
                {
                    listBoxStudents.ClearSelected(); // Unselect all items in the ListBox
                    ToggleSaveButtonState(true);
                    clearForm();
                }
            }
        }
    }

}
