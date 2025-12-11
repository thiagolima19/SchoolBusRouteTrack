namespace SchoolBusRouteTrack.AdministratorSystem
{
    partial class UserControlRouteView
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.comboBoxRoutes = new System.Windows.Forms.ComboBox();
            this.btn_addRoute = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_remove = new System.Windows.Forms.Button();
            this.lbl_school = new System.Windows.Forms.Label();
            this.lbl_driver = new System.Windows.Forms.Label();
            this.lbl_plate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMapControl1.AutoSize = true;
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(281, 11);
            this.gMapControl1.Margin = new System.Windows.Forms.Padding(2);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(937, 770);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            // 
            // comboBoxRoutes
            // 
            this.comboBoxRoutes.FormattingEnabled = true;
            this.comboBoxRoutes.Location = new System.Drawing.Point(21, 11);
            this.comboBoxRoutes.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxRoutes.Name = "comboBoxRoutes";
            this.comboBoxRoutes.Size = new System.Drawing.Size(214, 24);
            this.comboBoxRoutes.TabIndex = 1;
            //
            // btn_addRoute
            //
            this.btn_addRoute.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btn_addRoute.FlatAppearance.BorderSize = 0;
            this.btn_addRoute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addRoute.ForeColor = System.Drawing.Color.White;
            this.btn_addRoute.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btn_addRoute.Location = new System.Drawing.Point(31, 64);
            this.btn_addRoute.Name = "btn_addRoute";
            this.btn_addRoute.Size = new System.Drawing.Size(122, 28);
            this.btn_addRoute.TabIndex = 2;
            this.btn_addRoute.Text = "Add Route";
            this.btn_addRoute.UseVisualStyleBackColor = false;
            this.btn_addRoute.Click += new System.EventHandler(this.btn_addRoute_Click);
            //
            // btn_edit
            //
            this.btn_edit.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btn_edit.FlatAppearance.BorderSize = 0;
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit.ForeColor = System.Drawing.Color.White;
            this.btn_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btn_edit.Location = new System.Drawing.Point(31, 98);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(122, 28);
            this.btn_edit.TabIndex = 3;
            this.btn_edit.Text = "Edit Route";
            this.btn_edit.UseVisualStyleBackColor = false;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            //
            // btn_remove
            //
            this.btn_remove.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btn_remove.FlatAppearance.BorderSize = 0;
            this.btn_remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_remove.ForeColor = System.Drawing.Color.White;
            this.btn_remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btn_remove.Location = new System.Drawing.Point(31, 132);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(122, 28);
            this.btn_remove.TabIndex = 4;
            this.btn_remove.Text = "Remove Route";
            this.btn_remove.UseVisualStyleBackColor = false;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            //
            // lbl_school
            //
            this.lbl_school.AutoSize = true;
            this.lbl_school.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_school.Location = new System.Drawing.Point(21, 180);
            this.lbl_school.Name = "lbl_school";
            this.lbl_school.Size = new System.Drawing.Size(60, 18);
            this.lbl_school.TabIndex = 5;
            this.lbl_school.Text = "School:";
            //
            // lbl_driver
            //
            this.lbl_driver.AutoSize = true;
            this.lbl_driver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_driver.Location = new System.Drawing.Point(21, 210);
            this.lbl_driver.Name = "lbl_driver";
            this.lbl_driver.Size = new System.Drawing.Size(56, 18);
            this.lbl_driver.TabIndex = 6;
            this.lbl_driver.Text = "Driver:";
            //
            // lbl_plate
            //
            this.lbl_plate.AutoSize = true;
            this.lbl_plate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_plate.Location = new System.Drawing.Point(21, 240);
            this.lbl_plate.Name = "lbl_plate";
            this.lbl_plate.Size = new System.Drawing.Size(48, 18);
            this.lbl_plate.TabIndex = 7;
            this.lbl_plate.Text = "Plate:";

            //
            // UserControlRouteView
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.lbl_plate);
            this.Controls.Add(this.lbl_driver);
            this.Controls.Add(this.lbl_school);
            this.Controls.Add(this.btn_remove);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_addRoute);
            this.Controls.Add(this.comboBoxRoutes);
            this.Controls.Add(this.gMapControl1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControlRouteView";
            this.Size = new System.Drawing.Size(1229, 794);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.ComboBox comboBoxRoutes;
        private System.Windows.Forms.Button btn_addRoute;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_remove;
        private System.Windows.Forms.Label lbl_school;
        private System.Windows.Forms.Label lbl_driver;
        private System.Windows.Forms.Label lbl_plate;
    }
}
