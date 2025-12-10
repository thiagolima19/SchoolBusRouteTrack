namespace SchoolBusRouteTrack.AdministratorSystem
{
    partial class UserControlReports
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar quaisquer recursos que estejam sendo usados.
        /// </summary>
        /// <param name="disposing">true se recursos gerenciados devem ser descartados; caso contrário, false.</param>
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeaderInfo = new System.Windows.Forms.Panel();
            this.labelReportIDValue = new System.Windows.Forms.Label();
            this.labelReportIDLabel = new System.Windows.Forms.Label();
            this.dateTimePickerReport = new System.Windows.Forms.DateTimePicker();
            this.labelDateTitle = new System.Windows.Forms.Label();
            this.comboBoxTrip = new System.Windows.Forms.ComboBox();
            this.labelTripTitle = new System.Windows.Forms.Label();
            this.labelReportDashboardTitle = new System.Windows.Forms.Label();
            this.tlpMetrics = new System.Windows.Forms.TableLayoutPanel();
            this.panelCardDelays = new System.Windows.Forms.Panel();
            this.labelMetric4Value = new System.Windows.Forms.Label();
            this.labelMetric4Title = new System.Windows.Forms.Label();
            this.panelCardAbsent = new System.Windows.Forms.Panel();
            this.labelMetric3Value = new System.Windows.Forms.Label();
            this.labelMetric3Title = new System.Windows.Forms.Label();
            this.panelCardPresent = new System.Windows.Forms.Panel();
            this.labelMetric2Value = new System.Windows.Forms.Label();
            this.labelMetric2Title = new System.Windows.Forms.Label();
            this.panelCardStudents = new System.Windows.Forms.Panel();
            this.labelMetric1Value = new System.Windows.Forms.Label();
            this.labelMetric1Title = new System.Windows.Forms.Label();
            this.panelActions = new System.Windows.Forms.Panel();
            this.flowLayoutPanelActions = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonGenerateDailyReport = new System.Windows.Forms.Button();
            this.buttonGenerateTripSummary = new System.Windows.Forms.Button();
            this.buttonExportCSV = new System.Windows.Forms.Button();
            this.labelActionsTitle = new System.Windows.Forms.Label();
            this.panelReportsGrid = new System.Windows.Forms.Panel();
            this.dataGridViewReports = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Actions = new System.Windows.Forms.DataGridViewButtonColumn();
            this.labelRecentReportsTitle = new System.Windows.Forms.Label();
            this.panelHeaderInfo.SuspendLayout();
            this.tlpMetrics.SuspendLayout();
            this.panelCardDelays.SuspendLayout();
            this.panelCardAbsent.SuspendLayout();
            this.panelCardPresent.SuspendLayout();
            this.panelCardStudents.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.flowLayoutPanelActions.SuspendLayout();
            this.panelReportsGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeaderInfo
            // 
            this.panelHeaderInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelHeaderInfo.Controls.Add(this.labelReportIDValue);
            this.panelHeaderInfo.Controls.Add(this.labelReportIDLabel);
            this.panelHeaderInfo.Controls.Add(this.dateTimePickerReport);
            this.panelHeaderInfo.Controls.Add(this.labelDateTitle);
            this.panelHeaderInfo.Controls.Add(this.comboBoxTrip);
            this.panelHeaderInfo.Controls.Add(this.labelTripTitle);
            this.panelHeaderInfo.Controls.Add(this.labelReportDashboardTitle);
            this.panelHeaderInfo.Location = new System.Drawing.Point(14, 0);
            this.panelHeaderInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelHeaderInfo.Name = "panelHeaderInfo";
            this.panelHeaderInfo.Padding = new System.Windows.Forms.Padding(9, 8, 9, 0);
            this.panelHeaderInfo.Size = new System.Drawing.Size(1084, 150);
            this.panelHeaderInfo.TabIndex = 0;
            // 
            // labelReportIDValue
            // 
            this.labelReportIDValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelReportIDValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.labelReportIDValue.Location = new System.Drawing.Point(785, 88); // MODIFIED X-coordinate
            this.labelReportIDValue.Name = "labelReportIDValue";
            this.labelReportIDValue.Size = new System.Drawing.Size(100, 28);
            this.labelReportIDValue.TabIndex = 6;
            this.labelReportIDValue.Text = "12345";
            this.labelReportIDValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelReportIDLabel
            // 
            this.labelReportIDLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReportIDLabel.ForeColor = System.Drawing.Color.DimGray;
            this.labelReportIDLabel.Location = new System.Drawing.Point(670, 86); // MODIFIED X-coordinate and Width
            this.labelReportIDLabel.Name = "labelReportIDLabel";
            this.labelReportIDLabel.Size = new System.Drawing.Size(110, 28);
            this.labelReportIDLabel.TabIndex = 5;
            this.labelReportIDLabel.Text = "Report ID:";
            this.labelReportIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // 
            // dateTimePickerReport
            // 
            this.dateTimePickerReport.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerReport.Location = new System.Drawing.Point(505, 88); // MODIFIED X-coordinate
            this.dateTimePickerReport.Name = "dateTimePickerReport";
            this.dateTimePickerReport.Size = new System.Drawing.Size(120, 26);
            this.dateTimePickerReport.TabIndex = 4;
            // 
            // labelDateTitle
            // 
            this.labelDateTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelDateTitle.ForeColor = System.Drawing.Color.Gray;
            this.labelDateTitle.Location = new System.Drawing.Point(430, 86); // MODIFIED X-coordinate
            this.labelDateTitle.Name = "labelDateTitle";
            this.labelDateTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelDateTitle.Size = new System.Drawing.Size(70, 28);
            this.labelDateTitle.TabIndex = 3;
            this.labelDateTitle.Text = "Date:";
            this.labelDateTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // 
            // comboBoxTrip
            // 
            this.comboBoxTrip.FormattingEnabled = true;
            this.comboBoxTrip.Items.AddRange(new object[] {
            "Trip A",
            "Trip B",
            "Field Trip Z"});
            this.comboBoxTrip.Location = new System.Drawing.Point(245, 86); // MODIFIED X-coordinate
            this.comboBoxTrip.Name = "comboBoxTrip";
            this.comboBoxTrip.Size = new System.Drawing.Size(150, 28);
            this.comboBoxTrip.TabIndex = 2;
            this.comboBoxTrip.Text = "Trip A";
            // 
            // labelTripTitle
            // 
            this.labelTripTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelTripTitle.ForeColor = System.Drawing.Color.Gray;
            this.labelTripTitle.Location = new System.Drawing.Point(150, 88); 
            this.labelTripTitle.Name = "labelTripTitle";
            this.labelTripTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelTripTitle.Size = new System.Drawing.Size(90, 28);
            this.labelTripTitle.TabIndex = 1;
            this.labelTripTitle.Text = "Field Trip:";
            this.labelTripTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelReportDashboardTitle
            // 
            this.labelReportDashboardTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelReportDashboardTitle.Location = new System.Drawing.Point(9, 8);
            this.labelReportDashboardTitle.Name = "labelReportDashboardTitle";
            this.labelReportDashboardTitle.Size = new System.Drawing.Size(1063, 60);
            this.labelReportDashboardTitle.TabIndex = 0;
            this.labelReportDashboardTitle.Text = "Report Dashboard";
            this.labelReportDashboardTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // tlpMetrics
            // 
            this.tlpMetrics.ColumnCount = 4;
            this.tlpMetrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMetrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMetrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMetrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMetrics.Controls.Add(this.panelCardDelays, 3, 0);
            this.tlpMetrics.Controls.Add(this.panelCardAbsent, 2, 0);
            this.tlpMetrics.Controls.Add(this.panelCardPresent, 1, 0);
            this.tlpMetrics.Controls.Add(this.panelCardStudents, 0, 0);
            this.tlpMetrics.Location = new System.Drawing.Point(14, 164);
            this.tlpMetrics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlpMetrics.Name = "tlpMetrics";
            this.tlpMetrics.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.tlpMetrics.RowCount = 1;
            this.tlpMetrics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMetrics.Size = new System.Drawing.Size(1084, 152);
            this.tlpMetrics.TabIndex = 1;
            // 
            // panelCardDelays
            // 
            this.panelCardDelays.BackColor = System.Drawing.Color.White;
            this.panelCardDelays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCardDelays.Controls.Add(this.labelMetric4Value);
            this.panelCardDelays.Controls.Add(this.labelMetric4Title);
            this.panelCardDelays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCardDelays.Location = new System.Drawing.Point(810, 10);
            this.panelCardDelays.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelCardDelays.Name = "panelCardDelays";
            this.panelCardDelays.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.panelCardDelays.Size = new System.Drawing.Size(262, 132);
            this.panelCardDelays.TabIndex = 3;
            // 
            // labelMetric4Value
            // 
            this.labelMetric4Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMetric4Value.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.labelMetric4Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.labelMetric4Value.Location = new System.Drawing.Point(9, 48);
            this.labelMetric4Value.Name = "labelMetric4Value";
            this.labelMetric4Value.Size = new System.Drawing.Size(242, 74);
            this.labelMetric4Value.TabIndex = 2;
            this.labelMetric4Value.Text = "2";
            this.labelMetric4Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMetric4Title
            // 
            this.labelMetric4Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelMetric4Title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelMetric4Title.ForeColor = System.Drawing.Color.DimGray;
            this.labelMetric4Title.Location = new System.Drawing.Point(9, 8);
            this.labelMetric4Title.Name = "labelMetric4Title";
            this.labelMetric4Title.Size = new System.Drawing.Size(242, 40);
            this.labelMetric4Title.TabIndex = 1;
            this.labelMetric4Title.Text = "Total Delays:";
            this.labelMetric4Title.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panelCardAbsent
            // 
            this.panelCardAbsent.BackColor = System.Drawing.Color.White;
            this.panelCardAbsent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCardAbsent.Controls.Add(this.labelMetric3Value);
            this.panelCardAbsent.Controls.Add(this.labelMetric3Title);
            this.panelCardAbsent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCardAbsent.Location = new System.Drawing.Point(544, 10);
            this.panelCardAbsent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelCardAbsent.Name = "panelCardAbsent";
            this.panelCardAbsent.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.panelCardAbsent.Size = new System.Drawing.Size(260, 132);
            this.panelCardAbsent.TabIndex = 2;
            // 
            // labelMetric3Value
            // 
            this.labelMetric3Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMetric3Value.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.labelMetric3Value.ForeColor = System.Drawing.Color.Firebrick;
            this.labelMetric3Value.Location = new System.Drawing.Point(9, 48);
            this.labelMetric3Value.Name = "labelMetric3Value";
            this.labelMetric3Value.Size = new System.Drawing.Size(240, 74);
            this.labelMetric3Value.TabIndex = 2;
            this.labelMetric3Value.Text = "3";
            this.labelMetric3Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMetric3Title
            // 
            this.labelMetric3Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelMetric3Title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelMetric3Title.ForeColor = System.Drawing.Color.DimGray;
            this.labelMetric3Title.Location = new System.Drawing.Point(9, 8);
            this.labelMetric3Title.Name = "labelMetric3Title";
            this.labelMetric3Title.Size = new System.Drawing.Size(240, 40);
            this.labelMetric3Title.TabIndex = 1;
            this.labelMetric3Title.Text = "Total Absent:";
            this.labelMetric3Title.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panelCardPresent
            // 
            this.panelCardPresent.BackColor = System.Drawing.Color.White;
            this.panelCardPresent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCardPresent.Controls.Add(this.labelMetric2Value);
            this.panelCardPresent.Controls.Add(this.labelMetric2Title);
            this.panelCardPresent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCardPresent.Location = new System.Drawing.Point(278, 10);
            this.panelCardPresent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelCardPresent.Name = "panelCardPresent";
            this.panelCardPresent.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.panelCardPresent.Size = new System.Drawing.Size(260, 132);
            this.panelCardPresent.TabIndex = 1;
            // 
            // labelMetric2Value
            // 
            this.labelMetric2Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMetric2Value.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.labelMetric2Value.ForeColor = System.Drawing.Color.SeaGreen;
            this.labelMetric2Value.Location = new System.Drawing.Point(9, 48);
            this.labelMetric2Value.Name = "labelMetric2Value";
            this.labelMetric2Value.Size = new System.Drawing.Size(240, 74);
            this.labelMetric2Value.TabIndex = 2;
            this.labelMetric2Value.Text = "45";
            this.labelMetric2Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMetric2Title
            // 
            this.labelMetric2Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelMetric2Title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelMetric2Title.ForeColor = System.Drawing.Color.DimGray;
            this.labelMetric2Title.Location = new System.Drawing.Point(9, 8);
            this.labelMetric2Title.Name = "labelMetric2Title";
            this.labelMetric2Title.Size = new System.Drawing.Size(240, 40);
            this.labelMetric2Title.TabIndex = 1;
            this.labelMetric2Title.Text = "Total Present:";
            this.labelMetric2Title.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panelCardStudents
            // 
            this.panelCardStudents.BackColor = System.Drawing.Color.White;
            this.panelCardStudents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCardStudents.Controls.Add(this.labelMetric1Value);
            this.panelCardStudents.Controls.Add(this.labelMetric1Title);
            this.panelCardStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCardStudents.Location = new System.Drawing.Point(12, 10);
            this.panelCardStudents.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelCardStudents.Name = "panelCardStudents";
            this.panelCardStudents.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.panelCardStudents.Size = new System.Drawing.Size(260, 132);
            this.panelCardStudents.TabIndex = 0;
            // 
            // labelMetric1Value
            // 
            this.labelMetric1Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMetric1Value.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.labelMetric1Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.labelMetric1Value.Location = new System.Drawing.Point(9, 48);
            this.labelMetric1Value.Name = "labelMetric1Value";
            this.labelMetric1Value.Size = new System.Drawing.Size(240, 74);
            this.labelMetric1Value.TabIndex = 1;
            this.labelMetric1Value.Text = "50";
            this.labelMetric1Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMetric1Title
            // 
            this.labelMetric1Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelMetric1Title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelMetric1Title.ForeColor = System.Drawing.Color.DimGray;
            this.labelMetric1Title.Location = new System.Drawing.Point(9, 8);
            this.labelMetric1Title.Name = "labelMetric1Title";
            this.labelMetric1Title.Size = new System.Drawing.Size(240, 40);
            this.labelMetric1Title.TabIndex = 0;
            this.labelMetric1Title.Text = "Total Students:";
            this.labelMetric1Title.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panelActions
            // 
            this.panelActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelActions.Controls.Add(this.flowLayoutPanelActions);
            this.panelActions.Controls.Add(this.labelActionsTitle);
            this.panelActions.Location = new System.Drawing.Point(1104, 8);
            this.panelActions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelActions.Name = "panelActions";
            this.panelActions.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.panelActions.Size = new System.Drawing.Size(268, 308);
            this.panelActions.TabIndex = 2;
            // 
            // flowLayoutPanelActions
            // 
            this.flowLayoutPanelActions.Controls.Add(this.buttonGenerateDailyReport);
            this.flowLayoutPanelActions.Controls.Add(this.buttonGenerateTripSummary);
            this.flowLayoutPanelActions.Controls.Add(this.buttonExportCSV);
            this.flowLayoutPanelActions.Location = new System.Drawing.Point(15, 78);
            this.flowLayoutPanelActions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanelActions.Name = "flowLayoutPanelActions";
            this.flowLayoutPanelActions.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.flowLayoutPanelActions.Size = new System.Drawing.Size(240, 220);
            this.flowLayoutPanelActions.TabIndex = 2;
            // 
            // buttonGenerateDailyReport
            // 
            this.buttonGenerateDailyReport.BackColor = System.Drawing.Color.White;
            this.buttonGenerateDailyReport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonGenerateDailyReport.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonGenerateDailyReport.Location = new System.Drawing.Point(3, 10);
            this.buttonGenerateDailyReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonGenerateDailyReport.Name = "buttonGenerateDailyReport";
            this.buttonGenerateDailyReport.Size = new System.Drawing.Size(225, 75);
            this.buttonGenerateDailyReport.TabIndex = 1;
            this.buttonGenerateDailyReport.Text = "Generate Daily Report (Select Date)";
            this.buttonGenerateDailyReport.UseVisualStyleBackColor = false;
            // 
            // buttonGenerateTripSummary
            // 
            this.buttonGenerateTripSummary.BackColor = System.Drawing.Color.White;
            this.buttonGenerateTripSummary.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonGenerateTripSummary.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonGenerateTripSummary.Location = new System.Drawing.Point(3, 89);
            this.buttonGenerateTripSummary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonGenerateTripSummary.Name = "buttonGenerateTripSummary";
            this.buttonGenerateTripSummary.Size = new System.Drawing.Size(225, 74);
            this.buttonGenerateTripSummary.TabIndex = 2;
            this.buttonGenerateTripSummary.Text = "Generate Trip Summary (Select Trip ID)";
            this.buttonGenerateTripSummary.UseVisualStyleBackColor = false;
            // 
            // buttonExportCSV
            // 
            this.buttonExportCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.buttonExportCSV.FlatAppearance.BorderSize = 0;
            this.buttonExportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExportCSV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonExportCSV.ForeColor = System.Drawing.Color.White;
            this.buttonExportCSV.Location = new System.Drawing.Point(3, 167);
            this.buttonExportCSV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonExportCSV.Name = "buttonExportCSV";
            this.buttonExportCSV.Size = new System.Drawing.Size(225, 44);
            this.buttonExportCSV.TabIndex = 0;
            this.buttonExportCSV.Text = "Export to CSV";
            this.buttonExportCSV.UseVisualStyleBackColor = false;
            // 
            // labelActionsTitle
            // 
            this.labelActionsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelActionsTitle.Location = new System.Drawing.Point(9, 8);
            this.labelActionsTitle.Name = "labelActionsTitle";
            this.labelActionsTitle.Size = new System.Drawing.Size(246, 45);
            this.labelActionsTitle.TabIndex = 1;
            this.labelActionsTitle.Text = "Actions";
            this.labelActionsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelReportsGrid
            // 
            this.panelReportsGrid.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelReportsGrid.Controls.Add(this.dataGridViewReports);
            this.panelReportsGrid.Controls.Add(this.labelRecentReportsTitle);
            this.panelReportsGrid.Location = new System.Drawing.Point(14, 320);
            this.panelReportsGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelReportsGrid.Name = "panelReportsGrid";
            this.panelReportsGrid.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.panelReportsGrid.Size = new System.Drawing.Size(1358, 656);
            this.panelReportsGrid.TabIndex = 3;
            // 
            // dataGridViewReports
            // 
            this.dataGridViewReports.AllowUserToAddRows = false;
            this.dataGridViewReports.AllowUserToDeleteRows = false;
            this.dataGridViewReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewReports.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewReports.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Date,
            this.Type,
            this.Actions});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewReports.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewReports.Location = new System.Drawing.Point(12, 61);
            this.dataGridViewReports.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewReports.Name = "dataGridViewReports";
            this.dataGridViewReports.ReadOnly = true;
            this.dataGridViewReports.RowHeadersWidth = 62;
            this.dataGridViewReports.Size = new System.Drawing.Size(1334, 585);
            this.dataGridViewReports.TabIndex = 2;
            // 
            // ID
            // 
            this.ID.FillWeight = 30F;
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.FillWeight = 50F;
            this.Date.HeaderText = "Date";
            this.Date.MinimumWidth = 8;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.FillWeight = 90F;
            this.Type.HeaderText = "Type";
            this.Type.MinimumWidth = 8;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Actions
            // 
            this.Actions.FillWeight = 50F;
            this.Actions.HeaderText = "Actions";
            this.Actions.MinimumWidth = 8;
            this.Actions.Name = "Actions";
            this.Actions.ReadOnly = true;
            this.Actions.Text = "View";
            // 
            // labelRecentReportsTitle
            // 
            this.labelRecentReportsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelRecentReportsTitle.Location = new System.Drawing.Point(179, 8);
            this.labelRecentReportsTitle.Name = "labelRecentReportsTitle";
            this.labelRecentReportsTitle.Size = new System.Drawing.Size(864, 51);
            this.labelRecentReportsTitle.TabIndex = 1;
            this.labelRecentReportsTitle.Text = "Recent Reports";
            this.labelRecentReportsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserControlReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelReportsGrid);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.tlpMetrics);
            this.Controls.Add(this.panelHeaderInfo);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UserControlReports";
            this.Size = new System.Drawing.Size(1384, 992);
            this.panelHeaderInfo.ResumeLayout(false);
            this.tlpMetrics.ResumeLayout(false);
            this.panelCardDelays.ResumeLayout(false);
            this.panelCardAbsent.ResumeLayout(false);
            this.panelCardPresent.ResumeLayout(false);
            this.panelCardStudents.ResumeLayout(false);
            this.panelActions.ResumeLayout(false);
            this.flowLayoutPanelActions.ResumeLayout(false);
            this.panelReportsGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeaderInfo;
        private System.Windows.Forms.Label labelReportDashboardTitle;
        private System.Windows.Forms.ComboBox comboBoxTrip;
        private System.Windows.Forms.Label labelTripTitle;
        private System.Windows.Forms.Label labelDateTitle;
        private System.Windows.Forms.DateTimePicker dateTimePickerReport;
        private System.Windows.Forms.Label labelReportIDLabel;
        private System.Windows.Forms.Label labelReportIDValue;
        private System.Windows.Forms.TableLayoutPanel tlpMetrics;
        private System.Windows.Forms.Panel panelCardStudents;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Panel panelReportsGrid;
        private System.Windows.Forms.Label labelRecentReportsTitle;
        private System.Windows.Forms.DataGridView dataGridViewReports;
        private System.Windows.Forms.Label labelActionsTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelActions;
        private System.Windows.Forms.Button buttonExportCSV;
        private System.Windows.Forms.Button buttonGenerateDailyReport;
        private System.Windows.Forms.Button buttonGenerateTripSummary;
        private System.Windows.Forms.Panel panelCardDelays;
        private System.Windows.Forms.Label labelMetric4Value;
        private System.Windows.Forms.Label labelMetric4Title;
        private System.Windows.Forms.Panel panelCardAbsent;
        private System.Windows.Forms.Label labelMetric3Value;
        private System.Windows.Forms.Label labelMetric3Title;
        private System.Windows.Forms.Panel panelCardPresent;
        private System.Windows.Forms.Label labelMetric2Value;
        private System.Windows.Forms.Label labelMetric2Title;
        private System.Windows.Forms.Label labelMetric1Value;
        private System.Windows.Forms.Label labelMetric1Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewButtonColumn Actions;
    }
}