using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json.Linq;
using SchoolBusRouteTrack.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolBusRouteTrack.Models
{

    public partial class UserControlDriverRegister : UserControl
    {
        private const string googleApiKey = "AIzaSyCArvLZgooiF9BKD-2WlIZPdtHhbnYcDno";
        private List<Control> formFields;
        private BindingList<Driver> drivers;
        private List<Route> routes;
        private DriversRepository driverRepo = new DriversRepository();

        public UserControlDriverRegister()
        {
            InitializeComponent();

            GetFormFields();
            InitializeGMap();
            LoadDriversList();
            LoadRoutesComboBox();
            LoadVehiclesComboBox();
        }

        // Load routes into comboBox
        private void LoadRoutesComboBox()
        {
            try
            {
                routes = driverRepo.GetAllRoutes();
                comboBoxRoute.DataSource = null;
                comboBoxRoute.DataSource = routes;
                comboBoxRoute.DisplayMember = "RouteNumber";
                comboBoxRoute.ValueMember = "RouteID";
                comboBoxRoute.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading routes: {ex.Message}");
            }
        }
        private void LoadVehiclesComboBox()
        {
            try
            {
                var vehicles = driverRepo.GetAvailableVehicles();
                //include "None" option
                vehicles.Insert(0, new Vehicle { VehicleID = 0, Plate = "None", Type = "", Company = "" });

                comboBoxVehicle.DataSource = vehicles;
                comboBoxVehicle.DisplayMember = "Plate";
                comboBoxVehicle.ValueMember = "VehicleID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading vehicles: {ex.Message}");
            }
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
                comboBoxVehicle
            };
        }

        private void LoadDriversList()
        {
            var listFromDB = driverRepo.GetAllDrivers();
            drivers = new BindingList<Driver>(listFromDB);

            listBoxDriver.DataSource = drivers;
            listBoxDriver.DisplayMember = "Name";
            listBoxDriver.ValueMember = "DriverID";
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
            comboBoxVehicle.Text = "";
            comboBoxRoute.SelectedIndex = -1; // NEW: Clear route selection
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
                textBoxName.Text = selectedDriver.Name;
                textBoxPhone.Text = selectedDriver.Phone;
                comboBoxVehicle.Text = selectedDriver.AssignedVehicle;
                textBoxAddress.Text = selectedDriver.Address.FullAddress;

                if (routes != null && selectedDriver.DriverID > 0)
                {
                    var driverRoute = routes.FirstOrDefault(r =>
                        r.AssignedDriver?.Contains(selectedDriver.Name) == true);
                    if (driverRoute != null)
                    {
                        comboBoxRoute.SelectedValue = driverRoute.RouteID;
                    }
                    else
                    {
                        comboBoxRoute.SelectedIndex = -1;
                    }
                }

                DrawDriverMarker(selectedDriver.Address.Latitude, selectedDriver.Address.Longitude);
                gMapControlDriverAddress.Position = new PointLatLng(selectedDriver.Address.Latitude, selectedDriver.Address.Longitude);
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
            if (!isFormValid())
            {
                MessageBox.Show("Please correct the errors in the form.");
                return;
            }

            var coords = await GetCoordinatesFromAddress(textBoxAddress.Text);
            if (coords == null)
            {
                MessageBox.Show("Address not found.");
                return;
            }

            Driver newDriver = new Driver
            {
                Name = textBoxName.Text,
                Phone = textBoxPhone.Text,
                Status = "Active",
                AssignedVehicle = comboBoxVehicle.Text,
                Address = new MapLocation(coords.Item1, coords.Item2, textBoxAddress.Text)
            };

            bool success = driverRepo.InsertDriver(newDriver);

            if (!success)
            {
                MessageBox.Show("Error saving driver to database.");
                return;
            }


            if (comboBoxRoute.SelectedItem != null && comboBoxRoute.SelectedValue != null)
            {
                int routeId = (int)comboBoxRoute.SelectedValue;
                var allDrivers = driverRepo.GetAllDrivers();
                var latestDriver = allDrivers.LastOrDefault(d => d.Name == newDriver.Name && d.Phone == newDriver.Phone);

                if (latestDriver != null)
                {
                    bool routeAssigned = driverRepo.AssignDriverToRoute(routeId, latestDriver.DriverID);
                    if (routeAssigned)
                    {
                        if (!string.IsNullOrWhiteSpace(comboBoxVehicle.Text))
                        {
                            var vehicles = driverRepo.GetAvailableVehicles();
                            var selectedVehicle = vehicles.FirstOrDefault(v =>
                                v.Plate.Equals(comboBoxVehicle.Text, StringComparison.OrdinalIgnoreCase));

                            if (selectedVehicle != null)
                            {
                                driverRepo.AssignVehicleToRoute(routeId, selectedVehicle.VehicleID);
                            }
                            else
                            {
                                MessageBox.Show($"Vehicle with plate {comboBoxVehicle.Text} not found or not available.");
                            }
                        }
                    }
                }
            }

            MessageBox.Show("Driver added successfully!");

            LoadDriversList();
            LoadRoutesComboBox();
            ClearForm();
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

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (listBoxDriver.SelectedItem == null)
            {
                MessageBox.Show("Select a driver to edit.");
                return;
            }

            Driver selected = (Driver)listBoxDriver.SelectedItem;

            var coords = await GetCoordinatesFromAddress(textBoxAddress.Text);
            if (coords == null)
            {
                MessageBox.Show("Address not found.");
                return;
            }

            selected.Name = textBoxName.Text;
            selected.Phone = textBoxPhone.Text;
            selected.AssignedVehicle = comboBoxVehicle.Text;
            selected.Address = new MapLocation(coords.Item1, coords.Item2, textBoxAddress.Text);

            // Update driver info
            if (!driverRepo.UpdateDriver(selected))
            {
                MessageBox.Show("Error updating driver.");
                return;
            }

            if (comboBoxRoute.SelectedItem != null && comboBoxRoute.SelectedValue != null)
            {
                int routeId = (int)comboBoxRoute.SelectedValue;
                bool routeAssigned = driverRepo.AssignDriverToRoute(routeId, selected.DriverID);

                if (routeAssigned && !string.IsNullOrWhiteSpace(comboBoxVehicle.Text))
                {
                    var vehicles = driverRepo.GetAvailableVehicles();
                    var selectedVehicle = vehicles.FirstOrDefault(v =>
                        v.Plate.Equals(comboBoxVehicle.Text, StringComparison.OrdinalIgnoreCase));

                    if (selectedVehicle != null)
                    {
                        driverRepo.AssignVehicleToRoute(routeId, selectedVehicle.VehicleID);
                    }
                }
            }

            MessageBox.Show("Driver updated successfully!");
            LoadDriversList();
            LoadRoutesComboBox();
            ClearForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxDriver.SelectedItem == null)
            {
                MessageBox.Show("Select a driver to delete.");
                return;
            }

            Driver selected = (Driver)listBoxDriver.SelectedItem;

            if (!driverRepo.DeleteDriver(selected.DriverID))
            {
                MessageBox.Show("Error deleting driver.");
                return;
            }

            MessageBox.Show("Driver deleted!");

            LoadDriversList();
            ClearForm();
        }
    }

}