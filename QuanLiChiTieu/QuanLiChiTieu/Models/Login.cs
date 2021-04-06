using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiChiTieu.Models
{
    public class Login
    {
        internal static UserInfo GetInfoLogin(SqlConnection con, SqlCommand com, SqlDataReader dr, string loginName)
        {
            UserInfo userInfo = new UserInfo();
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT * FROM [dbo].[USER_INFO] WHERE [LOGIN_NAME] = @loginNameCheck";
                com.Parameters.AddWithValue("@loginNameCheck", loginName);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    userInfo.Id = int.Parse(dr["USER_ID"].ToString());
                    userInfo.Pass = dr["PASS"].ToString();
                    userInfo.EndCodePass = dr["ENCODE_PASS"].ToString();
                    break;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userInfo;
        }

        internal static void changeLoginStatus(SqlConnection con, SqlCommand com, int userId, bool isLogin)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("UPDATE [dbo].[USER_INFO] SET [LOGIN_STATUS] = @loginStatus WHERE [USER_ID] = @userId;");
                if (isLogin)
                {
                    sb.Append("UPDATE [dbo].[USER_INFO] SET [LOGIN_TIME] = @loginTime WHERE [USER_ID] = @userId;");
                }
                con.Open();
                com.Connection = con;
                com.CommandText = sb.ToString();
                com.Parameters.AddWithValue("@loginStatus", isLogin ? 1 : 0);
                if (isLogin)
                {
                    com.Parameters.AddWithValue("@loginTime", DateTime.Now);
                }
                com.Parameters.AddWithValue("@userId", userId);
                com.ExecuteNonQuery();
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
