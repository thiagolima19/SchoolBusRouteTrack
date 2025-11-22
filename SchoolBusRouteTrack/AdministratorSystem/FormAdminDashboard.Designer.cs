namespace SchoolBusRouteTrack.AdministratorSystem
{
    partial class FormAdminDashboard
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
            this.panelContentAdminDashboard = new System.Windows.Forms.Panel();
            this.flowLayoutPanelSideBarAdmin = new System.Windows.Forms.Panel();
            this.buttonDriverRegister = new System.Windows.Forms.Button();
            this.buttonStudentRegister = new System.Windows.Forms.Button();
            this.buttonRouteView = new System.Windows.Forms.Button();
            this.buttonReports = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.flowLayoutPanelSideBarAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContentAdminDashboard
            // 
            this.panelContentAdminDashboard.AutoSize = true;
            this.panelContentAdminDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContentAdminDashboard.Location = new System.Drawing.Point(147, 0);
            this.panelContentAdminDashboard.Margin = new System.Windows.Forms.Padding(2);
            this.panelContentAdminDashboard.Name = "panelContentAdminDashboard";
            this.panelContentAdminDashboard.Size = new System.Drawing.Size(922, 645);
            this.panelContentAdminDashboard.TabIndex = 0;
            // 
            // flowLayoutPanelSideBarAdmin
            // 
            this.flowLayoutPanelSideBarAdmin.Controls.Add(this.buttonDriverRegister);
            this.flowLayoutPanelSideBarAdmin.Controls.Add(this.buttonStudentRegister);
            this.flowLayoutPanelSideBarAdmin.Controls.Add(this.buttonRouteView);
            this.flowLayoutPanelSideBarAdmin.Controls.Add(this.buttonReports);
            this.flowLayoutPanelSideBarAdmin.Controls.Add(this.buttonLogout);
            this.flowLayoutPanelSideBarAdmin.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanelSideBarAdmin.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelSideBarAdmin.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanelSideBarAdmin.Name = "flowLayoutPanelSideBarAdmin";
            this.flowLayoutPanelSideBarAdmin.Size = new System.Drawing.Size(147, 645);
            this.flowLayoutPanelSideBarAdmin.TabIndex = 1;
            // 
            // buttonDriverRegister
            // 
            this.buttonDriverRegister.Location = new System.Drawing.Point(0, 131);
            this.buttonDriverRegister.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDriverRegister.Name = "buttonDriverRegister";
            this.buttonDriverRegister.Size = new System.Drawing.Size(143, 39);
            this.buttonDriverRegister.TabIndex = 4;
            this.buttonDriverRegister.Text = "Driver Registration";
            this.buttonDriverRegister.UseVisualStyleBackColor = true;
            // 
            // buttonStudentRegister
            // 
            this.buttonStudentRegister.Location = new System.Drawing.Point(2, 2);
            this.buttonStudentRegister.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStudentRegister.Name = "buttonStudentRegister";
            this.buttonStudentRegister.Size = new System.Drawing.Size(143, 39);
            this.buttonStudentRegister.TabIndex = 0;
            this.buttonStudentRegister.Text = "Student Registration";
            this.buttonStudentRegister.UseVisualStyleBackColor = true;
            this.buttonStudentRegister.Click += new System.EventHandler(this.buttonStudentRegister_Click);
            // 
            // buttonRouteView
            // 
            this.buttonRouteView.Location = new System.Drawing.Point(2, 45);
            this.buttonRouteView.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRouteView.Name = "buttonRouteView";
            this.buttonRouteView.Size = new System.Drawing.Size(143, 39);
            this.buttonRouteView.TabIndex = 1;
            this.buttonRouteView.Text = "Route View";
            this.buttonRouteView.UseVisualStyleBackColor = true;
            this.buttonRouteView.Click += new System.EventHandler(this.buttonRouteView_Click);
            // 
            // buttonReports
            // 
            this.buttonReports.Location = new System.Drawing.Point(2, 88);
            this.buttonReports.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReports.Name = "buttonReports";
            this.buttonReports.Size = new System.Drawing.Size(143, 39);
            this.buttonReports.TabIndex = 2;
            this.buttonReports.Text = "Reports";
            this.buttonReports.UseVisualStyleBackColor = true;
            this.buttonReports.Click += new System.EventHandler(this.buttonReports_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLogout.Location = new System.Drawing.Point(2, 606);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(143, 37);
            this.buttonLogout.TabIndex = 3;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // FormAdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1069, 645);
            this.Controls.Add(this.panelContentAdminDashboard);
            this.Controls.Add(this.flowLayoutPanelSideBarAdmin);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormAdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrator Dashboard";
            this.flowLayoutPanelSideBarAdmin.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelContentAdminDashboard;
        private System.Windows.Forms.Panel flowLayoutPanelSideBarAdmin;
        private System.Windows.Forms.Button buttonStudentRegister;
        private System.Windows.Forms.Button buttonRouteView;
        private System.Windows.Forms.Button buttonReports;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonDriverRegister;
    }
}