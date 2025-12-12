namespace SchoolBusRouteTrack.DriverSystem
{
    partial class UserControlRoute
    {
       private System.ComponentModel.IContainer components = null;

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
            this.comboBoxRoutes = new System.Windows.Forms.ComboBox();
            this.labelRouteName = new System.Windows.Forms.Label();
            this.checkedListBoxBusStop = new System.Windows.Forms.CheckedListBox();
            this.gMapControlRoute = new GMap.NET.WindowsForms.GMapControl();
            this.labelRoutePage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxRoutes
            // 
            this.comboBoxRoutes.FormattingEnabled = true;
            this.comboBoxRoutes.Location = new System.Drawing.Point(89, 49);
            this.comboBoxRoutes.Name = "comboBoxRoutes";
            this.comboBoxRoutes.Size = new System.Drawing.Size(200, 21);
            this.comboBoxRoutes.TabIndex = 0;
            this.comboBoxRoutes.Text = "-- Select a Route --";
            // 
            // labelRouteName
            // 
            this.labelRouteName.AutoSize = true;
            this.labelRouteName.Location = new System.Drawing.Point(41, 52);
            this.labelRouteName.Name = "labelRouteName";
            this.labelRouteName.Size = new System.Drawing.Size(42, 13);
            this.labelRouteName.TabIndex = 1;
            this.labelRouteName.Text = "Route: ";
            // 
            // checkedListBoxBusStop
            // 
            this.checkedListBoxBusStop.FormattingEnabled = true;
            this.checkedListBoxBusStop.Location = new System.Drawing.Point(44, 106);
            this.checkedListBoxBusStop.Name = "checkedListBoxBusStop";
            this.checkedListBoxBusStop.Size = new System.Drawing.Size(245, 334);
            this.checkedListBoxBusStop.TabIndex = 2;
            this.checkedListBoxBusStop.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxBusStop_ItemCheck);
            this.checkedListBoxBusStop.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxBusStop_SelectedIndexChanged);
            // 
            // gMapControlRoute
            // 
            this.gMapControlRoute.Bearing = 0F;
            this.gMapControlRoute.CanDragMap = true;
            this.gMapControlRoute.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControlRoute.GrayScaleMode = false;
            this.gMapControlRoute.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControlRoute.LevelsKeepInMemory = 5;
            this.gMapControlRoute.Location = new System.Drawing.Point(307, 52);
            this.gMapControlRoute.MarkersEnabled = true;
            this.gMapControlRoute.MaxZoom = 2;
            this.gMapControlRoute.MinZoom = 2;
            this.gMapControlRoute.MouseWheelZoomEnabled = true;
            this.gMapControlRoute.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControlRoute.Name = "gMapControlRoute";
            this.gMapControlRoute.NegativeMode = false;
            this.gMapControlRoute.PolygonsEnabled = true;
            this.gMapControlRoute.RetryLoadTile = 0;
            this.gMapControlRoute.RoutesEnabled = true;
            this.gMapControlRoute.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControlRoute.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControlRoute.ShowTileGridLines = false;
            this.gMapControlRoute.Size = new System.Drawing.Size(303, 388);
            this.gMapControlRoute.TabIndex = 3;
            this.gMapControlRoute.Zoom = 0D;
            // 
            // labelRoutePage
            // 
            this.labelRoutePage.AutoSize = true;
            this.labelRoutePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRoutePage.Location = new System.Drawing.Point(267, 14);
            this.labelRoutePage.Name = "labelRoutePage";
            this.labelRoutePage.Size = new System.Drawing.Size(123, 20);
            this.labelRoutePage.TabIndex = 4;
            this.labelRoutePage.Text = "Current Route";
            // 
            // UserControlRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.labelRoutePage);
            this.Controls.Add(this.gMapControlRoute);
            this.Controls.Add(this.checkedListBoxBusStop);
            this.Controls.Add(this.labelRouteName);
            this.Controls.Add(this.comboBoxRoutes);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControlRoute";
            this.Size = new System.Drawing.Size(653, 468);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxRoutes;
        private System.Windows.Forms.Label labelRouteName;
        private System.Windows.Forms.CheckedListBox checkedListBoxBusStop;
        private GMap.NET.WindowsForms.GMapControl gMapControlRoute;
        private System.Windows.Forms.Label labelRoutePage;
    }
}
