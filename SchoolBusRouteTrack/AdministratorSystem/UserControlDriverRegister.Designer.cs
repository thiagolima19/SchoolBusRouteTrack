namespace SchoolBusRouteTrack.Models
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lbl_AssignedVehicle = new System.Windows.Forms.Label();
            this.comboBoxRoute = new System.Windows.Forms.ComboBox();
            this.comboBoxVehicle = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelErrorAssignedVehicle
            // 
            this.labelErrorAssignedVehicle.AutoSize = true;
            this.labelErrorAssignedVehicle.ForeColor = System.Drawing.Color.Red;
            this.labelErrorAssignedVehicle.Location = new System.Drawing.Point(266, 529);
            this.labelErrorAssignedVehicle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelErrorAssignedVehicle.Name = "labelErrorAssignedVehicle";
            this.labelErrorAssignedVehicle.Size = new System.Drawing.Size(0, 25);
            this.labelErrorAssignedVehicle.TabIndex = 61;
            this.labelErrorAssignedVehicle.Tag = "";
            // 
            // labelErrorPhone
            // 
            this.labelErrorPhone.AutoSize = true;
            this.labelErrorPhone.ForeColor = System.Drawing.Color.Red;
            this.labelErrorPhone.Location = new System.Drawing.Point(270, 435);
            this.labelErrorPhone.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelErrorPhone.Name = "labelErrorPhone";
            this.labelErrorPhone.Size = new System.Drawing.Size(0, 25);
            this.labelErrorPhone.TabIndex = 56;
            // 
            // labelErrorName
            // 
            this.labelErrorName.AutoSize = true;
            this.labelErrorName.ForeColor = System.Drawing.Color.Red;
            this.labelErrorName.Location = new System.Drawing.Point(262, 256);
            this.labelErrorName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelErrorName.Name = "labelErrorName";
            this.labelErrorName.Size = new System.Drawing.Size(0, 25);
            this.labelErrorName.TabIndex = 53;
            // 
            // listBoxDriver
            // 
            this.listBoxDriver.FormattingEnabled = true;
            this.listBoxDriver.ItemHeight = 25;
            this.listBoxDriver.Location = new System.Drawing.Point(1136, 212);
            this.listBoxDriver.Margin = new System.Windows.Forms.Padding(6);
            this.listBoxDriver.Name = "listBoxDriver";
            this.listBoxDriver.Size = new System.Drawing.Size(528, 829);
            this.listBoxDriver.TabIndex = 52;
            // 
            // buttonDriverClear
            // 
            this.buttonDriverClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDriverClear.Location = new System.Drawing.Point(577, 1104);
            this.buttonDriverClear.Margin = new System.Windows.Forms.Padding(6);
            this.buttonDriverClear.Name = "buttonDriverClear";
            this.buttonDriverClear.Size = new System.Drawing.Size(150, 44);
            this.buttonDriverClear.TabIndex = 51;
            this.buttonDriverClear.Text = "Clear";
            this.buttonDriverClear.UseVisualStyleBackColor = true;
            this.buttonDriverClear.Click += new System.EventHandler(this.ButtonDriverClear_Click);
            // 
            // buttonDriverSave
            // 
            this.buttonDriverSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDriverSave.Location = new System.Drawing.Point(348, 1104);
            this.buttonDriverSave.Margin = new System.Windows.Forms.Padding(6);
            this.buttonDriverSave.Name = "buttonDriverSave";
            this.buttonDriverSave.Size = new System.Drawing.Size(150, 44);
            this.buttonDriverSave.TabIndex = 50;
            this.buttonDriverSave.Text = "Save";
            this.buttonDriverSave.UseVisualStyleBackColor = true;
            this.buttonDriverSave.Click += new System.EventHandler(this.ButtonDriverSave_Click);
            // 
            // labelPageTittle
            // 
            this.labelPageTittle.AutoSize = true;
            this.labelPageTittle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPageTittle.Location = new System.Drawing.Point(570, 127);
            this.labelPageTittle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelPageTittle.Name = "labelPageTittle";
            this.labelPageTittle.Size = new System.Drawing.Size(313, 37);
            this.labelPageTittle.TabIndex = 49;
            this.labelPageTittle.Text = "Driver Management";
            // 
            // labelAssignedVehicle
            // 
            this.labelAssignedVehicle.AutoSize = true;
            this.labelAssignedVehicle.Location = new System.Drawing.Point(98, 490);
            this.labelAssignedVehicle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelAssignedVehicle.Name = "labelAssignedVehicle";
            this.labelAssignedVehicle.Size = new System.Drawing.Size(170, 25);
            this.labelAssignedVehicle.TabIndex = 43;
            this.labelAssignedVehicle.Text = "Assigned Route:";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(272, 390);
            this.textBoxPhone.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(572, 31);
            this.textBoxPhone.TabIndex = 42;
            this.textBoxPhone.Tag = "Phone";
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(102, 390);
            this.labelPhone.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(80, 25);
            this.labelPhone.TabIndex = 41;
            this.labelPhone.Text = "Phone:";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(268, 298);
            this.textBoxAddress.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(572, 31);
            this.textBoxAddress.TabIndex = 34;
            this.textBoxAddress.Tag = "Address";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(98, 298);
            this.labelAddress.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(97, 25);
            this.labelAddress.TabIndex = 33;
            this.labelAddress.Text = "Address:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(268, 212);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(572, 31);
            this.textBoxName.TabIndex = 32;
            this.textBoxName.Tag = "Name";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(98, 212);
            this.labelName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(74, 25);
            this.labelName.TabIndex = 31;
            this.labelName.Text = "Name:";
            // 
            // labelErrorAddress
            // 
            this.labelErrorAddress.AutoSize = true;
            this.labelErrorAddress.ForeColor = System.Drawing.Color.Red;
            this.labelErrorAddress.Location = new System.Drawing.Point(270, 342);
            this.labelErrorAddress.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelErrorAddress.Name = "labelErrorAddress";
            this.labelErrorAddress.Size = new System.Drawing.Size(0, 25);
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
            this.gMapControlDriverAddress.Location = new System.Drawing.Point(268, 658);
            this.gMapControlDriverAddress.Margin = new System.Windows.Forms.Padding(6);
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
            this.gMapControlDriverAddress.Size = new System.Drawing.Size(576, 288);
            this.gMapControlDriverAddress.TabIndex = 63;
            this.gMapControlDriverAddress.Zoom = 0D;
            // 
            // buttonAddressSearch
            // 
            this.buttonAddressSearch.Location = new System.Drawing.Point(856, 298);
            this.buttonAddressSearch.Margin = new System.Windows.Forms.Padding(6);
            this.buttonAddressSearch.Name = "buttonAddressSearch";
            this.buttonAddressSearch.Size = new System.Drawing.Size(150, 38);
            this.buttonAddressSearch.TabIndex = 64;
            this.buttonAddressSearch.Text = "Search";
            this.buttonAddressSearch.UseVisualStyleBackColor = true;
            this.buttonAddressSearch.Click += new System.EventHandler(this.ButtonAddressSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(577, 1176);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(150, 44);
            this.btnDelete.TabIndex = 66;
            this.btnDelete.Tag = "delete";
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(348, 1176);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(150, 44);
            this.btnEdit.TabIndex = 65;
            this.btnEdit.Tag = "edit";
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lbl_AssignedVehicle
            // 
            this.lbl_AssignedVehicle.AutoSize = true;
            this.lbl_AssignedVehicle.Location = new System.Drawing.Point(82, 563);
            this.lbl_AssignedVehicle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_AssignedVehicle.Name = "lbl_AssignedVehicle";
            this.lbl_AssignedVehicle.Size = new System.Drawing.Size(352, 25);
            this.lbl_AssignedVehicle.TabIndex = 67;
            this.lbl_AssignedVehicle.Text = "Assigned vehicle: (Plate # XXX123)";
            // 
            // comboBoxRoute
            // 
            this.comboBoxRoute.FormattingEnabled = true;
            this.comboBoxRoute.Location = new System.Drawing.Point(277, 490);
            this.comboBoxRoute.Name = "comboBoxRoute";
            this.comboBoxRoute.Size = new System.Drawing.Size(567, 33);
            this.comboBoxRoute.TabIndex = 69;
            // 
            // comboBoxVehicle
            // 
            this.comboBoxVehicle.FormattingEnabled = true;
            this.comboBoxVehicle.Location = new System.Drawing.Point(443, 560);
            this.comboBoxVehicle.Name = "comboBoxVehicle";
            this.comboBoxVehicle.Size = new System.Drawing.Size(401, 33);
            this.comboBoxVehicle.TabIndex = 70;
            // 
            // UserControlDriverRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxVehicle);
            this.Controls.Add(this.comboBoxRoute);
            this.Controls.Add(this.lbl_AssignedVehicle);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
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
            this.Controls.Add(this.labelAssignedVehicle);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "UserControlDriverRegister";
            this.Size = new System.Drawing.Size(1766, 1275);
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
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lbl_AssignedVehicle;
        private System.Windows.Forms.ComboBox comboBoxRoute;
        private System.Windows.Forms.ComboBox comboBoxVehicle;
    }
}
