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
    //This form is a dialog form to add Routes - Patricia
    public partial class FormAddRoute : Form
    {

        SchoolRepository schoolRepository;
        DriversRepository driversRepository;
        VehicleRepository vehicleRepository;
        RouteRepository routeRepository;
        MapsService service;

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
                lbl_error_address.Text = "Type an address!";
                lbl_error_address.ForeColor = Color.Red;
                return;
            }
            var result = await service.GetCoordinatesFromAddress(txt_address.Text);
            // Not found
            if (result == null || result.FormattedAddress == "Canada")
            {
                lbl_error_address.Text = "Address not found!";
                lbl_error_address.ForeColor = Color.Red;
                return;
            }

            lbl_error_address.Text = "";

            //Add STOP if address is found
            if (result != null)
            {
                var stop = new Stop();

                // use address from, not that it was typed
                stop.Address = result.FormattedAddress;
                stop.Latitude = result.Latitude;
                stop.Longitude = result.Longitude;
                txt_address.Clear();
                list_stops.Items.Add(stop);                
            }            
        }
        
        // Remove STOPS from list (only from list - not BD)
        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (list_stops.SelectedIndex >= 0)
            {
                list_stops.Items.RemoveAt(list_stops.SelectedIndex);
            }
            else
            {
                lbl_error_remove.Text = "Select an item to remove!";
                lbl_error_remove.ForeColor = Color.Red;
            }
        }

        //Save ROUTE and their STOPS (1..N)
        private void btn_save_Click(object sender, EventArgs e)
        {
            var route = new Route(); // 1 Route
            var stops = new List<Stop>(); // N Stops

            route.RouteNumber = txt_route_num.Text;
            route.Description = txt_description.Text;
            route.SchoolID = ((School)cb_school.SelectedItem).SchoolID; // save only SchoolID
            route.VehicleID = ((Vehicle)cb_vehicle.SelectedItem).VehicleID; // save only VehicleID
            route.DriverID = ((Models.Driver)cb_driver.SelectedItem).DriverID; // save only DriverID

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
