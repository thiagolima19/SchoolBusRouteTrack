using SchoolBusRouteTrack.AdministratorSystem;
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
            this.buttonAttendence.Click += new EventHandler(buttonAttendence_Click);
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
            UserControlTrip UCTrip = new UserControlTrip();
            LoadContent(UCTrip);
        }

        private void buttonRoute_Click(object sender, EventArgs e)
        {
            UserControlRoute UCRoute = new UserControlRoute();
            LoadContent(UCRoute);
        }

        private void buttonAttendence_Click(object sender, EventArgs e)
        {
            UserControlAttendence UCAttendence = new UserControlAttendence();
            LoadContent(UCAttendence);
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}
