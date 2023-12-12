using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.BusinessLogic.Layer.SQL
{
    public static class BillingSQL
    {
        public const string sql_SaverUserInfo = @"INSERT INTO BillingUserTable(FirstName,LastName,Email,Password,AccountType)
                                                VALUES(@FirstName,@LastName,@Email,@Password,@AccountType)";
        public const string sql_GetUserByEmail = @"SELECT UserId,FirstName,AccountType,Email From BillingUserTable WHERE Email=@Email";
        public const string sql_GetUserByEmailAndPassword = @"SELECT UserId,FirstName,AccountType,Email FROM BillingUserTable WHERE Email=@Email AND Password=@Password";
        public const string sql_DeleteProduct = "DELETE FROM ProductTable WHERE ProductId=@ProductId";
        public const string sql_UpdateProduct = "UPDATE ProductTable SET ProductName=@ProductName,Quantity=@Quantity,ProductCategory=@ProductCategory,Price=@Price WHERE ProductId=@ProductId";
        public const string sql_GetProductByProductName = @"SELECT ProductId,ProductName,Quantity FROM ProductTable WHERE ProductName=@ProductName";
        //public const string sql_GetProductQuantity = @"SELECT ProductName,Quantity FROM ProductTable WHERE Quantity=@Quantity";
        
    }
}
