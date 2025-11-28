using SchoolBusRouteTrack.AdministratorSystem;
using SchoolBusRouteTrack.Data;
using SchoolBusRouteTrack.DriverSystem;
using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

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

            // 2. Database Query Logic (REPLACES HARDCODED LOGIC)
            string query = "SELECT Role FROM [User] WHERE Username = @Username AND Password = @Password";

            SqlParameter[] parameters = new SqlParameter[]
            {
                //prevent SQL Injection attacks!
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };

            DBHelper db = new DBHelper();
            object roleResult = db.ExecuteScalar(query, parameters);

            if (roleResult != null)
            {
                string userRole = roleResult.ToString();

                if (userRole == "Admin")
                {
                    OpenDashboard(new FormAdminDashboard());
                }
                else if (userRole == "Driver")
                {
                    OpenDashboard(new FormDriverDashboard());
                }
                else
                {
                    MessageBox.Show("User role is invalid.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper method to handle closing Login and opening the new Dashboard
        private void OpenDashboard(Form dashboardForm)
        {
            this.Hide();

            DialogResult result = dashboardForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.Show();
                ClearLoginFields();
            }
            else
            {
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