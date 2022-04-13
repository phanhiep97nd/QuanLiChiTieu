using QuanLiChiTieu.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
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
	}
}