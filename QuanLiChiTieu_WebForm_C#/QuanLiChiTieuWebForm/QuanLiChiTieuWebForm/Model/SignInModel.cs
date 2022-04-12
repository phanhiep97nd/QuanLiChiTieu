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
    public class SignInModel
    {
        public static bool SignIn(UserInfo userInfo)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            try
            {
                conn.Open();
                SqlCommand com = new SqlCommand();
                com.Connection = conn;
                com.CommandText = "INSERT INTO [dbo].[USER_INFO] ([LOGIN_NAME],[PASS],[ENCODE_PASS],[LOGIN_TIME],[LOGIN_STATUS]) VALUES (@loginName, @pass, @encodePass, @loginTime, @statusTime)";
                //com.Parameters.AddWithValue("@userId", userInfo.Id);
                com.Parameters.AddWithValue("@loginName", userInfo.LoginName);
                string encodeKey = DateTime.Now.ToString();
                string encodePass = Common.Common.encode(userInfo.Pass, encodeKey);
                com.Parameters.AddWithValue("@pass", encodePass);
                com.Parameters.AddWithValue("@encodePass", encodeKey);
                com.Parameters.AddWithValue("@loginTime", encodeKey);
                com.Parameters.AddWithValue("@statusTime", 0);

                com.ExecuteNonQuery();

                result = true;
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

        public static bool CheckExistLoginName(string loginName)
        {
            bool check = false;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            try
            {
                conn.Open();
                SqlCommand com = new SqlCommand();
                com.Connection = conn;
                com.CommandText = "SELECT COUNT(*) FROM [dbo].[USER_INFO] WHERE [LOGIN_NAME] = @loginName ";
                com.Parameters.AddWithValue("@loginName", loginName);

                int count = Convert.ToInt32(com.ExecuteScalar());
                if (count != 0)
                {
                    check = true;
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

            return check;
        }
    }
}