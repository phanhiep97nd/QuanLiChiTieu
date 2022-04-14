using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLiChiTieu.Models
{
    public class SpendingModel
    {
        internal static bool ClickCreateSpending(SpendingEntity spendingInfo)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            SqlCommand com = new SqlCommand();
            UserInfo userInfo = new UserInfo();
            int result = 0;
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "INSERT INTO [dbo].[SPENDING] ([USER_ID],[VALUE_SPENDING],[TYPE_SPENDING],[DATE_SPENDING],[NOTE_SPENDING]) VALUES (@userId, @valueSpending, @typeSpending, @dateSpending, @noteSpending)";
                com.Parameters.AddWithValue("@userId", spendingInfo.UserId);
                com.Parameters.AddWithValue("@valueSpending", spendingInfo.ValueSpending);
                com.Parameters.AddWithValue("@typeSpending", spendingInfo.TypeSpending);
                com.Parameters.AddWithValue("@dateSpending", spendingInfo.DateSpending);
                com.Parameters.AddWithValue("@noteSpending", "".Equals(spendingInfo.NoteSpending) ? "NA" : spendingInfo.NoteSpending);
                result = com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result != 0 ? true : false;
        }

        internal static DataTable GetSpendingInfo(int userId, string year)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            DataTable dtSpending = new DataTable();
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                sb.Append(" SELECT * FROM [dbo].[SPENDING] ");
                sb.Append(" WHERE ");
                sb.Append(" [USER_ID] = @UserId");
                sb.Append(" AND YEAR(DATE_SPENDING) = @year");
                SqlDataAdapter da = new SqlDataAdapter(sb.ToString(), con);
                da.SelectCommand.Parameters.Add("@UserId", userId);
                da.SelectCommand.Parameters.Add("@year", year);
			    da.SelectCommand.CommandTimeout = 600;
                da.Fill(dtSpending);
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
            return dtSpending;
        }

        internal static int UpdateSpending(SqlConnection con, SqlCommand com, SpendingEntity SpendingInfo)
        {
            int result = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                com.Connection = con;
                sb.Append("UPDATE [dbo].[SPENDING]");
                sb.Append(" SET ");
                sb.Append(" [VALUE_SPENDING] = @valueSpending");
                sb.Append(", [TYPE_SPENDING] = @typeSpending");
                sb.Append(", [DATE_SPENDING] = @dateSpending");
                sb.Append(", [NOTE_SPENDING] = @noteSpending");
                sb.Append(" WHERE ");
                sb.Append("[SPENDING_ID] = @id");
                com.CommandText = sb.ToString();
                com.Parameters.AddWithValue("@valueSpending", SpendingInfo.ValueSpending);
                com.Parameters.AddWithValue("@typeSpending", SpendingInfo.TypeSpending);
                com.Parameters.AddWithValue("@dateSpending", SpendingInfo.DateSpending);
                com.Parameters.AddWithValue("@noteSpending", "".Equals(SpendingInfo.NoteSpending) ? "NA" : SpendingInfo.NoteSpending);
                com.Parameters.AddWithValue("@id", SpendingInfo.SpendingId);
                result = com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
