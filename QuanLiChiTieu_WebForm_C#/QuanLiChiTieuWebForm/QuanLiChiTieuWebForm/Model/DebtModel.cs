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
    public class DebtModel
    {
        public static void InsertDebt(SqlConnection con, SqlTransaction trans, DebtEntity debtInfo)
        {
            SqlCommand com = new SqlCommand();
            try
            {
                com.Connection = con;
                com.Transaction = trans;
                com.CommandText = "INSERT INTO [dbo].[DEBT] ([USER_ID],[INCOME_ID],[VALUE_DEBT],[HUMAN_DEBT],[DATE_DEBT],[STATUS_DEBT],[NOTE_DEBT],[PATH_IMG_DEBT]) VALUES (@userId, @spendingId, @valueDebt, @humanDebt, @dateDebt, @statusDebt, @noteDebt, @pathImgDebt)";
                com.Parameters.AddWithValue("@userId", debtInfo.UserId);
                com.Parameters.AddWithValue("@spendingId", debtInfo.IncomeId);
                com.Parameters.AddWithValue("@valueDebt", debtInfo.ValueDebt);
                com.Parameters.AddWithValue("@humanDebt", debtInfo.HumanDebt);
                com.Parameters.AddWithValue("@dateDebt", debtInfo.DateDebt);
                com.Parameters.AddWithValue("@statusDebt", debtInfo.StatusDebt);
                com.Parameters.AddWithValue("@noteDebt", debtInfo.NoteDebt);
                com.Parameters.AddWithValue("@pathImgDebt", debtInfo.PathImgDebt);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetDebtInfo(int userId, SearchCondition searchCondition)
        {
            DataTable debtDt = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                sb.Append(" SELECT [USER_ID] ");
                sb.Append(" ,[DEBT_ID] ");
                sb.Append(" ,[INCOME_ID] ");
                sb.Append(" ,[VALUE_DEBT] ");
                sb.Append(" ,[HUMAN_DEBT] ");
                sb.Append(" ,CONVERT(varchar, [DEBT].[DATE_DEBT], 103) AS [DATE_DEBT] ");
                sb.Append(" ,[STATUS_DEBT] ");
                sb.Append(" ,[NOTE_DEBT] ");
                sb.Append(" ,[DATE_DEBT] AS [DATE_DEBT_SORT] ");
                sb.Append(" ,[PATH_IMG_DEBT] ");
                sb.Append(" ,CONVERT(varchar, [DEBT].[DATE_DEBT_FINISH], 103) AS [DATE_DEBT_FINISH] ");
                sb.Append(" ,[NOTE_DEBT_FINISH] ");
                sb.Append(" ,[PATH_IMG_DEBT_FINISH] ");
                sb.Append(" FROM [dbo].[DEBT] ");
                sb.Append(" WHERE ");
                sb.Append(" [USER_ID] = @UserId");
                sb.Append(" AND YEAR(DATE_DEBT) = @year");
                if (!searchCondition.IsViewAllOfYear)
                {
                    sb.Append(" AND MONTH(DATE_DEBT) = @month");
                }
                if(searchCondition.StatusSearch != "1")
                {
                    sb.Append(" AND [STATUS_DEBT] = @status");
                }
                sb.Append(" AND [HUMAN_DEBT] LIKE @human");
                SqlDataAdapter da = new SqlDataAdapter(sb.ToString(), con);
                da.SelectCommand.Parameters.AddWithValue("@UserId", userId);
                da.SelectCommand.Parameters.AddWithValue("@year", searchCondition.YearSearch);
                if (!searchCondition.IsViewAllOfYear)
                {
                    da.SelectCommand.Parameters.AddWithValue("@month", searchCondition.MonthSearch);
                }
                if(searchCondition.StatusSearch != "1")
                {
                    da.SelectCommand.Parameters.AddWithValue("@status", searchCondition.StatusSearch == "2"? "0" : "1");
                }
                da.SelectCommand.Parameters.AddWithValue("@human", '%' + searchCondition.NameSearch + '%');
                da.SelectCommand.CommandTimeout = 600;
                da.Fill(debtDt);
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

            return debtDt;
        }
    }
}