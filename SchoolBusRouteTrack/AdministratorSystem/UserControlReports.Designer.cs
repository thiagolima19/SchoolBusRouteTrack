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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeaderInfo = new System.Windows.Forms.Panel();
            this.labelReportDashboardTitle = new System.Windows.Forms.Label();
            this.panelReportsGrid = new System.Windows.Forms.Panel();
            this.labelReportsTitle = new System.Windows.Forms.Label();
            this.dataGridViewReports = new System.Windows.Forms.DataGridView();
            this.panelActions = new System.Windows.Forms.Panel();
            this.buttonExportCSV = new System.Windows.Forms.Button();
            this.buttonGenerateTripSummary = new System.Windows.Forms.Button();
            this.buttonGenerateDailyReport = new System.Windows.Forms.Button();
            this.flowLayoutPanelActions = new System.Windows.Forms.FlowLayoutPanel();
            this.panelHeaderInfo.SuspendLayout();
            this.panelReportsGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).BeginInit();
            this.panelActions.SuspendLayout();
            this.flowLayoutPanelActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeaderInfo
            // 
            this.panelHeaderInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelHeaderInfo.Controls.Add(this.labelReportDashboardTitle);
            this.panelHeaderInfo.Location = new System.Drawing.Point(14, 13);
            this.panelHeaderInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelHeaderInfo.Name = "panelHeaderInfo";
            this.panelHeaderInfo.Padding = new System.Windows.Forms.Padding(9, 8, 9, 0);
            this.panelHeaderInfo.Size = new System.Drawing.Size(504, 137);
            this.panelHeaderInfo.TabIndex = 0;
            // 
            // labelReportDashboardTitle
            // 
            this.labelReportDashboardTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReportDashboardTitle.Location = new System.Drawing.Point(12, 8);
            this.labelReportDashboardTitle.Name = "labelReportDashboardTitle";
            this.labelReportDashboardTitle.Size = new System.Drawing.Size(480, 116);
            this.labelReportDashboardTitle.TabIndex = 0;
            this.labelReportDashboardTitle.Text = "Report Dashboard";
            this.labelReportDashboardTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelReportsGrid
            // 
            this.panelReportsGrid.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelReportsGrid.Controls.Add(this.labelReportsTitle);
            this.panelReportsGrid.Controls.Add(this.dataGridViewReports);
            this.panelReportsGrid.Location = new System.Drawing.Point(14, 167);
            this.panelReportsGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelReportsGrid.Name = "panelReportsGrid";
            this.panelReportsGrid.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.panelReportsGrid.Size = new System.Drawing.Size(1358, 809);
            this.panelReportsGrid.TabIndex = 3;
            // 
            // labelReportsTitle
            // 
            this.labelReportsTitle.AutoSize = true;
            this.labelReportsTitle.Location = new System.Drawing.Point(639, 39);
            this.labelReportsTitle.Name = "labelReportsTitle";
            this.labelReportsTitle.Size = new System.Drawing.Size(51, 20);
            this.labelReportsTitle.TabIndex = 3;
            this.labelReportsTitle.Text = "label1";
            // 
            // dataGridViewReports
            // 
            this.dataGridViewReports.AllowUserToAddRows = false;
            this.dataGridViewReports.AllowUserToDeleteRows = false;
            this.dataGridViewReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewReports.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewReports.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewReports.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewReports.Location = new System.Drawing.Point(12, 61);
            this.dataGridViewReports.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewReports.Name = "dataGridViewReports";
            this.dataGridViewReports.ReadOnly = true;
            this.dataGridViewReports.RowHeadersWidth = 62;
            this.dataGridViewReports.Size = new System.Drawing.Size(1334, 738);
            this.dataGridViewReports.TabIndex = 2;
            // 
            // panelActions
            // 
            this.panelActions.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelActions.Controls.Add(this.flowLayoutPanelActions);
            this.panelActions.Location = new System.Drawing.Point(538, 13);
            this.panelActions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelActions.Name = "panelActions";
            this.panelActions.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.panelActions.Size = new System.Drawing.Size(834, 137);
            this.panelActions.TabIndex = 2;
            // 
            // buttonExportCSV
            // 
            this.buttonExportCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.buttonExportCSV.FlatAppearance.BorderSize = 0;
            this.buttonExportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExportCSV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonExportCSV.ForeColor = System.Drawing.Color.White;
            this.buttonExportCSV.Location = new System.Drawing.Point(513, 10);
            this.buttonExportCSV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonExportCSV.Name = "buttonExportCSV";
            this.buttonExportCSV.Size = new System.Drawing.Size(292, 91);
            this.buttonExportCSV.TabIndex = 0;
            this.buttonExportCSV.Text = "Export to CSV";
            this.buttonExportCSV.UseVisualStyleBackColor = false;
            this.buttonExportCSV.Click += new System.EventHandler(this.buttonExportCSV_Click);
            // 
            // buttonGenerateTripSummary
            // 
            this.buttonGenerateTripSummary.BackColor = System.Drawing.Color.White;
            this.buttonGenerateTripSummary.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonGenerateTripSummary.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonGenerateTripSummary.Location = new System.Drawing.Point(3, 10);
            this.buttonGenerateTripSummary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonGenerateTripSummary.Name = "buttonGenerateTripSummary";
            this.buttonGenerateTripSummary.Size = new System.Drawing.Size(251, 91);
            this.buttonGenerateTripSummary.TabIndex = 2;
            this.buttonGenerateTripSummary.Text = "Generate Trip Summary";
            this.buttonGenerateTripSummary.UseVisualStyleBackColor = false;
            this.buttonGenerateTripSummary.Click += new System.EventHandler(this.buttonGenerateTripSummary_Click);
            // 
            // buttonGenerateDailyReport
            // 
            this.buttonGenerateDailyReport.BackColor = System.Drawing.Color.White;
            this.buttonGenerateDailyReport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonGenerateDailyReport.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonGenerateDailyReport.Location = new System.Drawing.Point(260, 10);
            this.buttonGenerateDailyReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonGenerateDailyReport.Name = "buttonGenerateDailyReport";
            this.buttonGenerateDailyReport.Size = new System.Drawing.Size(247, 91);
            this.buttonGenerateDailyReport.TabIndex = 1;
            this.buttonGenerateDailyReport.Text = "Generate Daily Report";
            this.buttonGenerateDailyReport.UseVisualStyleBackColor = false;
            this.buttonGenerateDailyReport.Click += new System.EventHandler(this.buttonGenerateDailyReport_Click);
            // 
            // flowLayoutPanelActions
            // 
            this.flowLayoutPanelActions.Controls.Add(this.buttonGenerateTripSummary);
            this.flowLayoutPanelActions.Controls.Add(this.buttonGenerateDailyReport);
            this.flowLayoutPanelActions.Controls.Add(this.buttonExportCSV);
            this.flowLayoutPanelActions.Location = new System.Drawing.Point(12, 10);
            this.flowLayoutPanelActions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanelActions.Name = "flowLayoutPanelActions";
            this.flowLayoutPanelActions.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.flowLayoutPanelActions.Size = new System.Drawing.Size(810, 117);
            this.flowLayoutPanelActions.TabIndex = 2;
            // 
            // UserControlReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelReportsGrid);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.panelHeaderInfo);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UserControlReports";
            this.Size = new System.Drawing.Size(1384, 992);
            this.panelHeaderInfo.ResumeLayout(false);
            this.panelReportsGrid.ResumeLayout(false);
            this.panelReportsGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).EndInit();
            this.panelActions.ResumeLayout(false);
            this.flowLayoutPanelActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeaderInfo;
        private System.Windows.Forms.Label labelReportDashboardTitle;
        private System.Windows.Forms.Panel panelReportsGrid;
        private System.Windows.Forms.DataGridView dataGridViewReports;
        private System.Windows.Forms.Label labelReportsTitle;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelActions;
        private System.Windows.Forms.Button buttonGenerateTripSummary;
        private System.Windows.Forms.Button buttonGenerateDailyReport;
        private System.Windows.Forms.Button buttonExportCSV;
    }
}