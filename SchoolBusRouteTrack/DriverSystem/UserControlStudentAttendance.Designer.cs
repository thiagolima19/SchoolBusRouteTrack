namespace SchoolBusRouteTrack.DriverSystem
{
    partial class UserControlStudentAttendance
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
            this.labelStudentName = new System.Windows.Forms.Label();
            this.checkBoxPickedUp = new System.Windows.Forms.CheckBox();
            this.checkBoxDroppedOff = new System.Windows.Forms.CheckBox();
            this.checkBoxAbsent = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelStudentName
            // 
            this.labelStudentName.AutoSize = true;
            this.labelStudentName.Location = new System.Drawing.Point(20, 9);
            this.labelStudentName.Name = "labelStudentName";
            this.labelStudentName.Size = new System.Drawing.Size(75, 13);
            this.labelStudentName.TabIndex = 0;
            this.labelStudentName.Text = "Student Name";
            // 
            // checkBoxPickedUp
            // 
            this.checkBoxPickedUp.AutoSize = true;
            this.checkBoxPickedUp.Location = new System.Drawing.Point(190, 7);
            this.checkBoxPickedUp.Name = "checkBoxPickedUp";
            this.checkBoxPickedUp.Size = new System.Drawing.Size(76, 17);
            this.checkBoxPickedUp.TabIndex = 1;
            this.checkBoxPickedUp.Text = "Picked Up";
            this.checkBoxPickedUp.UseVisualStyleBackColor = true;
            // 
            // checkBoxDroppedOff
            // 
            this.checkBoxDroppedOff.AutoSize = true;
            this.checkBoxDroppedOff.Location = new System.Drawing.Point(295, 7);
            this.checkBoxDroppedOff.Name = "checkBoxDroppedOff";
            this.checkBoxDroppedOff.Size = new System.Drawing.Size(84, 17);
            this.checkBoxDroppedOff.TabIndex = 2;
            this.checkBoxDroppedOff.Text = "Dropped Off";
            this.checkBoxDroppedOff.UseVisualStyleBackColor = true;
            // 
            // checkBoxAbsent
            // 
            this.checkBoxAbsent.AutoSize = true;
            this.checkBoxAbsent.Location = new System.Drawing.Point(408, 7);
            this.checkBoxAbsent.Name = "checkBoxAbsent";
            this.checkBoxAbsent.Size = new System.Drawing.Size(59, 17);
            this.checkBoxAbsent.TabIndex = 3;
            this.checkBoxAbsent.Text = "Absent";
            this.checkBoxAbsent.UseVisualStyleBackColor = true;
            // 
            // UserControlStudentAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.checkBoxAbsent);
            this.Controls.Add(this.checkBoxDroppedOff);
            this.Controls.Add(this.checkBoxPickedUp);
            this.Controls.Add(this.labelStudentName);
            this.Name = "UserControlStudentAttendance";
            this.Size = new System.Drawing.Size(500, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStudentName;
        private System.Windows.Forms.CheckBox checkBoxPickedUp;
        private System.Windows.Forms.CheckBox checkBoxDroppedOff;
        private System.Windows.Forms.CheckBox checkBoxAbsent;
    }
}
