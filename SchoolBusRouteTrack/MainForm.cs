using SchoolBusRouteTrack.AdministratorSystem;
using SchoolBusRouteTrack.Data;
using SchoolBusRouteTrack.DriverSystem;
using SchoolBusRouteTrack.UserModel;
using System;
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

            // 2. Validate login using the stored Procedure ValidateLoginSP
            DBHelper db = new DBHelper();
            LoginUser loggedInUser = db.ValidateLoginSP(username, password);
            // OR use the stored procedure version:
            // UserModel loggedInUser = db.ValidateLoginSP(username, password);

            if (loggedInUser != null)
            {
                // 3. Set the current user session
                CurrentUser.SetUser(
                    loggedInUser.UserID,
                    loggedInUser.Username,
                    loggedInUser.Role,
                    loggedInUser.DriverID
                );

                // 4. Open appropriate dashboard
                if (loggedInUser.Role == "Admin")
                {
                    OpenDashboard(new FormAdminDashboard());
                }
                else if (loggedInUser.Role == "Driver")
                {
                    OpenDashboard(new FormDriverDashboard());
                }
                else
                {
                    MessageBox.Show("User role is invalid.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CurrentUser.Clear();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OpenDashboard(Form dashboardForm)
        {
            this.Hide();

            DialogResult result = dashboardForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                // User logged out from dashboard
                CurrentUser.Clear(); // Clear the session
                this.Show();
                ClearLoginFields();
            }
            else
            {
                // User closed the application
                CurrentUser.Clear(); // Clear the session
                Application.Exit();
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ClearLoginFields()
        {
            textBoxUsername.Clear();
            textBoxPassword.Clear();

            textBoxUsername.Focus();
        }
    }
}