using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolBusRouteTrack.AdministratorSystem
{
    public partial class UserControlStudentRegister : UserControl
    {
        private List<Control> formFields;


        public UserControlStudentRegister()
        {

            InitializeComponent();

            GetFormFields();           
            
        }

        private void GetFormFields ()
        {
            formFields = new List<Control> ();
            formFields.Add(textBoxName);
            formFields.Add(textBoxAddress);
            formFields.Add(textBoxGrade);
            formFields.Add(textBoxGuardianName);
            formFields.Add(textBoxPhone);
            formFields.Add(textBoxRelationship);
            formFields.Add(textBoxSchoolID);
            formFields.Add(textBoxSpecialCare);
            formFields.Add(textBoxStopID);


        }


        private void UserControlStudentRegister_Load(object sender, EventArgs e)
        {

        }

        private bool isFormValid()
        {
            bool isValid = true;          

            foreach (Control control in formFields) 
            {
                Control errorLabel = this.Controls.Find($"labelError{control.Tag}", true).FirstOrDefault();

                if (string.IsNullOrWhiteSpace(control.Text))
                {
                    isValid = false;

                    
                    if (errorLabel != null) 
                    { 
                        errorLabel.Text = $"{control.Tag} is required.";
                    }
                                      
                }
                else if (errorLabel != null)
                {
                    errorLabel.Text = "";
                }
                
            }

            return isValid;
        }

        private void buttonStudentSave_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                string studentName = textBoxName.Text;
                string address = textBoxAddress.Text;
                string grade = textBoxGrade.Text;
                string guardianName = textBoxGuardianName.Text;
                string phone = textBoxPhone.Text;
                string relationship = textBoxRelationship.Text;
                int schoolID = int.Parse(textBoxSchoolID.Text);
                string specialCare = textBoxSpecialCare.Text;
                int stopID = int.Parse(textBoxStopID.Text);

                Student newStudent = new Student(studentName, address, grade, guardianName, relationship, phone, schoolID, specialCare, stopID);

                listBoxStudents.Items.Add(newStudent._name);

                clearForm();
            }
            else
            { 
                MessageBox.Show("Please fill in all required fields!");
            }

        }

        private void clearForm()
        {
            textBoxName.Text = "";
            textBoxAddress.Text = "";
            textBoxGrade.Text = "";
            textBoxGuardianName.Text = "";
            textBoxPhone.Text = "";
            textBoxRelationship.Text = "";
            textBoxSchoolID.Text = "";
            textBoxSpecialCare.Text = "";
            textBoxStopID.Text = "";
        }

        private void buttonStudentClear_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void textBoxSchoolID_TextChanged(object sender, EventArgs e)
        {

        }

        private void isNumericValue(KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void textBoxSchoolID_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumericValue(e);
        }

        private void textBoxStopID_KeyPress(object sender, KeyPressEventArgs e)
        {
            isNumericValue(e);
        }
    }


}
