using BillingSystem.BusinessLogic.Layer.Repository;
using BillingSystem.BusinessLogic.Layer.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillingSystem
{
    public partial class ManageProduct : Form
    {
        public ManageProduct()
        {
            InitializeComponent();
        }
        
        public int productId { get; set; }
        public string ProdNames
        {
            get
            {
                return txtProductName.Text;
            }
            set
            {
                txtProductName.Text = value;
            }
        }
        public string Prices
        {
            get
            {
                return txtPrice.Text;
            }
            set
            {
                txtPrice.Text = value;
            }
        }
        public string Qty
        {
            get
            {
                return txtQuantity.Text;
            }
            set
            {
                txtQuantity.Text = value;
            }
        }
        public string Categories
        {
            get
            {
                return ddlProductCategory.Text;
            }
            set
            {
                ddlProductCategory.Text = value;
            }
        }




        //refrence
        private readonly ProductRepository _productRepository = new ProductRepository();

        private void ManageProduct_Load(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            LoadProducts();
        }

        private void LoadProducts()
        {
            ddlProductCategory.SelectedIndex = 0;
            grdProduct.AutoGenerateColumns = false;
            grdProduct.DataSource = _productRepository.GetAllProducts();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ProductViewModel model = new ProductViewModel()
                {
                    ProductId = productId,
                    ProductName = ProdNames,
                    ProductCategory = Categories,
                    Quantity = Convert.ToInt32(Qty),
                    Price = Convert.ToDecimal(Prices)
                };
                if (IfProductExists(ProdNames))
                {
                    
                    int quantityOfField = Convert.ToInt32(txtQuantity.Text);
                    DataTable dt = _productRepository.GetAllProducts();
                    foreach (DataRow dr in dt.Rows)
                    {
                        int id = Convert.ToInt32(dr["ProductId"].ToString());
                        productId = id;
                        int dbQuantity = Convert.ToInt32(dr["Quantity"].ToString());
                        int result = quantityOfField + dbQuantity;
                        txtQuantity.Text = Convert.ToString(result);
                    }
                    MessageBox.Show("Stock Added", "Notification");
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    if (btnUpdate.Visible == true)
                    {
                        btnUpdate_Click(sender, e);
                    }
                }
                else
                {
                    CreateProducts(model);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }


        }

        private void CreateProducts(ProductViewModel model)
        {
            int i = _productRepository.CreateProduct(model);
            if (i > 0)
            {
                MessageBox.Show("Product Saved Successfully", "Information");
                LoadProducts();
            }
            else
            {
                MessageBox.Show("Failed to Save Product", "Error");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetControls();

        }

        private void ResetControls()
        {
            txtProductName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            ddlProductCategory.SelectedValue = 0;
        }

        private void grdProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //first get the cellclick value on column and check for it
                string headerText = grdProduct.Columns[e.ColumnIndex].HeaderText;
                if (headerText == "Delete")
                {
                    DeleteProduct(e);
                }
                else if (headerText == "Edit")
                {
                    EditProduct(e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void EditProduct(DataGridViewCellEventArgs e)
        {
            

            var currentRow = grdProduct.Rows[e.RowIndex];

            productId = Convert.ToInt32(currentRow.Cells[0].Value.ToString());
            txtProductName.Text = currentRow.Cells["ProductName"].Value.ToString();
            txtPrice.Text = currentRow.Cells["Price"].Value.ToString();
            txtQuantity.Text = currentRow.Cells["Quantity"].Value.ToString();

            string type = currentRow.Cells["ProductCategory"].Value.ToString();

            var productType = ddlProductCategory.Items;
            for (int i = 0; i < productType.Count; i++)
            {
                if (productType[i].ToString() == type)
                {
                    ddlProductCategory.SelectedIndex = i;
                }
            }
            btnUpdate.Visible = true;
            btnSave.Visible = false;
        }

        private void DeleteProduct(DataGridViewCellEventArgs e)
        {
            var confirmationResult = MessageBox.Show("Are you sure you want to delete?", "Delete Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (confirmationResult == DialogResult.Yes)
            {
                productId = Convert.ToInt32(grdProduct.Rows[e.RowIndex].Cells[0].Value.ToString());
                ProductViewModel model = new ProductViewModel()
                {
                    ProductId = productId
                };
                int result = _productRepository.DeleteProduct(model);
                if (result > 0)
                {
                    LoadProducts();
                    MessageBox.Show("Deleted Successfully", "Notification");
                }
                else
                {
                    MessageBox.Show("Failed to Delete", "Notification");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            string productName = txtProductName.Text;
            string productCategory = ddlProductCategory.Text;
            decimal productPrice = Convert.ToDecimal(txtPrice.Text);
            int productQuantity = Convert.ToInt32(txtQuantity.Text);

            ProductViewModel model = new ProductViewModel()
            {
                ProductId = productId,
                ProductName = productName,
                ProductCategory = productCategory,
                Price = productPrice,
                Quantity = productQuantity
            };

            if (productId > 0)
            {
                int result = _productRepository.UpdateProduct(model);
                if (result > 0)
                {
                    MessageBox.Show("Record Updated Successfully.", "Notification");
                    LoadProducts();
                    ResetControls();
                }
                else
                {
                    MessageBox.Show("Failed to Update Records.", "Notification");
                }
            }
        }
        private bool IfProductExists(string productName)
        {
            DataTable dt = _productRepository.GetProductByProductName(productName);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}




