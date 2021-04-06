using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text;

namespace QuanLiChiTieu.Models
{
    public class SignIn
    {
        internal static void ClickSignIn(SqlConnection con, SqlCommand com, UserInfo userInfo)
        {
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "INSERT INTO [dbo].[USER_INFO] ([LOGIN_NAME],[PASS],[ENCODE_PASS],[LOGIN_TIME],[LOGIN_STATUS]) VALUES (@loginName, @pass, @encodePass, @loginTime, @statusTime)";
                //com.Parameters.AddWithValue("@userId", userInfo.Id);
                com.Parameters.AddWithValue("@loginName", userInfo.LoginName);
                string encodeKey = DateTime.Now.ToString();
                string encodePass = EncodePass.encode(userInfo.Pass, encodeKey);
                com.Parameters.AddWithValue("@pass", encodePass);
                com.Parameters.AddWithValue("@encodePass", encodeKey);
                com.Parameters.AddWithValue("@loginTime", encodeKey);
                com.Parameters.AddWithValue("@statusTime", 0);
                com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static Boolean IsExistLoginName(SqlConnection con, SqlCommand com, SqlDataReader dr, string loginName)
        {
            bool check = false;
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT * FROM [dbo].[USER_INFO] WHERE [LOGIN_NAME] = @loginNameCheck";
                com.Parameters.AddWithValue("@loginNameCheck", loginName);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["LOGIN_NAME"].ToString() != "")
                    {
                        check = true;
                    }
                    else
                    {
                        check = false;
                    }
                }
                con.Close();
                return check;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
