using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace QuanLiChiTieuWebForm.Model
{
    public class LoginModel
    {
        public static bool CheckLogin(UserInfo userInfo)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            try
            {
                conn.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM [USER_INFO]");
                sb.Append(" WHERE");
                sb.Append(" LOGIN_NAME = @loginName");
                sb.Append(" AND PASS = @pass");
                SqlCommand com = new SqlCommand(sb.ToString(), conn);
                com.Parameters.Add("@loginName", SqlDbType.NVarChar).Value = userInfo.LoginName;
                com.Parameters.Add("@pass", SqlDbType.NVarChar).Value = Common.Common.encode(userInfo.Pass);

                SqlDataReader reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }
    }
}