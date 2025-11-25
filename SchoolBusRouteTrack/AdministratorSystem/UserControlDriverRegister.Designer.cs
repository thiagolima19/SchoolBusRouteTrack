namespace SchoolBusRouteTrack.AdministratorSystem
{
    partial class UserControlDriverRegister
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelErrorAssignedVehicle = new System.Windows.Forms.Label();
            this.labelErrorPhone = new System.Windows.Forms.Label();
            this.labelErrorName = new System.Windows.Forms.Label();
            this.listBoxDriver = new System.Windows.Forms.ListBox();
            this.buttonDriverClear = new System.Windows.Forms.Button();
            this.buttonDriverSave = new System.Windows.Forms.Button();
            this.labelPageTittle = new System.Windows.Forms.Label();
            this.textBoxAssignedVehicle = new System.Windows.Forms.TextBox();
            this.labelAssignedVehicle = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelErrorAddress = new System.Windows.Forms.Label();
            this.gMapControlDriverAddress = new GMap.NET.WindowsForms.GMapControl();
            this.buttonAddressSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelErrorAssignedVehicle
            // 
            this.labelErrorAssignedVehicle.AutoSize = true;
            this.labelErrorAssignedVehicle.ForeColor = System.Drawing.Color.Red;
            this.labelErrorAssignedVehicle.Location = new System.Drawing.Point(133, 275);
            this.labelErrorAssignedVehicle.Name = "labelErrorAssignedVehicle";
            this.labelErrorAssignedVehicle.Size = new System.Drawing.Size(0, 13);
            this.labelErrorAssignedVehicle.TabIndex = 61;
            this.labelErrorAssignedVehicle.Tag = "";
            // 
            // labelErrorPhone
            // 
            this.labelErrorPhone.AutoSize = true;
            this.labelErrorPhone.ForeColor = System.Drawing.Color.Red;
            this.labelErrorPhone.Location = new System.Drawing.Point(135, 226);
            this.labelErrorPhone.Name = "labelErrorPhone";
            this.labelErrorPhone.Size = new System.Drawing.Size(0, 13);
            this.labelErrorPhone.TabIndex = 56;
            // 
            // labelErrorName
            // 
            this.labelErrorName.AutoSize = true;
            this.labelErrorName.ForeColor = System.Drawing.Color.Red;
            this.labelErrorName.Location = new System.Drawing.Point(131, 133);
            this.labelErrorName.Name = "labelErrorName";
            this.labelErrorName.Size = new System.Drawing.Size(0, 13);
            this.labelErrorName.TabIndex = 53;
            // 
            // listBoxDriver
            // 
            this.listBoxDriver.FormattingEnabled = true;
            this.listBoxDriver.Location = new System.Drawing.Point(568, 110);
            this.listBoxDriver.Name = "listBoxDriver";
            this.listBoxDriver.Size = new System.Drawing.Size(266, 433);
            this.listBoxDriver.TabIndex = 52;
            // 
            // buttonDriverClear
            // 
            this.buttonDriverClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDriverClear.Location = new System.Drawing.Point(470, 574);
            this.buttonDriverClear.Name = "buttonDriverClear";
            this.buttonDriverClear.Size = new System.Drawing.Size(75, 23);
            this.buttonDriverClear.TabIndex = 51;
            this.buttonDriverClear.Text = "Clear";
            this.buttonDriverClear.UseVisualStyleBackColor = true;
            this.buttonDriverClear.Click += new System.EventHandler(this.ButtonDriverClear_Click);
            // 
            // buttonDriverSave
            // 
            this.buttonDriverSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDriverSave.Location = new System.Drawing.Point(231, 574);
            this.buttonDriverSave.Name = "buttonDriverSave";
            this.buttonDriverSave.Size = new System.Drawing.Size(75, 23);
            this.buttonDriverSave.TabIndex = 50;
            this.buttonDriverSave.Text = "Save";
            this.buttonDriverSave.UseVisualStyleBackColor = true;
            this.buttonDriverSave.Click += new System.EventHandler(this.ButtonDriverSave_Click);
            // 
            // labelPageTittle
            // 
            this.labelPageTittle.AutoSize = true;
            this.labelPageTittle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPageTittle.Location = new System.Drawing.Point(285, 66);
            this.labelPageTittle.Name = "labelPageTittle";
            this.labelPageTittle.Size = new System.Drawing.Size(165, 20);
            this.labelPageTittle.TabIndex = 49;
            this.labelPageTittle.Text = "Driver Management";
            // 
            // textBoxAssignedVehicle
            // 
            this.textBoxAssignedVehicle.Location = new System.Drawing.Point(134, 252);
            this.textBoxAssignedVehicle.Name = "textBoxAssignedVehicle";
            this.textBoxAssignedVehicle.Size = new System.Drawing.Size(288, 20);
            this.textBoxAssignedVehicle.TabIndex = 44;
            this.textBoxAssignedVehicle.Tag = "AssignedVehicle";
            // 
            // labelAssignedVehicle
            // 
            this.labelAssignedVehicle.AutoSize = true;
            this.labelAssignedVehicle.Location = new System.Drawing.Point(49, 255);
            this.labelAssignedVehicle.Name = "labelAssignedVehicle";
            this.labelAssignedVehicle.Size = new System.Drawing.Size(85, 13);
            this.labelAssignedVehicle.TabIndex = 43;
            this.labelAssignedVehicle.Text = "Assigned Route:";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(136, 203);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(288, 20);
            this.textBoxPhone.TabIndex = 42;
            this.textBoxPhone.Tag = "Phone";
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(51, 203);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(41, 13);
            this.labelPhone.TabIndex = 41;
            this.labelPhone.Text = "Phone:";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(134, 155);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(288, 20);
            this.textBoxAddress.TabIndex = 34;
            this.textBoxAddress.Tag = "Address";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(49, 155);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(48, 13);
            this.labelAddress.TabIndex = 33;
            this.labelAddress.Text = "Address:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(134, 110);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(288, 20);
            this.textBoxName.TabIndex = 32;
            this.textBoxName.Tag = "Name";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(49, 110);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 31;
            this.labelName.Text = "Name:";
            // 
            // labelErrorAddress
            // 
            this.labelErrorAddress.AutoSize = true;
            this.labelErrorAddress.ForeColor = System.Drawing.Color.Red;
            this.labelErrorAddress.Location = new System.Drawing.Point(135, 178);
            this.labelErrorAddress.Name = "labelErrorAddress";
            this.labelErrorAddress.Size = new System.Drawing.Size(0, 13);
            this.labelErrorAddress.TabIndex = 62;
            // 
            // gMapControlDriverAddress
            // 
            this.gMapControlDriverAddress.Bearing = 0F;
            this.gMapControlDriverAddress.CanDragMap = true;
            this.gMapControlDriverAddress.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControlDriverAddress.GrayScaleMode = false;
            this.gMapControlDriverAddress.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControlDriverAddress.LevelsKeepInMemory = 5;
            this.gMapControlDriverAddress.Location = new System.Drawing.Point(134, 342);
            this.gMapControlDriverAddress.MarkersEnabled = true;
            this.gMapControlDriverAddress.MaxZoom = 2;
            this.gMapControlDriverAddress.MinZoom = 2;
            this.gMapControlDriverAddress.MouseWheelZoomEnabled = true;
            this.gMapControlDriverAddress.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControlDriverAddress.Name = "gMapControlDriverAddress";
            this.gMapControlDriverAddress.NegativeMode = false;
            this.gMapControlDriverAddress.PolygonsEnabled = true;
            this.gMapControlDriverAddress.RetryLoadTile = 0;
            this.gMapControlDriverAddress.RoutesEnabled = true;
            this.gMapControlDriverAddress.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControlDriverAddress.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControlDriverAddress.ShowTileGridLines = false;
            this.gMapControlDriverAddress.Size = new System.Drawing.Size(288, 150);
            this.gMapControlDriverAddress.TabIndex = 63;
            this.gMapControlDriverAddress.Zoom = 0D;
            // 
            // buttonAddressSearch
            // 
            this.buttonAddressSearch.Location = new System.Drawing.Point(428, 155);
            this.buttonAddressSearch.Name = "buttonAddressSearch";
            this.buttonAddressSearch.Size = new System.Drawing.Size(75, 20);
            this.buttonAddressSearch.TabIndex = 64;
            this.buttonAddressSearch.Text = "Search";
            this.buttonAddressSearch.UseVisualStyleBackColor = true;
            this.buttonAddressSearch.Click += new System.EventHandler(this.ButtonAddressSearch_Click);
            // 
            // UserControlDriverRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonAddressSearch);
            this.Controls.Add(this.gMapControlDriverAddress);
            this.Controls.Add(this.labelErrorAddress);
            this.Controls.Add(this.labelErrorAssignedVehicle);
            this.Controls.Add(this.labelErrorPhone);
            this.Controls.Add(this.labelErrorName);
            this.Controls.Add(this.listBoxDriver);
            this.Controls.Add(this.buttonDriverClear);
            this.Controls.Add(this.buttonDriverSave);
            this.Controls.Add(this.labelPageTittle);
            this.Controls.Add(this.textBoxAssignedVehicle);
            this.Controls.Add(this.labelAssignedVehicle);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Name = "UserControlDriverRegister";
            this.Size = new System.Drawing.Size(883, 663);
            this.Click += new System.EventHandler(this.HandleClickOutsideListBox);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelErrorAssignedVehicle;
        private System.Windows.Forms.Label labelErrorPhone;
        private System.Windows.Forms.Label labelErrorName;
        private System.Windows.Forms.ListBox listBoxDriver;
        private System.Windows.Forms.Button buttonDriverClear;
        private System.Windows.Forms.Button buttonDriverSave;
        private System.Windows.Forms.Label labelPageTittle;
        private System.Windows.Forms.TextBox textBoxAssignedVehicle;
        private System.Windows.Forms.Label labelAssignedVehicle;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelErrorAddress;
        private GMap.NET.WindowsForms.GMapControl gMapControlDriverAddress;
        private System.Windows.Forms.Button buttonAddressSearch;
    }
}
