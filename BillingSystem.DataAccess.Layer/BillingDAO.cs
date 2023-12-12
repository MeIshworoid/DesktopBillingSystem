using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BillingSystem.DataAccess.Layer
{
    public class BillingDAO
    {
        //for sqlconnection
        private static SqlConnection GetSqlConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["billingConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
            return sqlConnection;
        }

        //for insert,delete and update
        public static int IDU(string sql,CommandType cmdType, SqlParameter[] sqlParameters)
        {
            
            using(SqlConnection sqlConnection = GetSqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = sqlConnection;
                    cmd.CommandText = sql;
                    cmd.CommandType = cmdType;
                    if (sqlParameters != null)
                    {
                        cmd.Parameters.AddRange(sqlParameters);
                    }

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        //Get all data
        public static DataTable GetDataTable(string sql,CommandType cmdType, SqlParameter[] sqlParameters = null)
        {
            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = sqlConnection;
                    cmd.CommandText = sql;
                    cmd.CommandType = cmdType;
                    if (sqlParameters != null)
                    {
                        cmd.Parameters.AddRange(sqlParameters);
                    }
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);

                    return dt;
                }
            }
        }
    }
}
