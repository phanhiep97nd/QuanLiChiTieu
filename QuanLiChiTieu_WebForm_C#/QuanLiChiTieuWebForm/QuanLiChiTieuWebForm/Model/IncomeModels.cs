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
	public class IncomeModels
	{
		internal static bool ClickCreateIncome(IncomeEntity incomeInfo)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            SqlCommand com = new SqlCommand();
            UserInfo userInfo = new UserInfo();
            int result = 0;
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "INSERT INTO [dbo].[INCOME] ([USER_ID],[VALUE_INCOME],[TYPE_INCOME],[DATE_INCOME],[NOTE_INCOME]) VALUES (@userId, @valueIncome, @typeIncome, @dateIncome, @noteIncome)";
                com.Parameters.AddWithValue("@userId", incomeInfo.UserId);
                com.Parameters.AddWithValue("@valueIncome", incomeInfo.ValueIncome);
                com.Parameters.AddWithValue("@typeIncome", incomeInfo.TypeIncome);
                com.Parameters.AddWithValue("@dateIncome", incomeInfo.DateIncome);
                com.Parameters.AddWithValue("@noteIncome", "".Equals(incomeInfo.NoteIncome) ? "NA" : incomeInfo.NoteIncome);
                result = com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result != 0 ? true : false;
        }

        internal static DataTable GetIncomeInfo(int userId, string year)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            DataTable dtIncome = new DataTable();
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                sb.Append(" SELECT * FROM [dbo].[INCOME] ");
                sb.Append(" WHERE ");
                sb.Append(" [USER_ID] = @UserId");
                sb.Append(" AND YEAR(DATE_INCOME) = @year");
                SqlDataAdapter da = new SqlDataAdapter(sb.ToString(), con);
                da.SelectCommand.Parameters.Add("@UserId", userId);
                da.SelectCommand.Parameters.Add("@year", year);
			    da.SelectCommand.CommandTimeout = 600;
                da.Fill(dtIncome);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
				{
					con.Close();
				}
            }
            return dtIncome;
        }
	}
}