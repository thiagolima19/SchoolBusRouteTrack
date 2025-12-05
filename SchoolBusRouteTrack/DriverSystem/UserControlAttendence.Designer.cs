namespace SchoolBusRouteTrack.DriverSystem
{
    partial class UserControlAttendence
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelAttendancePage = new System.Windows.Forms.Label();
            this.labelRoute = new System.Windows.Forms.Label();
            this.comboBoxRoutes = new System.Windows.Forms.ComboBox();
            this.labelStop = new System.Windows.Forms.Label();
            this.comboBoxStops = new System.Windows.Forms.ComboBox();
            this.buttonSaveAttendance = new System.Windows.Forms.Button();
            this.buttonShowStudents = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(61, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(538, 300);
            this.panel1.TabIndex = 0;
            // 
            // labelAttendancePage
            // 
            this.labelAttendancePage.AutoSize = true;
            this.labelAttendancePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAttendancePage.Location = new System.Drawing.Point(233, 20);
            this.labelAttendancePage.Name = "labelAttendancePage";
            this.labelAttendancePage.Size = new System.Drawing.Size(180, 20);
            this.labelAttendancePage.TabIndex = 7;
            this.labelAttendancePage.Text = "Students Attendance";
            // 
            // labelRoute
            // 
            this.labelRoute.AutoSize = true;
            this.labelRoute.Location = new System.Drawing.Point(76, 66);
            this.labelRoute.Name = "labelRoute";
            this.labelRoute.Size = new System.Drawing.Size(42, 13);
            this.labelRoute.TabIndex = 6;
            this.labelRoute.Text = "Route: ";
            // 
            // comboBoxRoutes
            // 
            this.comboBoxRoutes.FormattingEnabled = true;
            this.comboBoxRoutes.Items.AddRange(new object[] {
            "Route School 1",
            "Route School 2"});
            this.comboBoxRoutes.Location = new System.Drawing.Point(124, 63);
            this.comboBoxRoutes.Name = "comboBoxRoutes";
            this.comboBoxRoutes.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRoutes.TabIndex = 5;
            this.comboBoxRoutes.Text = "Route School 1";
            // 
            // labelStop
            // 
            this.labelStop.AutoSize = true;
            this.labelStop.Location = new System.Drawing.Point(283, 66);
            this.labelStop.Name = "labelStop";
            this.labelStop.Size = new System.Drawing.Size(35, 13);
            this.labelStop.TabIndex = 9;
            this.labelStop.Text = "Stop: ";
            // 
            // comboBoxStops
            // 
            this.comboBoxStops.FormattingEnabled = true;
            this.comboBoxStops.Items.AddRange(new object[] {
            "Bus Stop 1",
            "Bus Stop 2",
            "Bus Stop 3"});
            this.comboBoxStops.Location = new System.Drawing.Point(324, 63);
            this.comboBoxStops.Name = "comboBoxStops";
            this.comboBoxStops.Size = new System.Drawing.Size(121, 21);
            this.comboBoxStops.TabIndex = 8;
            this.comboBoxStops.Text = "Bus Stop 1";
            // 
            // buttonSaveAttendance
            // 
            this.buttonSaveAttendance.Location = new System.Drawing.Point(524, 412);
            this.buttonSaveAttendance.Name = "buttonSaveAttendance";
            this.buttonSaveAttendance.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveAttendance.TabIndex = 10;
            this.buttonSaveAttendance.Text = "Save";
            this.buttonSaveAttendance.UseVisualStyleBackColor = true;
            this.buttonSaveAttendance.Click += new System.EventHandler(this.buttonSaveAttendance_Click);
            // 
            // buttonShowStudents
            // 
            this.buttonShowStudents.Location = new System.Drawing.Point(485, 63);
            this.buttonShowStudents.Name = "buttonShowStudents";
            this.buttonShowStudents.Size = new System.Drawing.Size(90, 23);
            this.buttonShowStudents.TabIndex = 11;
            this.buttonShowStudents.Text = "Show Students";
            this.buttonShowStudents.UseVisualStyleBackColor = true;
            // 
            // UserControlAttendence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.buttonShowStudents);
            this.Controls.Add(this.buttonSaveAttendance);
            this.Controls.Add(this.labelStop);
            this.Controls.Add(this.comboBoxStops);
            this.Controls.Add(this.labelAttendancePage);
            this.Controls.Add(this.labelRoute);
            this.Controls.Add(this.comboBoxRoutes);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControlAttendence";
            this.Size = new System.Drawing.Size(653, 468);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelAttendancePage;
        private System.Windows.Forms.Label labelRoute;
        private System.Windows.Forms.ComboBox comboBoxRoutes;
        private System.Windows.Forms.Label labelStop;
        private System.Windows.Forms.ComboBox comboBoxStops;
        private System.Windows.Forms.Button buttonSaveAttendance;
        private System.Windows.Forms.Button buttonShowStudents;
    }
}
