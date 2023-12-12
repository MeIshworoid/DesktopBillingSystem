using BillingSystem.BusinessLogic.Layer.Repository;
using BillingSystem.Utility;
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
    public partial class IntroForm : Form
    {
        public IntroForm()
        {
            InitializeComponent();
        }

        private readonly UserRepository _userRepository = new UserRepository();

        //properties
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


        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginUser();
        }

        private void LoginUser()
        {
            DataTable dt = _userRepository.GetUserByEmail(Email);

            if (UserExists(Email, Password))
            {
                DataRow row = dt.Rows[0];
                BillingSessionHelper.FirstName = row["FirstName"].ToString();
                BillingSessionHelper.AccountType = row["AccountType"].ToString();
                BillingSessionHelper.UserId = Convert.ToInt32(row["UserId"].ToString());
                BillingSessionHelper.Email = row["Email"].ToString();


                MessageBox.Show("Login Successfull", "Success");
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Credentials", "Warning");
            }
        }

        private bool UserExists(string email,string password)
        {
            DataTable dt = _userRepository.GetUserByEmailAndPassword(email, password);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginUser();
            }
        }
    }
}
