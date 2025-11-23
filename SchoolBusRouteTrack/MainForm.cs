using SchoolBusRouteTrack.AdministratorSystem;
using SchoolBusRouteTrack.DriverSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolBusRouteTrack
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
      
            this.buttonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            // 1. Check for Empty Fields
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Hardcoded Logic for Roles
            // In the future, this part will be replaced by a Database Query
            if (username == "admin" && password == "admin123")
            {
                OpenDashboard(new FormAdminDashboard());
            }
            else if (username == "driver" && password == "driver123")
            {
                OpenDashboard(new FormDriverDashboard());
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper method to handle closing Login and opening the new Dashboard
        private void OpenDashboard(Form dashboardForm)
        {
            // Hide the login form
            this.Hide();

            dashboardForm.FormClosed += (s, args) => this.Close();
            dashboardForm.Show();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}