using BillingSystem.BusinessLogic.Layer.SQL;
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
    public class UserRepository
    {
        //create new user
        public int CreateNewUser(string firstName,string lastName,string email,string password,string accountType)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@FirstName",firstName),
                new SqlParameter("@LastName",lastName),
                new SqlParameter("@Email",email),
                new SqlParameter("@Password",password),
                new SqlParameter("@AccountType",accountType)
            };

            return BillingDAO.IDU(BillingSQL.sql_SaverUserInfo, CommandType.Text, sqlParameters);
        }

        //get user by user email
        public DataTable GetUserByEmail(string email)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@Email",email)
            };

            return BillingDAO.GetDataTable(BillingSQL.sql_GetUserByEmail, CommandType.Text, sqlParameters);
        }

        //for login
        public DataTable GetUserByEmailAndPassword(string email,string password)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@Email",email),
                new SqlParameter("@Password",password)
            };

            return BillingDAO.GetDataTable(BillingSQL.sql_GetUserByEmailAndPassword, CommandType.Text, sqlParameters);
        }

    }
}
