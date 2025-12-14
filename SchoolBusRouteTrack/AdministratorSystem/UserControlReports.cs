using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SchoolBusRouteTrack.Reports;
using System.IO;
using System.Collections.Generic;

namespace SchoolBusRouteTrack.AdministratorSystem
{
    public partial class UserControlReports : UserControl
    {
        private ReportRepository _reportRepo = new ReportRepository();

        public UserControlReports()
        {
            InitializeComponent();

            labelReportsTitle.Text = "To generate a report, please select an option.";
        }

        /// <summary>
        /// Simple dialog to select a Route and, optionally, a Date, created purely in code.
        /// </summary>
        private class ReportParameterDialog : Form
        {
            public int SelectedRouteID { get; private set; }
            public DateTime SelectedDate { get; private set; }
            private bool _requireDate;

            private class RouteListItem
            {
                public int RouteID { get; set; }
                public string Display { get; set; }
                public override string ToString() => Display;
            }

            public ReportParameterDialog(string title, bool requireDate, List<(int id, string number, string description)> routes)
            {
                _requireDate = requireDate;
                this.Text = title;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.StartPosition = FormStartPosition.CenterParent;
                this.Size = new Size(300, requireDate ? 250 : 180);

                int y = 10;

                // Route Selection
                Label lblRoute = new Label() { Left = 20, Top = y, Width = 250, Text = "Select Route:" };
                this.Controls.Add(lblRoute);
                y += 25;

                ComboBox cmbRoute = new ComboBox() { Left = 20, Top = y, Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };

                foreach (var route in routes)
                {
                    cmbRoute.Items.Add(new RouteListItem { RouteID = route.id, Display = $"{route.number} - {route.description}" });
                }

                if (cmbRoute.Items.Count > 0)
                    cmbRoute.SelectedIndex = 0;

                this.Controls.Add(cmbRoute);
                y += 40;

                // Date Selection (if required)
                DateTimePicker dtpDate = null;
                if (requireDate)
                {
                    Label lblDate = new Label() { Left = 20, Top = y, Width = 250, Text = "Date Selection:" };
                    this.Controls.Add(lblDate);
                    y += 25;

                    dtpDate = new DateTimePicker() { Left = 20, Top = y, Width = 250, Value = DateTime.Today };
                    this.Controls.Add(dtpDate);
                    y += 40;
                }

                // Buttons
                Button btnOk = new Button() { Text = "Generate Report", Left = 20, Width = 120, Top = y, DialogResult = DialogResult.OK };
                Button btnCancel = new Button() { Text = "Cancel", Left = 150, Width = 120, Top = y, DialogResult = DialogResult.Cancel };

                btnOk.Click += (sender, e) =>
                {
                    if (cmbRoute.SelectedItem == null)
                    {
                        MessageBox.Show("Please select a route.", "Invalid selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.DialogResult = DialogResult.None;
                        return;
                    }

                    this.SelectedRouteID = ((RouteListItem)cmbRoute.SelectedItem).RouteID;
                    if (_requireDate)
                    {
                        this.SelectedDate = dtpDate.Value.Date;
                    }
                    else
                    {
                        this.SelectedDate = DateTime.MinValue;
                    }
                };

                this.Controls.Add(btnOk);
                this.Controls.Add(btnCancel);
                this.AcceptButton = btnOk;
                this.CancelButton = btnCancel;
            }
        }

        private void buttonGenerateDailyReport_Click(object sender, EventArgs e)
        {
            ShowReportDialog(true, "Generate Daily Report");
        }

        private void buttonGenerateTripSummary_Click(object sender, EventArgs e)
        {
            ShowReportDialog(false, "Generate Trip Summary");
        }

        private void ShowReportDialog(bool requiresDate, string dialogTitle)
        {
            try
            {
                var routes = _reportRepo.GetRouteList();
                if (routes == null || routes.Count == 0)
                {
                    MessageBox.Show("Could not load routes for selection. Please check the connection and the database.", "Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var selectionDialog = new ReportParameterDialog(dialogTitle, requiresDate, routes))
                {
                    if (selectionDialog.ShowDialog() == DialogResult.OK)
                    {
                        int routeID = selectionDialog.SelectedRouteID;

                        if (requiresDate)
                        {
                            GenerateDailyReport(routeID, selectionDialog.SelectedDate);
                        }
                        else
                        {
                            GenerateTripSummary(routeID);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while preparing the selection: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateDailyReport(int routeID, DateTime selectedDate)
        {
            try
            {
                DataTable reportData = _reportRepo.GetDailyRouteAttendance(routeID, selectedDate);

                if (reportData.Rows.Count > 0)
                {
                    dataGridViewReports.DataSource = reportData;
                    labelReportsTitle.Text = $"Daily Attendance Report for Route ID {routeID} on {selectedDate.ToShortDateString()}";
                }
                else
                {
                    dataGridViewReports.DataSource = null;
                    labelReportsTitle.Text = $"Daily Attendance Report (Empty) for Route ID {routeID} on {selectedDate.ToShortDateString()}";
                    MessageBox.Show("No attendance records found for the selected route and date.", "Empty Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to generate the daily report: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateTripSummary(int routeID)
        {
            try
            {
                DataTable reportData = _reportRepo.GetRouteTripSummary(routeID);

                if (reportData.Rows.Count > 0)
                {
                    dataGridViewReports.DataSource = reportData;
                    labelReportsTitle.Text = $"Trip Summary Report for Route ID {routeID}";
                }
                else
                {
                    dataGridViewReports.DataSource = null;
                    labelReportsTitle.Text = $"Trip Summary Report (Empty) for Route ID {routeID}";
                    MessageBox.Show("No trips found to generate a summary for this route.", "Empty Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to generate the trip summary: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonExportCSV_Click(object sender, EventArgs e)
        {
            if (dataGridViewReports.Rows.Count == 0 || dataGridViewReports.DataSource == null)
            {
                MessageBox.Show("There is no data to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV file (*.csv)|*.csv";
                sfd.FileName = "ReportExport_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportToCsv(dataGridViewReports, sfd.FileName);
                        MessageBox.Show("Data successfully exported to CSV.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error during export: {ex.Message}", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExportToCsv(DataGridView dgv, string filePath)
        {
            StringBuilder sb = new StringBuilder();

            // Get Column Headers
            string header = string.Join(",", dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible).Select(c => $"\"{c.HeaderText}\""));
            sb.AppendLine(header);

            // Get Rows
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                string line = string.Join(",", row.Cells.Cast<DataGridViewCell>().Where(c => dgv.Columns[c.ColumnIndex].Visible).Select(c => $"\"{c.Value?.ToString().Replace("\"", "\"\"")}\""));
                sb.AppendLine(line);
            }

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }
    }
}