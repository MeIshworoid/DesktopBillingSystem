using BillingSystem.BusinessLogic.Layer.SQL;
using BillingSystem.BusinessLogic.Layer.ViewModel;
using BillingSystem.DataAccess.Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.BusinessLogic.Layer.Repository
{
    public class ProductRepository
    {


        //create products
        public int CreateProduct(ProductViewModel model)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ProductName",model.ProductName),
                new SqlParameter("@Quantity",model.Quantity),
                new SqlParameter("@ProductCategory",model.ProductCategory),
                new SqlParameter("@Price",model.Price)
            };
            return BillingDAO.IDU("sp_CreateProduct", CommandType.StoredProcedure, parameters);

        }

        //get all products
        public DataTable GetAllProducts()
        {
            return BillingDAO.GetDataTable("sp_GetAllProducts", CommandType.StoredProcedure);
        }

        //delete product
        public int DeleteProduct(ProductViewModel model)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ProductId",model.ProductId)
            };
            return BillingDAO.IDU(BillingSQL.sql_DeleteProduct, CommandType.Text, parameters);
        }
        
        //update product
        public int UpdateProduct(ProductViewModel model)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ProductId",model.ProductId),
                new SqlParameter("@ProductName",model.ProductName),
                new SqlParameter("@Quantity",model.Quantity),
                new SqlParameter("@ProductCategory",model.ProductCategory),
                new SqlParameter("@Price",model.Price)
            };

            return BillingDAO.IDU(BillingSQL.sql_UpdateProduct, CommandType.Text, parameters);
        }

        //get product by product name
        public DataTable GetProductByProductName(string productName)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ProductName",productName)
            };

            return BillingDAO.GetDataTable(BillingSQL.sql_GetProductByProductName, CommandType.Text, parameters);
        }

        ////get product quantity
        //public DataTable GetQuantity()
        //{
        //    return BillingDAO.GetDataTable(BillingSQL.sql_GetProductQuantity, CommandType.Text);
        //}
    }
}
