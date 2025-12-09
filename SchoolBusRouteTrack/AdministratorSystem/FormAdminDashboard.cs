using SchoolBusRouteTrack.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolBusRouteTrack.AdministratorSystem
{
    public partial class FormAdminDashboard : Form
    {
        public FormAdminDashboard()
        {
            InitializeComponent();

            this.buttonStudentRegister.Click += new EventHandler(buttonStudentRegister_Click);
            this.buttonRouteView.Click += new EventHandler(buttonRouteView_Click);
            this.buttonReports.Click += new EventHandler(buttonReports_Click); 
            this.buttonLogout.Click += new EventHandler(buttonLogout_Click);
            this.buttonDriverRegister.Click += new EventHandler(buttonDriverRegister_Click);
        }

        // --- THE HELPER METHOD ---
        // This method removes whatever is currently in the panel 
        // and replaces it with the new UserControl you pass to it.
        private void LoadContent(UserControl userControl)
        {
            // 1. Clear existing controls (remove the previous screen)
            panelContentAdminDashboard.Controls.Clear();

            // 2. Set the new control to fill the entire panel space
            userControl.Dock = DockStyle.Fill;

            // 3. Add the new control to the panel
            panelContentAdminDashboard.Controls.Add(userControl);

            // 4. Bring it to the front to ensure it's visible
            userControl.BringToFront();
        }

        private void buttonStudentRegister_Click(object sender, EventArgs e)
        {
            // Opens the Student Registration screen
            UserControlStudentRegister UCStudentRegister = new UserControlStudentRegister();
            LoadContent(UCStudentRegister);
        }

        private void buttonRouteView_Click(object sender, EventArgs e)
        {
            UserControlRouteView UCRoute = new UserControlRouteView();
            LoadContent(UCRoute);
        }

        private void buttonReports_Click(object sender, EventArgs e)
        {
            UserControlReports UCReports = new UserControlReports();
            LoadContent(UCReports);
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void buttonDriverRegister_Click(object sender, EventArgs e)
        {
            UserControlDriverRegister UCDriverRegister = new UserControlDriverRegister();
            LoadContent(UCDriverRegister);
        }
    }
}
