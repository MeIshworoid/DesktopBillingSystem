using BillingSystem.BusinessLogic.Layer.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillingSystem
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        //object of businesslayer classes
        private readonly UserRepository _userRepository = new UserRepository();

        //property
        public string FirstName
        {
            get
            {
                return txtFirstName.Text;
            }
            set
            {
                txtFirstName.Text = value;
            }
        }

        public string LastName
        {
            get
            {
                return txtLastName.Text;
            }
            set
            {
                txtLastName.Text = value;
            }
        }

        public string Email
        {
            get
            {
                return txtEmail.Text;
            }
            set
            {
                txtEmail.Text = value;
            }
        }

        public string Password
        {
            get
            {
                return txtPassword.Text;
            }
            set
            {
                txtPassword.Text = value;
            }
        }

        public string AccountType
        {
            get
            {
                return ddlAccountType.Text;
            }
            set
            {
                ddlAccountType.Text = value;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void ResetFields()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            ddlAccountType.SelectedIndex = 0;
            
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            ddlAccountType.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IFEmailExists(Email))
            {
                MessageBox.Show("User Already Exists", "Warning");
            }
            else if (AccountType == "Admin")
            {
                MessageBox.Show("Admin Already Exists", "Warning");
            }
            else
            {
                
                int result = _userRepository.CreateNewUser(FirstName, LastName, Email, Password, AccountType);
                if (result > 0)
                {
                    MessageBox.Show("Account Created Successfully", "Information");
                    BackToIntroForm();
                }
                else
                {
                    MessageBox.Show("Failed to Create", "Warning");
                }
            }
           
        }

        private bool IFEmailExists(string email)
        {
            DataTable dt = _userRepository.GetUserByEmail(email);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void BackToIntroForm()
        {
            IntroForm introForm = new IntroForm();
            if (introForm.Visible == true)
            {
                introForm.Hide();
            }
            else
            {
                introForm.Show();
                btnSave.Visible = false;
                btnCancel.Visible = false;
            }
        }
    }
}
