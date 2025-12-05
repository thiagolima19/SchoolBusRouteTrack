namespace SchoolBusRouteTrack.DriverSystem
{
    partial class UserControlTrip
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
            this.flowTripsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowTripsPanel
            // 
            this.flowTripsPanel.AutoScroll = true;
            this.flowTripsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowTripsPanel.Location = new System.Drawing.Point(0, 0);
            this.flowTripsPanel.Name = "flowTripsPanel";
            this.flowTripsPanel.Padding = new System.Windows.Forms.Padding(20);
            this.flowTripsPanel.Size = new System.Drawing.Size(1262, 765);
            this.flowTripsPanel.TabIndex = 0;
            // 
            // UserControlTrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.flowTripsPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControlTrip";
            this.Size = new System.Drawing.Size(1262, 765);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowTripsPanel;
    }
}
