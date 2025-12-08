namespace SchoolBusRouteTrack.AdministratorSystem
{
    partial class UserControlStudentRegister
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
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.textBoxGrade = new System.Windows.Forms.TextBox();
            this.labelGrade = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.textBoxRelationship = new System.Windows.Forms.TextBox();
            this.labelRelationship = new System.Windows.Forms.Label();
            this.textBoxGuardianName = new System.Windows.Forms.TextBox();
            this.labelGuardianName = new System.Windows.Forms.Label();
            this.textBoxSpecialCare = new System.Windows.Forms.TextBox();
            this.labelSpecialCare = new System.Windows.Forms.Label();
            this.textBoxSchoolID = new System.Windows.Forms.TextBox();
            this.labelSchoolID = new System.Windows.Forms.Label();
            this.labelPageTittle = new System.Windows.Forms.Label();
            this.buttonStudentSave = new System.Windows.Forms.Button();
            this.buttonStudentClear = new System.Windows.Forms.Button();
            this.listBoxStudents = new System.Windows.Forms.ListBox();
            this.labelErrorName = new System.Windows.Forms.Label();
            this.labelErrorAddress = new System.Windows.Forms.Label();
            this.labelErrorGrade = new System.Windows.Forms.Label();
            this.labelErrorGuardianName = new System.Windows.Forms.Label();
            this.labelErrorRelationship = new System.Windows.Forms.Label();
            this.labelErrorPhone = new System.Windows.Forms.Label();
            this.labelErrorSchoolID = new System.Windows.Forms.Label();
            this.labelErrorSpecialCare = new System.Windows.Forms.Label();
            this.gMapControlStudent = new GMap.NET.WindowsForms.GMapControl();
            this.buttonSearchAddress = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(51, 74);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(47, 16);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(164, 74);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(383, 22);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.Tag = "Name";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(164, 122);
            this.textBoxAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(383, 22);
            this.textBoxAddress.TabIndex = 3;
            this.textBoxAddress.Tag = "Address";
            this.textBoxAddress.TextChanged += new System.EventHandler(this.textBoxAddress_TextChanged);
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(51, 122);
            this.labelAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(61, 16);
            this.labelAddress.TabIndex = 2;
            this.labelAddress.Text = "Address:";
            this.labelAddress.Click += new System.EventHandler(this.labelAddress_Click);
            // 
            // textBoxGrade
            // 
            this.textBoxGrade.Location = new System.Drawing.Point(164, 179);
            this.textBoxGrade.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxGrade.Name = "textBoxGrade";
            this.textBoxGrade.Size = new System.Drawing.Size(128, 22);
            this.textBoxGrade.TabIndex = 5;
            this.textBoxGrade.Tag = "Grade";
            // 
            // labelGrade
            // 
            this.labelGrade.AutoSize = true;
            this.labelGrade.Location = new System.Drawing.Point(51, 179);
            this.labelGrade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGrade.Name = "labelGrade";
            this.labelGrade.Size = new System.Drawing.Size(48, 16);
            this.labelGrade.TabIndex = 4;
            this.labelGrade.Text = "Grade:";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(404, 300);
            this.textBoxPhone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(143, 22);
            this.textBoxPhone.TabIndex = 11;
            this.textBoxPhone.Tag = "Phone";
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(325, 304);
            this.labelPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(49, 16);
            this.labelPhone.TabIndex = 10;
            this.labelPhone.Text = "Phone:";
            // 
            // textBoxRelationship
            // 
            this.textBoxRelationship.Location = new System.Drawing.Point(164, 299);
            this.textBoxRelationship.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRelationship.Name = "textBoxRelationship";
            this.textBoxRelationship.Size = new System.Drawing.Size(143, 22);
            this.textBoxRelationship.TabIndex = 9;
            this.textBoxRelationship.Tag = "Relationship";
            // 
            // labelRelationship
            // 
            this.labelRelationship.AutoSize = true;
            this.labelRelationship.Location = new System.Drawing.Point(51, 308);
            this.labelRelationship.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRelationship.Name = "labelRelationship";
            this.labelRelationship.Size = new System.Drawing.Size(85, 16);
            this.labelRelationship.TabIndex = 8;
            this.labelRelationship.Text = "Relationship:";
            // 
            // textBoxGuardianName
            // 
            this.textBoxGuardianName.Location = new System.Drawing.Point(164, 240);
            this.textBoxGuardianName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxGuardianName.Name = "textBoxGuardianName";
            this.textBoxGuardianName.Size = new System.Drawing.Size(383, 22);
            this.textBoxGuardianName.TabIndex = 7;
            this.textBoxGuardianName.Tag = "GuardianName";
            // 
            // labelGuardianName
            // 
            this.labelGuardianName.AutoSize = true;
            this.labelGuardianName.Location = new System.Drawing.Point(51, 248);
            this.labelGuardianName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGuardianName.Name = "labelGuardianName";
            this.labelGuardianName.Size = new System.Drawing.Size(105, 16);
            this.labelGuardianName.TabIndex = 6;
            this.labelGuardianName.Text = "Guardian Name:";
            // 
            // textBoxSpecialCare
            // 
            this.textBoxSpecialCare.Location = new System.Drawing.Point(164, 363);
            this.textBoxSpecialCare.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSpecialCare.Name = "textBoxSpecialCare";
            this.textBoxSpecialCare.Size = new System.Drawing.Size(383, 22);
            this.textBoxSpecialCare.TabIndex = 15;
            this.textBoxSpecialCare.Tag = "SpecialCare";
            // 
            // labelSpecialCare
            // 
            this.labelSpecialCare.AutoSize = true;
            this.labelSpecialCare.Location = new System.Drawing.Point(51, 367);
            this.labelSpecialCare.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSpecialCare.Name = "labelSpecialCare";
            this.labelSpecialCare.Size = new System.Drawing.Size(88, 16);
            this.labelSpecialCare.TabIndex = 14;
            this.labelSpecialCare.Text = "Special Care:";
            // 
            // textBoxSchoolID
            // 
            this.textBoxSchoolID.Location = new System.Drawing.Point(408, 179);
            this.textBoxSchoolID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSchoolID.Name = "textBoxSchoolID";
            this.textBoxSchoolID.Size = new System.Drawing.Size(139, 22);
            this.textBoxSchoolID.TabIndex = 13;
            this.textBoxSchoolID.Tag = "SchoolID";
            this.textBoxSchoolID.TextChanged += new System.EventHandler(this.textBoxSchoolID_TextChanged);
            this.textBoxSchoolID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSchoolID_KeyPress);
            // 
            // labelSchoolID
            // 
            this.labelSchoolID.AutoSize = true;
            this.labelSchoolID.Location = new System.Drawing.Point(317, 182);
            this.labelSchoolID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSchoolID.Name = "labelSchoolID";
            this.labelSchoolID.Size = new System.Drawing.Size(68, 16);
            this.labelSchoolID.TabIndex = 12;
            this.labelSchoolID.Text = "School ID:";
            // 
            // labelPageTittle
            // 
            this.labelPageTittle.AutoSize = true;
            this.labelPageTittle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPageTittle.Location = new System.Drawing.Point(365, 20);
            this.labelPageTittle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPageTittle.Name = "labelPageTittle";
            this.labelPageTittle.Size = new System.Drawing.Size(207, 25);
            this.labelPageTittle.TabIndex = 18;
            this.labelPageTittle.Text = "Student Registration";
            // 
            // buttonStudentSave
            // 
            this.buttonStudentSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStudentSave.Location = new System.Drawing.Point(743, 612);
            this.buttonStudentSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonStudentSave.Name = "buttonStudentSave";
            this.buttonStudentSave.Size = new System.Drawing.Size(100, 28);
            this.buttonStudentSave.TabIndex = 19;
            this.buttonStudentSave.Text = "Save";
            this.buttonStudentSave.UseVisualStyleBackColor = true;
            this.buttonStudentSave.Click += new System.EventHandler(this.buttonStudentSave_Click);
            // 
            // buttonStudentClear
            // 
            this.buttonStudentClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStudentClear.Location = new System.Drawing.Point(857, 612);
            this.buttonStudentClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonStudentClear.Name = "buttonStudentClear";
            this.buttonStudentClear.Size = new System.Drawing.Size(100, 28);
            this.buttonStudentClear.TabIndex = 20;
            this.buttonStudentClear.Text = "Clear";
            this.buttonStudentClear.UseVisualStyleBackColor = true;
            this.buttonStudentClear.Click += new System.EventHandler(this.buttonStudentClear_Click);
            // 
            // listBoxStudents
            // 
            this.listBoxStudents.FormattingEnabled = true;
            this.listBoxStudents.ItemHeight = 16;
            this.listBoxStudents.Location = new System.Drawing.Point(743, 74);
            this.listBoxStudents.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxStudents.Name = "listBoxStudents";
            this.listBoxStudents.Size = new System.Drawing.Size(353, 532);
            this.listBoxStudents.TabIndex = 21;
            // 
            // labelErrorName
            // 
            this.labelErrorName.AutoSize = true;
            this.labelErrorName.ForeColor = System.Drawing.Color.Red;
            this.labelErrorName.Location = new System.Drawing.Point(160, 102);
            this.labelErrorName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelErrorName.Name = "labelErrorName";
            this.labelErrorName.Size = new System.Drawing.Size(0, 16);
            this.labelErrorName.TabIndex = 22;
            this.labelErrorName.Click += new System.EventHandler(this.labelErrorName_Click);
            // 
            // labelErrorAddress
            // 
            this.labelErrorAddress.AutoSize = true;
            this.labelErrorAddress.ForeColor = System.Drawing.Color.Red;
            this.labelErrorAddress.Location = new System.Drawing.Point(163, 150);
            this.labelErrorAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelErrorAddress.Name = "labelErrorAddress";
            this.labelErrorAddress.Size = new System.Drawing.Size(0, 16);
            this.labelErrorAddress.TabIndex = 23;
            this.labelErrorAddress.Click += new System.EventHandler(this.labelErrorAddress_Click);
            // 
            // labelErrorGrade
            // 
            this.labelErrorGrade.AutoSize = true;
            this.labelErrorGrade.ForeColor = System.Drawing.Color.Red;
            this.labelErrorGrade.Location = new System.Drawing.Point(163, 207);
            this.labelErrorGrade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelErrorGrade.Name = "labelErrorGrade";
            this.labelErrorGrade.Size = new System.Drawing.Size(0, 16);
            this.labelErrorGrade.TabIndex = 24;
            this.labelErrorGrade.Tag = "";
            // 
            // labelErrorGuardianName
            // 
            this.labelErrorGuardianName.AutoSize = true;
            this.labelErrorGuardianName.ForeColor = System.Drawing.Color.Red;
            this.labelErrorGuardianName.Location = new System.Drawing.Point(163, 268);
            this.labelErrorGuardianName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelErrorGuardianName.Name = "labelErrorGuardianName";
            this.labelErrorGuardianName.Size = new System.Drawing.Size(0, 16);
            this.labelErrorGuardianName.TabIndex = 27;
            this.labelErrorGuardianName.Tag = "";
            // 
            // labelErrorRelationship
            // 
            this.labelErrorRelationship.AutoSize = true;
            this.labelErrorRelationship.ForeColor = System.Drawing.Color.Red;
            this.labelErrorRelationship.Location = new System.Drawing.Point(163, 328);
            this.labelErrorRelationship.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelErrorRelationship.Name = "labelErrorRelationship";
            this.labelErrorRelationship.Size = new System.Drawing.Size(0, 16);
            this.labelErrorRelationship.TabIndex = 26;
            // 
            // labelErrorPhone
            // 
            this.labelErrorPhone.AutoSize = true;
            this.labelErrorPhone.ForeColor = System.Drawing.Color.Red;
            this.labelErrorPhone.Location = new System.Drawing.Point(403, 328);
            this.labelErrorPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelErrorPhone.Name = "labelErrorPhone";
            this.labelErrorPhone.Size = new System.Drawing.Size(0, 16);
            this.labelErrorPhone.TabIndex = 25;
            // 
            // labelErrorSchoolID
            // 
            this.labelErrorSchoolID.AutoSize = true;
            this.labelErrorSchoolID.ForeColor = System.Drawing.Color.Red;
            this.labelErrorSchoolID.Location = new System.Drawing.Point(407, 207);
            this.labelErrorSchoolID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelErrorSchoolID.Name = "labelErrorSchoolID";
            this.labelErrorSchoolID.Size = new System.Drawing.Size(0, 16);
            this.labelErrorSchoolID.TabIndex = 30;
            this.labelErrorSchoolID.Tag = "";
            // 
            // labelErrorSpecialCare
            // 
            this.labelErrorSpecialCare.AutoSize = true;
            this.labelErrorSpecialCare.ForeColor = System.Drawing.Color.Red;
            this.labelErrorSpecialCare.Location = new System.Drawing.Point(163, 392);
            this.labelErrorSpecialCare.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelErrorSpecialCare.Name = "labelErrorSpecialCare";
            this.labelErrorSpecialCare.Size = new System.Drawing.Size(0, 16);
            this.labelErrorSpecialCare.TabIndex = 29;
            // 
            // gMapControlStudent
            // 
            this.gMapControlStudent.Bearing = 0F;
            this.gMapControlStudent.CanDragMap = true;
            this.gMapControlStudent.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControlStudent.GrayScaleMode = false;
            this.gMapControlStudent.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControlStudent.LevelsKeepInMemory = 5;
            this.gMapControlStudent.Location = new System.Drawing.Point(164, 424);
            this.gMapControlStudent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gMapControlStudent.MarkersEnabled = true;
            this.gMapControlStudent.MaxZoom = 2;
            this.gMapControlStudent.MinZoom = 2;
            this.gMapControlStudent.MouseWheelZoomEnabled = true;
            this.gMapControlStudent.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControlStudent.Name = "gMapControlStudent";
            this.gMapControlStudent.NegativeMode = false;
            this.gMapControlStudent.PolygonsEnabled = true;
            this.gMapControlStudent.RetryLoadTile = 0;
            this.gMapControlStudent.RoutesEnabled = true;
            this.gMapControlStudent.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControlStudent.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControlStudent.ShowTileGridLines = false;
            this.gMapControlStudent.Size = new System.Drawing.Size(384, 248);
            this.gMapControlStudent.TabIndex = 31;
            this.gMapControlStudent.Zoom = 0D;
            // 
            // buttonSearchAddress
            // 
            this.buttonSearchAddress.Location = new System.Drawing.Point(568, 122);
            this.buttonSearchAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSearchAddress.Name = "buttonSearchAddress";
            this.buttonSearchAddress.Size = new System.Drawing.Size(100, 24);
            this.buttonSearchAddress.TabIndex = 32;
            this.buttonSearchAddress.Text = "Search";
            this.buttonSearchAddress.UseVisualStyleBackColor = true;
            this.buttonSearchAddress.Click += new System.EventHandler(this.buttonSearchAddress_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(857, 648);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(100, 28);
            this.buttonDelete.TabIndex = 33;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEdit.Location = new System.Drawing.Point(743, 648);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(100, 28);
            this.buttonEdit.TabIndex = 34;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // UserControlStudentRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonSearchAddress);
            this.Controls.Add(this.gMapControlStudent);
            this.Controls.Add(this.labelErrorSchoolID);
            this.Controls.Add(this.labelErrorSpecialCare);
            this.Controls.Add(this.labelErrorGuardianName);
            this.Controls.Add(this.labelErrorRelationship);
            this.Controls.Add(this.labelErrorPhone);
            this.Controls.Add(this.labelErrorGrade);
            this.Controls.Add(this.labelErrorAddress);
            this.Controls.Add(this.labelErrorName);
            this.Controls.Add(this.listBoxStudents);
            this.Controls.Add(this.buttonStudentClear);
            this.Controls.Add(this.buttonStudentSave);
            this.Controls.Add(this.labelPageTittle);
            this.Controls.Add(this.textBoxSpecialCare);
            this.Controls.Add(this.labelSpecialCare);
            this.Controls.Add(this.textBoxSchoolID);
            this.Controls.Add(this.labelSchoolID);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.textBoxRelationship);
            this.Controls.Add(this.labelRelationship);
            this.Controls.Add(this.textBoxGuardianName);
            this.Controls.Add(this.labelGuardianName);
            this.Controls.Add(this.textBoxGrade);
            this.Controls.Add(this.labelGrade);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControlStudentRegister";
            this.Size = new System.Drawing.Size(1164, 692);
            this.Load += new System.EventHandler(this.UserControlStudentRegister_Load);
            this.Click += new System.EventHandler(this.HandleClickOutsideListBox);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox textBoxGrade;
        private System.Windows.Forms.Label labelGrade;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.TextBox textBoxRelationship;
        private System.Windows.Forms.Label labelRelationship;
        private System.Windows.Forms.TextBox textBoxGuardianName;
        private System.Windows.Forms.Label labelGuardianName;
        private System.Windows.Forms.TextBox textBoxSpecialCare;
        private System.Windows.Forms.Label labelSpecialCare;
        private System.Windows.Forms.TextBox textBoxSchoolID;
        private System.Windows.Forms.Label labelSchoolID;
        private System.Windows.Forms.Label labelPageTittle;
        private System.Windows.Forms.Button buttonStudentSave;
        private System.Windows.Forms.Button buttonStudentClear;
        private System.Windows.Forms.ListBox listBoxStudents;
        private System.Windows.Forms.Label labelErrorName;
        private System.Windows.Forms.Label labelErrorAddress;
        private System.Windows.Forms.Label labelErrorGrade;
        private System.Windows.Forms.Label labelErrorGuardianName;
        private System.Windows.Forms.Label labelErrorRelationship;
        private System.Windows.Forms.Label labelErrorPhone;
        private System.Windows.Forms.Label labelErrorSchoolID;
        private System.Windows.Forms.Label labelErrorSpecialCare;
        private GMap.NET.WindowsForms.GMapControl gMapControlStudent;
        private System.Windows.Forms.Button buttonSearchAddress;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
    }
}
