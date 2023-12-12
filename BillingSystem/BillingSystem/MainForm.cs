using BillingSystem.BusinessLogic.Layer.Repository;
using BillingSystem.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillingSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void introductionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Nobody3522");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUserInfo.Text = string.Format("UserName: {0}, Role: {1}, UserId: {2}", BillingSessionHelper.FirstName, BillingSessionHelper.AccountType, BillingSessionHelper.UserId);
            if (BillingSessionHelper.AccountType=="Admin")
            {

            }
            else
            {
                usersToolStripMenuItem.Visible = false;
            }
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageUser manageUser = new ManageUser();
            manageUser.MdiParent = this;
            manageUser.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageProduct manageProduct = new ManageProduct();
            manageProduct.MdiParent = this;
            manageProduct.Show();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuyingAndPrinting buyingAndPrinting = new BuyingAndPrinting();
            buyingAndPrinting.MdiParent = this;
            buyingAndPrinting.Show();
        }
    }
}
