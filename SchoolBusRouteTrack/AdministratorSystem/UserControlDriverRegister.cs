using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolBusRouteTrack.AdministratorSystem
{

    public partial class UserControlDriverRegister : UserControl
    {
        private List<Control> formFields;

        public UserControlDriverRegister()
        {
            InitializeComponent();

            GetFormFields();

        }

        private void GetFormFields()
        {
            formFields = new List<Control>();
            formFields.Add(textBoxName);
            formFields.Add(textBoxAddress);
            formFields.Add(textBoxPhone);
            formFields.Add(textBoxAssignedRoute);
            
        }



        private void UserControlDriverRegister_Load(object sender, EventArgs e)
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

        private void clearForm()
        {
            textBoxName.Text = "";
            textBoxAddress.Text = "";
            textBoxPhone.Text = "";
            textBoxAssignedRoute.Text = "";
        }

        private void buttonDriverSave_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                string name = textBoxName.Text;
                string address = textBoxAddress.Text;
                string phoneNumber = textBoxPhone.Text;
                string assignedRoute = textBoxAssignedRoute.Text;
                Driver newDriver = new Driver(name, address, phoneNumber, assignedRoute);
                
                listBoxDriver.Items.Add(newDriver._name);

                clearForm();
            }
            else
            {
                MessageBox.Show("Please correct the errors in the form.", "Form Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDriverClear_Click(object sender, EventArgs e)
        {
            clearForm();
        }
    }
}
