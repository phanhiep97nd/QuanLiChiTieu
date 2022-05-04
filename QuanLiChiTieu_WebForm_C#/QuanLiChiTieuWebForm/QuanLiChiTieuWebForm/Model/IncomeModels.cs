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
                sb.Append(" SELECT [USER_ID] ");
                sb.Append(" ,[INCOME_ID] ");
                sb.Append(" ,[VALUE_INCOME] ");
                sb.Append(" ,CONVERT(varchar, [INCOME].[DATE_INCOME], 103) AS [DATE_INCOME] ");
                sb.Append(" ,[TYPE_INCOME] ");
                sb.Append(" ,[NOTE_INCOME] ");
                sb.Append(" ,[DATE_INCOME] AS [DATE_INCOME_SORT] ");
                sb.Append(" FROM [dbo].[INCOME] ");
                sb.Append(" WHERE ");
                sb.Append(" [USER_ID] = @UserId");
                sb.Append(" AND YEAR(DATE_INCOME) = @year");
                SqlDataAdapter da = new SqlDataAdapter(sb.ToString(), con);
                da.SelectCommand.Parameters.AddWithValue("@UserId", userId);
                da.SelectCommand.Parameters.AddWithValue("@year", year);
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

        public static long GetListIncomePerMonth(string userId, string month, string year)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            SqlCommand com = new SqlCommand();
            long result = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                com.Connection = con;
                sb.Append(" SELECT SUM(VALUE_INCOME) FROM [dbo].[INCOME] ");
                sb.Append(" WHERE ");
                sb.Append("[USER_ID] = @userId");
                sb.Append(" AND ");
                sb.Append(" MONTH(DATE_INCOME) = @month AND ");
                sb.Append(" YEAR(DATE_INCOME) = @year ");
                com.CommandText = sb.ToString();
                com.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
                com.Parameters.Add("@month", SqlDbType.VarChar).Value = month;
                com.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //dr = com.ExecuteReader();
                object total = com.ExecuteScalar();
                com.Parameters.Clear();
                //while (dr.Read())
                //{
                //    result = Convert.ToInt16(dr.GetValue(0));
                //}
                result = long.Parse(Convert.ToString(total) == "" ? "0" : Convert.ToString(total));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
            return result;
        }

        public static bool UpdateIncome(IncomeEntity incomeInfo)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            SqlCommand com = new SqlCommand();
            int result = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                com.Connection = con;
                sb.Append("UPDATE [dbo].[INCOME]");
                sb.Append(" SET ");
                sb.Append(" [VALUE_INCOME] = @valueIncome");
                sb.Append(", [TYPE_INCOME] = @typeIncome");
                sb.Append(", [DATE_INCOME] = @dateIncome");
                sb.Append(", [NOTE_INCOME] = @noteIncome");
                sb.Append(" WHERE ");
                sb.Append("[INCOME_ID] = @id");
                com.CommandText = sb.ToString();
                com.Parameters.AddWithValue("@valueIncome", incomeInfo.ValueIncome);
                com.Parameters.AddWithValue("@typeIncome", incomeInfo.TypeIncome);
                com.Parameters.AddWithValue("@dateIncome", incomeInfo.DateIncome);
                com.Parameters.AddWithValue("@noteIncome", "".Equals(incomeInfo.NoteIncome) ? "NA" : incomeInfo.NoteIncome);
                com.Parameters.AddWithValue("@id", incomeInfo.IncomeId);
                result = com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result != 0 ? true : false;
        }

        public static bool DeleteIncome(int idIncome)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            SqlCommand com = new SqlCommand();
            int result = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                com.Connection = con;
                sb.Append("DELETE FROM [dbo].[INCOME]");
                sb.Append(" WHERE ");
                sb.Append("[INCOME_ID] = @id");
                com.CommandText = sb.ToString();
                com.Parameters.AddWithValue("@id", idIncome);
                result = com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result != 0 ? true : false;
        }

        public static DataTable GetAllIncome(string userId)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            DataTable dtIncome = new DataTable();
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                sb.Append(" SELECT ");
                sb.Append(" ROW_NUMBER() OVER(ORDER BY [INCOME].[DATE_INCOME]) [ROW_NUM] ");
                sb.Append(" , [USER_INFO].[LOGIN_NAME] ");
                sb.Append(" , [INCOME].[DATE_INCOME] ");
                sb.Append(" , CASE [INCOME].[TYPE_INCOME] ");
                sb.Append(" WHEN '1' THEN N'Tiền lương' ");
                sb.Append(" WHEN '2' THEN N'Thu nhập khác' ");
                sb.Append(" END AS [TYPE_INCOME] ");
                sb.Append(" , [INCOME].[VALUE_INCOME] ");
                sb.Append(" , [INCOME].[NOTE_INCOME] ");
                sb.Append(" FROM [dbo].[INCOME] ");
                sb.Append(" LEFT JOIN [dbo].[USER_INFO] ");
                sb.Append(" ON [INCOME].[USER_ID] = [USER_INFO].[USER_ID] ");
                sb.Append(" WHERE ");
                sb.Append(" [INCOME].[USER_ID] = @UserId");
                sb.Append(" ORDER BY [INCOME].[DATE_INCOME] ");
                SqlDataAdapter da = new SqlDataAdapter(sb.ToString(), con);
                da.SelectCommand.Parameters.AddWithValue("@UserId", userId);
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