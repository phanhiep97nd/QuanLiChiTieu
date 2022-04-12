using QuanLiChiTieu.Models;
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
        public static UserInfo GetInfoLogin(string loginName)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            SqlCommand com = new SqlCommand();
            UserInfo userInfo = new UserInfo();
            try
            {
                conn.Open();
                com.Connection = conn;
                com.CommandText = "SELECT * FROM [dbo].[USER_INFO] WHERE [LOGIN_NAME] = @loginNameCheck";
                com.Parameters.AddWithValue("@loginNameCheck", loginName);

                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    userInfo.Id = int.Parse(dr["USER_ID"].ToString());
                    userInfo.Pass = dr["PASS"].ToString();
                    userInfo.EndCodePass = dr["ENCODE_PASS"].ToString();
                    break;
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

            return userInfo;
        }
    }
}