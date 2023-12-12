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
    public partial class BuyingAndPrinting : Form
    {
        public BuyingAndPrinting()
        {
            InitializeComponent();
        }

        private readonly ProductRepository _productRepository = new ProductRepository();

        private void BuyingAndPrinting_Load(object sender, EventArgs e)
        {
            grdProductList.AutoGenerateColumns = false;
            grdProductList.DataSource = _productRepository.GetAllProducts();
        }

        private void grdProductList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string headerText = grdProductList.Columns[e.ColumnIndex].HeaderText;
            if (headerText == "Select Item")
            {
                
                
            }
        }
    }
}
