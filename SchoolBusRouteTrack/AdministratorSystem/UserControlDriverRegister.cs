using GMap.NET.WindowsForms;
using GMap.NET;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.WindowsForms.Markers;
using System.ComponentModel;

namespace SchoolBusRouteTrack.AdministratorSystem
{

    public partial class UserControlDriverRegister : UserControl
    {
        private const string googleApiKey = "AIzaSyCArvLZgooiF9BKD-2WlIZPdtHhbnYcDno"; // Replace with your actual Google Maps API key
        private List<Control> formFields;
        private BindingList<Driver> drivers = new BindingList<Driver>()
        {
            new Driver(1, "John Doe", new MapLocation(51.0296064, -114.0883456, "1128 Frontenac Avenue SW, Calgary, AB T2T, Canada", 1), "555-1234", "Vehicle 1"),
            new Driver(2, "Jane Smith", new MapLocation(50.8751408,-113.9520514, "Main Street SE, Calgary, AB T3M, Canada", 2), "555-5678", "Vehicle 2"),
            new Driver(3, "Mike Johnson", new MapLocation(51.0912546,-114.2239332, "Pine Street NW, Calgary, AB T3B, Canada", 3), "555-9012", "Vehicle 3")
        };

        public UserControlDriverRegister()
        {
            InitializeComponent();

            GetFormFields();

            InitializeGMap();

            LoadDriversList();
        }

        private void InitializeGMap()
        {
            gMapControlDriverAddress.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = AccessMode.ServerOnly;

            //zoom in and out and drag map
            gMapControlDriverAddress.MinZoom = 4;
            gMapControlDriverAddress.MaxZoom = 20;
            gMapControlDriverAddress.Zoom = 13;
            gMapControlDriverAddress.MouseWheelZoomType = MouseWheelZoomType.ViewCenter;
            gMapControlDriverAddress.CanDragMap = false;
            gMapControlDriverAddress.IgnoreMarkerOnMouseWheel = false;
            // remove red cross from the map
            gMapControlDriverAddress.ShowCenter = false;

            // initial center position based on calgary's latitude and longitude
            gMapControlDriverAddress.Position = new PointLatLng(51.0501, -114.08529);
            gMapControlDriverAddress.Visible = false;
        }
        private void GetFormFields()
        {
            formFields = new List<Control>
            {
                textBoxName,
                textBoxAddress,
                textBoxPhone,
                textBoxAssignedVehicle
            };

        }


        private void LoadDriversList()
        {
            listBoxDriver.DataSource = drivers;

            listBoxDriver.DisplayMember = "_name";
            listBoxDriver.ValueMember = "_driverID";

            listBoxDriver.SelectedIndex = -1;

            listBoxDriver.SelectedIndexChanged += ListBoxDriver_SelectedIndexChanged;
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

        private void ClearForm()
        {
            textBoxName.Text = "";
            textBoxAddress.Text = "";
            textBoxPhone.Text = "";
            textBoxAssignedVehicle.Text = "";
            gMapControlDriverAddress.Overlays.Clear();
            gMapControlDriverAddress.Visible = false;
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


        private void DrawDriverMarker(double lat, double lng)
        {
            gMapControlDriverAddress.Overlays.Clear();

            GMarkerGoogle driverMarker = new GMarkerGoogle(
                new PointLatLng(lat, lng),
                GMarkerGoogleType.red_small
            );

            GMapOverlay driverOverlay = new GMapOverlay("driver");
            driverOverlay.Markers.Add(driverMarker);

            gMapControlDriverAddress.Overlays.Add(driverOverlay);
        }

        private void ListBoxDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            Driver selectedDriver = (Driver)listBoxDriver.SelectedItem;

            if (selectedDriver != null)
            {
                ToggleSaveButtonState(false);
                textBoxName.Text = selectedDriver._name;
                textBoxPhone.Text = selectedDriver._phoneNumber;
                textBoxAssignedVehicle.Text = selectedDriver._assignedVehicle;


                textBoxAddress.Text = selectedDriver._address.FullAddress;

                DrawDriverMarker(selectedDriver._address.Latitude, selectedDriver._address.Longitude);
                gMapControlDriverAddress.Position = new PointLatLng(selectedDriver._address.Latitude, selectedDriver._address.Longitude);
                gMapControlDriverAddress.Visible = true;
            }
        }

        private async void ButtonAddressSearch_Click(object sender, EventArgs e)
        {
            var request = await GetCoordinatesFromAddress(textBoxAddress.Text);

            if (request != null)
            {
                gMapControlDriverAddress.Position = new PointLatLng(request.Item1, request.Item2);
                DrawDriverMarker(request.Item1, request.Item2);
                gMapControlDriverAddress.Visible = true;
            }
        }

        private async void ButtonDriverSave_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                string name = textBoxName.Text;
                string phoneNumber = textBoxPhone.Text;
                string assignedVehicle = textBoxAssignedVehicle.Text;

                MapLocation address = new MapLocation(0, 0, "", 0); // Placeholder for address coordinates
                var userCoordinates = await GetCoordinatesFromAddress(textBoxAddress.Text);
                if (userCoordinates != null)
                {
                    address = new MapLocation(userCoordinates.Item1, userCoordinates.Item2, textBoxAddress.Text, drivers.Count + 1);
                }

                Driver newDriver = new Driver(drivers.Count + 1, name, address, phoneNumber, assignedVehicle);

                drivers.Add(newDriver);

                listBoxDriver.SelectedIndex = -1;

                ClearForm();
            }
            else
            {
                MessageBox.Show("Please correct the errors in the form.", "Form Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonDriverClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ToggleSaveButtonState(bool shouldEnableButton)
        {
            buttonDriverSave.Enabled = shouldEnableButton;
        }

        private void HandleClickOutsideListBox(object sender, EventArgs e)
        {
            if (sender != null)
            {
                // Check if the click occurred outside the ListBox
                if (!listBoxDriver.Bounds.Contains(this.PointToClient(Cursor.Position)) && listBoxDriver.SelectedIndex >= 0)
                {
                    listBoxDriver.ClearSelected(); // Unselect all items in the ListBox
                    ToggleSaveButtonState(true);
                    ClearForm();
                }
            }
        }

        private void UserControlDriverRegister_Load(object sender, EventArgs e)
        {

        }
    }

}
