using SchoolBusRouteTrack.AdministratorSystem;
using SchoolBusRouteTrack.Data;
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
    public partial class FormDriverDashboard : Form
    {
        public FormDriverDashboard()
        {
            InitializeComponent();

            this.buttonTrip.Click += new EventHandler(buttonTrip_Click);
            this.buttonRoute.Click += new EventHandler(buttonRoute_Click);
            //   this.btn_attendance.Click += new EventHandler(ButtonAttendence_Click);
            this.btn_attendance.Click += new EventHandler(btn_attendance_Click);
            this.buttonLogout.Click += new EventHandler(buttonLogout_Click);
        }

        // --- THE HELPER METHOD ---
        // This method removes whatever is currently in the panel 
        // and replaces it with the new UserControl you pass to it.
        private void LoadContent(UserControl userControl)
        {
            // 1. Clear existing controls (remove the previous screen)
            panelContentDriverDashboard.Controls.Clear();

            // 2. Set the new control to fill the entire panel space
            userControl.Dock = DockStyle.Fill;

            // 3. Add the new control to the panel
            panelContentDriverDashboard.Controls.Add(userControl);

            // 4. Bring it to the front to ensure it's visible
            userControl.BringToFront();
        }

        private void buttonTrip_Click(object sender, EventArgs e)
        {
            // Pass the driver ID from CurrentUser
            int driverId = CurrentUser.DriverID ?? 0;
            if (driverId > 0)
            {
                UserControlTrip UCTrip = new UserControlTrip(driverId);
                LoadContent(UCTrip);
            }
            else
            {
                MessageBox.Show("Driver ID not found. Please contact administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRoute_Click(object sender, EventArgs e)
        {
            int driverId = CurrentUser.DriverID ?? 0;
            UserControlRoute UCRoute = new UserControlRoute(driverId);
            LoadContent(UCRoute);
        }

        
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void btn_attendance_Click(object sender, EventArgs e)
        {

        }
    }
}
