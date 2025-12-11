namespace SchoolBusRouteTrack
{
    partial class FormAddRoute
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
            this.components = new System.ComponentModel.Container();
            this.lbl_route = new System.Windows.Forms.Label();
            this.lbl_school = new System.Windows.Forms.Label();
            this.lbl_description = new System.Windows.Forms.Label();
            this.lbl_driver = new System.Windows.Forms.Label();
            this.lbl_stop_address = new System.Windows.Forms.Label();
            this.lbl_vehicle = new System.Windows.Forms.Label();
            this.txt_route_num = new System.Windows.Forms.TextBox();
            this.txt_description = new System.Windows.Forms.TextBox();
            this.cb_school = new System.Windows.Forms.ComboBox();
            this.cb_driver = new System.Windows.Forms.ComboBox();
            this.cb_vehicle = new System.Windows.Forms.ComboBox();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.list_stops = new System.Windows.Forms.ListBox();
            this.btn_up = new System.Windows.Forms.Button();
            this.btn_down = new System.Windows.Forms.Button();
            this.label_erro_endereco = new System.Windows.Forms.Label();
            this.btn_remove = new System.Windows.Forms.Button();
            this.lbl_error = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lbl_list_stops = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_route
            // 
            this.lbl_route.AutoSize = true;
            this.lbl_route.Location = new System.Drawing.Point(33, 38);
            this.lbl_route.Name = "lbl_route";
            this.lbl_route.Size = new System.Drawing.Size(94, 16);
            this.lbl_route.TabIndex = 0;
            this.lbl_route.Text = "Route Number";
            // 
            // lbl_school
            // 
            this.lbl_school.AutoSize = true;
            this.lbl_school.Location = new System.Drawing.Point(33, 163);
            this.lbl_school.Name = "lbl_school";
            this.lbl_school.Size = new System.Drawing.Size(49, 16);
            this.lbl_school.TabIndex = 1;
            this.lbl_school.Text = "School";
            // 
            // lbl_description
            // 
            this.lbl_description.AutoSize = true;
            this.lbl_description.Location = new System.Drawing.Point(33, 103);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(75, 16);
            this.lbl_description.TabIndex = 2;
            this.lbl_description.Text = "Description";
            // 
            // lbl_driver
            // 
            this.lbl_driver.AutoSize = true;
            this.lbl_driver.Location = new System.Drawing.Point(33, 217);
            this.lbl_driver.Name = "lbl_driver";
            this.lbl_driver.Size = new System.Drawing.Size(43, 16);
            this.lbl_driver.TabIndex = 3;
            this.lbl_driver.Text = "Driver";
            // 
            // lbl_stop_address
            // 
            this.lbl_stop_address.AutoSize = true;
            this.lbl_stop_address.Location = new System.Drawing.Point(283, 37);
            this.lbl_stop_address.Name = "lbl_stop_address";
            this.lbl_stop_address.Size = new System.Drawing.Size(89, 16);
            this.lbl_stop_address.TabIndex = 4;
            this.lbl_stop_address.Text = "Stop Address";
            // 
            // lbl_vehicle
            // 
            this.lbl_vehicle.AutoSize = true;
            this.lbl_vehicle.Location = new System.Drawing.Point(33, 276);
            this.lbl_vehicle.Name = "lbl_vehicle";
            this.lbl_vehicle.Size = new System.Drawing.Size(52, 16);
            this.lbl_vehicle.TabIndex = 5;
            this.lbl_vehicle.Text = "Vehicle";
            // 
            // txt_route_num
            // 
            this.txt_route_num.Location = new System.Drawing.Point(36, 57);
            this.txt_route_num.Name = "txt_route_num";
            this.txt_route_num.Size = new System.Drawing.Size(100, 22);
            this.txt_route_num.TabIndex = 6;
            // 
            // txt_description
            // 
            this.txt_description.Location = new System.Drawing.Point(36, 122);
            this.txt_description.Name = "txt_description";
            this.txt_description.Size = new System.Drawing.Size(228, 22);
            this.txt_description.TabIndex = 7;
            // 
            // cb_school
            // 
            this.cb_school.FormattingEnabled = true;
            this.cb_school.Location = new System.Drawing.Point(36, 182);
            this.cb_school.Name = "cb_school";
            this.cb_school.Size = new System.Drawing.Size(228, 24);
            this.cb_school.TabIndex = 8;
            // 
            // cb_driver
            // 
            this.cb_driver.FormattingEnabled = true;
            this.cb_driver.Location = new System.Drawing.Point(36, 236);
            this.cb_driver.Name = "cb_driver";
            this.cb_driver.Size = new System.Drawing.Size(228, 24);
            this.cb_driver.TabIndex = 9;
            // 
            // cb_vehicle
            // 
            this.cb_vehicle.FormattingEnabled = true;
            this.cb_vehicle.Location = new System.Drawing.Point(36, 295);
            this.cb_vehicle.Name = "cb_vehicle";
            this.cb_vehicle.Size = new System.Drawing.Size(228, 24);
            this.cb_vehicle.TabIndex = 10;
            // 
            // txt_address
            // 
            this.txt_address.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txt_address.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_address.Location = new System.Drawing.Point(286, 57);
            this.txt_address.Margin = new System.Windows.Forms.Padding(4);
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(383, 22);
            this.txt_address.TabIndex = 35;
            this.txt_address.Tag = "Address";
            this.txt_address.TextChanged += new System.EventHandler(this.txt_address_TextChanged);
            //
            // btn_add
            //
            this.btn_add.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btn_add.FlatAppearance.BorderSize = 0;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btn_add.ForeColor = System.Drawing.Color.White;
            this.btn_add.Location = new System.Drawing.Point(700, 50);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 40);
            this.btn_add.TabIndex = 36;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // list_stops
            // 
            this.list_stops.FormattingEnabled = true;
            this.list_stops.ItemHeight = 16;
            this.list_stops.Location = new System.Drawing.Point(286, 122);
            this.list_stops.Name = "list_stops";
            this.list_stops.Size = new System.Drawing.Size(383, 228);
            this.list_stops.TabIndex = 37;
            //
            // btn_up
            //
            this.btn_up.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btn_up.FlatAppearance.BorderSize = 0;
            this.btn_up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_up.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btn_up.ForeColor = System.Drawing.Color.White;
            this.btn_up.Location = new System.Drawing.Point(700, 183);
            this.btn_up.Name = "btn_up";
            this.btn_up.Size = new System.Drawing.Size(75, 40);
            this.btn_up.TabIndex = 38;
            this.btn_up.Text = "Up";
            this.btn_up.UseVisualStyleBackColor = false;
            this.btn_up.Click += new System.EventHandler(this.btn_up_Click);
            //
            // btn_down
            //
            this.btn_down.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btn_down.FlatAppearance.BorderSize = 0;
            this.btn_down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_down.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btn_down.ForeColor = System.Drawing.Color.White;
            this.btn_down.Location = new System.Drawing.Point(700, 246);
            this.btn_down.Name = "btn_down";
            this.btn_down.Size = new System.Drawing.Size(75, 40);
            this.btn_down.TabIndex = 39;
            this.btn_down.Text = "Down";
            this.btn_down.UseVisualStyleBackColor = false;
            this.btn_down.Click += new System.EventHandler(this.btn_down_Click);
            // 
            // label_erro_endereco
            // 
            this.label_erro_endereco.AutoSize = true;
            this.label_erro_endereco.Location = new System.Drawing.Point(317, 87);
            this.label_erro_endereco.Name = "label_erro_endereco";
            this.label_erro_endereco.Size = new System.Drawing.Size(0, 16);
            this.label_erro_endereco.TabIndex = 40;
            //
            // btn_remove
            //
            this.btn_remove.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btn_remove.FlatAppearance.BorderSize = 0;
            this.btn_remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btn_remove.ForeColor = System.Drawing.Color.White;
            this.btn_remove.Location = new System.Drawing.Point(700, 119);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(75, 40);
            this.btn_remove.TabIndex = 41;
            this.btn_remove.Text = "Remove";
            this.btn_remove.UseVisualStyleBackColor = false;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // lbl_error
            // 
            this.lbl_error.AutoSize = true;
            this.lbl_error.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_error.Location = new System.Drawing.Point(174, 383);
            this.lbl_error.Name = "lbl_error";
            this.lbl_error.Size = new System.Drawing.Size(0, 25);
            this.lbl_error.TabIndex = 42;
            //
            // btn_save
            //
            this.btn_save.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btn_save.FlatAppearance.BorderSize = 0;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(700, 307);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 40);
            this.btn_save.TabIndex = 43;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lbl_list_stops
            // 
            this.lbl_list_stops.AutoSize = true;
            this.lbl_list_stops.Location = new System.Drawing.Point(283, 103);
            this.lbl_list_stops.Name = "lbl_list_stops";
            this.lbl_list_stops.Size = new System.Drawing.Size(65, 16);
            this.lbl_list_stops.TabIndex = 45;
            this.lbl_list_stops.Text = "Stops List";
            // 
            // FormAddRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_list_stops);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.lbl_error);
            this.Controls.Add(this.btn_remove);
            this.Controls.Add(this.label_erro_endereco);
            this.Controls.Add(this.btn_down);
            this.Controls.Add(this.btn_up);
            this.Controls.Add(this.list_stops);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.txt_address);
            this.Controls.Add(this.cb_vehicle);
            this.Controls.Add(this.cb_driver);
            this.Controls.Add(this.cb_school);
            this.Controls.Add(this.txt_description);
            this.Controls.Add(this.txt_route_num);
            this.Controls.Add(this.lbl_vehicle);
            this.Controls.Add(this.lbl_stop_address);
            this.Controls.Add(this.lbl_driver);
            this.Controls.Add(this.lbl_description);
            this.Controls.Add(this.lbl_school);
            this.Controls.Add(this.lbl_route);
            this.Name = "FormAddRoute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Route";
            this.Load += new System.EventHandler(this.AddRouteForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_route;
        private System.Windows.Forms.Label lbl_school;
        private System.Windows.Forms.Label lbl_description;
        private System.Windows.Forms.Label lbl_driver;
        private System.Windows.Forms.Label lbl_stop_address;
        private System.Windows.Forms.Label lbl_vehicle;
        private System.Windows.Forms.TextBox txt_route_num;
        private System.Windows.Forms.TextBox txt_description;
        private System.Windows.Forms.ComboBox cb_school;
        private System.Windows.Forms.ComboBox cb_driver;
        private System.Windows.Forms.ComboBox cb_vehicle;
        private System.Windows.Forms.TextBox txt_address;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.ListBox list_stops;
        private System.Windows.Forms.Button btn_up;
        private System.Windows.Forms.Button btn_down;
        private System.Windows.Forms.Label label_erro_endereco;
        private System.Windows.Forms.Button btn_remove;
        private System.Windows.Forms.Label lbl_error;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lbl_list_stops;
    }
}