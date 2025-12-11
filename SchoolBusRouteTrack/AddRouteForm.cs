using GMap.NET;
using SchoolBusRouteTrack.Data;
using SchoolBusRouteTrack.Models;
using SchoolBusRouteTrack.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SchoolBusRouteTrack
{
    //This form is a dialog form to add/edit Routes - Patricia
    public partial class FormAddRoute : Form
    {

        SchoolRepository schoolRepository;
        DriversRepository driversRepository;
        VehicleRepository vehicleRepository;
        RouteRepository routeRepository;
        MapsService service;

        // For edit mode
        private int? _editingRouteId = null;
        private Data.Route _editingRoute = null;

        // Constructor for ADD mode
        public FormAddRoute()
        {
            InitializeComponent();
            // objects frm classes below regarding tables SCHOOL, DRIVERS, VEHICLE, ROUTE, ROUTESTOP, STOP
            schoolRepository  = new SchoolRepository();
            driversRepository = new DriversRepository();
            vehicleRepository = new VehicleRepository();
            routeRepository   = new RouteRepository(); //ROUTE, ROUTESTOP, STOP
            service = new MapsService();
        }

        // Constructor for EDIT mode
        public FormAddRoute(int routeId) : this()
        {
            _editingRouteId = routeId;
        }

        private void AddRouteForm_Load(object sender, EventArgs e)
        {
            load(); // load all information from DB (different tables)
        }

        private void load()
        {
            var schools = loadSchools(); // select * from table SCHOOLS and load combobox
            foreach (School school in schools)
            {
                cb_school.Items.Add(school);
            }
            cb_school.DisplayMember = "Name";

            var drivers = loadDrivers(); // select * from table DRIVERS and load combobox
            foreach (Models.Driver driver in drivers)
            {
                cb_driver.Items.Add(driver);
            }
            cb_driver.DisplayMember = "FullName";

            var vehicles = loadVehicle(); // select * from table VEHICLES and load combobox
            foreach (Models.Vehicle vehicle in vehicles)
            {
                cb_vehicle.Items.Add(vehicle);
            }
            cb_vehicle.DisplayMember = "Plate";

            // If editing, load the route data
            if (_editingRouteId.HasValue)
            {
                LoadRouteForEditing(_editingRouteId.Value);
            }
        }

        // Load route data for editing
        private void LoadRouteForEditing(int routeId)
        {
            _editingRoute = routeRepository.GetRouteById(routeId);
            if (_editingRoute == null)
            {
                MessageBox.Show("Route not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Change form title
            this.Text = "Edit Route";

            // Fill form fields
            txt_route_num.Text = _editingRoute.RouteNumber;
            txt_description.Text = _editingRoute.Description;

            // Select School in combobox
            for (int i = 0; i < cb_school.Items.Count; i++)
            {
                if (((School)cb_school.Items[i]).SchoolID == _editingRoute.SchoolID)
                {
                    cb_school.SelectedIndex = i;
                    break;
                }
            }

            // Select Driver in combobox
            if (_editingRoute.DriverID.HasValue)
            {
                for (int i = 0; i < cb_driver.Items.Count; i++)
                {
                    if (((Models.Driver)cb_driver.Items[i]).DriverID == _editingRoute.DriverID.Value)
                    {
                        cb_driver.SelectedIndex = i;
                        break;
                    }
                }
            }

            // Select Vehicle in combobox
            if (_editingRoute.VehicleID.HasValue)
            {
                for (int i = 0; i < cb_vehicle.Items.Count; i++)
                {
                    if (((Models.Vehicle)cb_vehicle.Items[i]).VehicleID == _editingRoute.VehicleID.Value)
                    {
                        cb_vehicle.SelectedIndex = i;
                        break;
                    }
                }
            }

            // Load stops
            var stops = routeRepository.GetStopsByRouteId(routeId);
            foreach (var stop in stops)
            {
                list_stops.Items.Add(stop);
            }
        }

        private List<School> loadSchools()
        {
            var data = schoolRepository.GetSchools();
            return School.FromDataTable(data);
        }
        private List<Models.Driver> loadDrivers()
        {
            var data = driversRepository.GetDrivers();
            return Models.Driver.FromDataTable(data);
        }
        private List<Models.Vehicle> loadVehicle()
        {
            var data = vehicleRepository.GetVehicle();
            return Models.Vehicle.FromDataTable(data);
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            int i = list_stops.SelectedIndex;
            if (i > 0)
            {
                var item = list_stops.Items[i];
                list_stops.Items.RemoveAt(i);
                list_stops.Items.Insert(i - 1, item);
                list_stops.SelectedIndex = i - 1;
            }
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            int i = list_stops.SelectedIndex;
            if (i >= 0 && i < list_stops.Items.Count - 1)
            {
                var item = list_stops.Items[i];
                list_stops.Items.RemoveAt(i);
                list_stops.Items.Insert(i + 1, item);
                list_stops.SelectedIndex = i + 1;
            }
        }
        private async void btn_add_Click(object sender, EventArgs e)
        {
            // validate entry
            if (string.IsNullOrWhiteSpace(txt_address.Text))
            {
                label_erro_endereco.Text = "Type an address!";
                label_erro_endereco.ForeColor = Color.Red;
                return;
            }

            var result = await service.GetCoordinatesFromAddress(txt_address.Text);

            if (result != null)
            {
                var stop = new Stop();

                // 👉 usa o endereço vindo do Google, NÃO o que foi digitado
                stop.Address = result.FormattedAddress;
                stop.Latitude = result.Latitude;
                stop.Longitude = result.Longitude;

                label_erro_endereco.Text = "";

                // se quiser, já atualiza o TextBox também:
                txt_address.Text = result.FormattedAddress;

                list_stops.Items.Add(stop);
                // list_stops.Tag = stop;  // isso aqui geralmente não precisa,
                // Tag é do controle, não de cada item
            }
            else
            {
                label_erro_endereco.Text = "Address not found";
                label_erro_endereco.ForeColor = Color.Red;
            }
        }

        //Add address ONLY after search and confirm the existence of it - Patricia
        /*     private async void btn_add_Click(object sender, EventArgs e)
             {
                 // validate entry
                 if (string.IsNullOrWhiteSpace(txt_address.Text))
                 {
                     label_erro_endereco.Text = "Type an address!";
                     label_erro_endereco.ForeColor = Color.Red;
                     return;
                 }

                 var request = await service.GetCoordinatesFromAddress(txt_address.Text);

                 if (request != null)
                 {
                     var stop = new Stop();
                     stop.Address = txt_address.Text;
                     stop.Latitude = request.Item1;
                     stop.Longitude = request.Item2;
                     label_erro_endereco.Text = "";

                     list_stops.Items.Add(stop);
                     list_stops.Tag = stop;
                 }
                 else
                 {
                     label_erro_endereco.Text = "Address not found";
                     label_erro_endereco.ForeColor = Color.Red;
                 }
             }*/
        //private async void btn_add_Click(object sender, EventArgs e)
        //{
        //    label_erro_endereco.Text = "";

        //    if (string.IsNullOrWhiteSpace(txt_address.Text))
        //    {
        //        label_erro_endereco.Text = "Type an address!";
        //        label_erro_endereco.ForeColor = Color.Red;
        //        return;
        //    }

        //    btn_add.Enabled = false;
        //    try
        //    {
        //        var service = new MapsService();
        //        var result = await service.GetCoordinatesFromAddress(txt_address.Text.Trim()); // GeocodeResult

        //        if (result == null || !result.Success)
        //        {
        //            label_erro_endereco.Text = result?.ErrorMessage ?? "Address not found";
        //            label_erro_endereco.ForeColor = Color.Red;
        //            return;
        //        }

        //        var stop = new Stop
        //        {
        //            Address = string.IsNullOrWhiteSpace(result.FormattedAddress) ? txt_address.Text.Trim() : result.FormattedAddress,
        //            Latitude = result.Latitude,
        //            Longitude = result.Longitude
        //        };

        //        list_stops.Items.Add(stop);
        //        list_stops.SelectedIndex = list_stops.Items.Count - 1;
        //        txt_address.Clear();
        //        label_erro_endereco.Text = "";
        //    }
        //    catch (Exception ex)
        //    {
        //        label_erro_endereco.Text = "Error: " + ex.Message;
        //        label_erro_endereco.ForeColor = Color.Red;
        //    }
        //    finally
        //    {
        //        btn_add.Enabled = true;
        //    }
        //}







        /// <summary>
        /// // Remove STOPS from list (only screen)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (list_stops.SelectedIndex >= 0)
            {
                list_stops.Items.RemoveAt(list_stops.SelectedIndex);
            }
            else
            {
                lbl_error.Text = "Select an item to remove!";
                lbl_error.ForeColor = Color.Red;
            }
        }

        //Save ROUTE and their STOPS (1..N)
        private void btn_save_Click(object sender, EventArgs e)
        {
            // Validate all required fields
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(txt_route_num.Text))
                errors.Add("Route Number");

            if (cb_school.SelectedItem == null)
                errors.Add("School");

            if (cb_driver.SelectedItem == null)
                errors.Add("Driver");

            if (cb_vehicle.SelectedItem == null)
                errors.Add("Vehicle");

            if (list_stops.Items.Count == 0)
                errors.Add("At least one Stop");

            if (errors.Count > 0)
            {
                MessageBox.Show(
                    "Please fill in all required fields:\n\n- " + string.Join("\n- ", errors),
                    "Required Fields",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Check if Route Number already exists
            int? excludeRouteId = _editingRoute?.RouteID;
            if (routeRepository.RouteNumberExists(txt_route_num.Text.Trim(), excludeRouteId))
            {
                MessageBox.Show(
                    $"Route Number '{txt_route_num.Text.Trim()}' already exists.\nPlease use a different number.",
                    "Duplicate Route Number",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var route = new Data.Route(); // 1 Route
            var stops = new List<Stop>(); // N Stops

            // If editing, use the existing RouteID
            if (_editingRoute != null)
            {
                route.RouteID = _editingRoute.RouteID;
            }

            route.RouteNumber = txt_route_num.Text;
            route.Description = txt_description.Text;
            route.SchoolID = ((School)cb_school.SelectedItem).SchoolID;
            route.VehicleID = ((Vehicle)cb_vehicle.SelectedItem).VehicleID;
            route.DriverID = ((Models.Driver)cb_driver.SelectedItem).DriverID;

            foreach (Stop stop in list_stops.Items)
            {
                stops.Add(stop);
            }

            routeRepository.SaveRouteWithStops(route, stops);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

           private async void txt_address_TextChanged(object sender, EventArgs e)
        {
            if (txt_address.Text.Length < 3)
                return;

            Console.WriteLine(txt_address.Text);
            var suggestions = await service.GetAddressListAsync(txt_address.Text);

            Console.WriteLine(string.Join("|", suggestions.ToString()));

            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            source.AddRange(suggestions.ToArray());

            txt_address.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_address.AutoCompleteSource = AutoCompleteSource.AllSystemSources;
            txt_address.AutoCompleteCustomSource = source;
        }
    }
}
