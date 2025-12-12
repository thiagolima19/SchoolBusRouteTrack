namespace SchoolBusRouteTrack.DriverSystem
{
    partial class FormDriverDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelContentDriverDashboard = new System.Windows.Forms.Panel();
            this.flowLayoutPanelSideBarDriver = new System.Windows.Forms.Panel();
            this.buttonTrip = new System.Windows.Forms.Button();
            this.buttonRoute = new System.Windows.Forms.Button();
            this.btn_attendance = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.flowLayoutPanelSideBarDriver.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContentDriverDashboard
            // 
            this.panelContentDriverDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContentDriverDashboard.Location = new System.Drawing.Point(196, 0);
            this.panelContentDriverDashboard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelContentDriverDashboard.Name = "panelContentDriverDashboard";
            this.panelContentDriverDashboard.Size = new System.Drawing.Size(871, 576);
            this.panelContentDriverDashboard.TabIndex = 0;
            // 
            // flowLayoutPanelSideBarDriver
            // 
            this.flowLayoutPanelSideBarDriver.Controls.Add(this.buttonTrip);
            this.flowLayoutPanelSideBarDriver.Controls.Add(this.buttonRoute);
            this.flowLayoutPanelSideBarDriver.Controls.Add(this.btn_attendance);
            this.flowLayoutPanelSideBarDriver.Controls.Add(this.buttonLogout);
            this.flowLayoutPanelSideBarDriver.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanelSideBarDriver.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelSideBarDriver.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanelSideBarDriver.Name = "flowLayoutPanelSideBarDriver";
            this.flowLayoutPanelSideBarDriver.Size = new System.Drawing.Size(196, 576);
            this.flowLayoutPanelSideBarDriver.TabIndex = 1;
            // 
            // buttonTrip
            // 
            this.buttonTrip.Location = new System.Drawing.Point(3, 2);
            this.buttonTrip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTrip.Name = "buttonTrip";
            this.buttonTrip.Size = new System.Drawing.Size(190, 48);
            this.buttonTrip.TabIndex = 0;
            this.buttonTrip.Text = "Trip";
            this.buttonTrip.UseVisualStyleBackColor = true;
            this.buttonTrip.Click += new System.EventHandler(this.buttonTrip_Click);
            // 
            // buttonRoute
            // 
            this.buttonRoute.Location = new System.Drawing.Point(3, 55);
            this.buttonRoute.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRoute.Name = "buttonRoute";
            this.buttonRoute.Size = new System.Drawing.Size(190, 48);
            this.buttonRoute.TabIndex = 1;
            this.buttonRoute.Text = "Route";
            this.buttonRoute.UseVisualStyleBackColor = true;
            this.buttonRoute.Click += new System.EventHandler(this.buttonRoute_Click);
            // 
            // btn_attendance
            // 
            this.btn_attendance.Location = new System.Drawing.Point(3, 108);
            this.btn_attendance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_attendance.Name = "btn_attendance";
            this.btn_attendance.Size = new System.Drawing.Size(190, 48);
            this.btn_attendance.TabIndex = 2;
            this.btn_attendance.Text = "Attendance";
            this.btn_attendance.UseVisualStyleBackColor = true;
            this.btn_attendance.Click += new System.EventHandler(this.btn_attendance_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLogout.Location = new System.Drawing.Point(3, 526);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(190, 48);
            this.buttonLogout.TabIndex = 3;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // FormDriverDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 576);
            this.Controls.Add(this.panelContentDriverDashboard);
            this.Controls.Add(this.flowLayoutPanelSideBarDriver);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(912, 488);
            this.Name = "FormDriverDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Driver Dashboard";
            this.flowLayoutPanelSideBarDriver.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContentDriverDashboard;
        private System.Windows.Forms.Panel flowLayoutPanelSideBarDriver;
        private System.Windows.Forms.Button buttonTrip;
        private System.Windows.Forms.Button buttonRoute;
        private System.Windows.Forms.Button btn_attendance;
        private System.Windows.Forms.Button buttonLogout;
    }
}