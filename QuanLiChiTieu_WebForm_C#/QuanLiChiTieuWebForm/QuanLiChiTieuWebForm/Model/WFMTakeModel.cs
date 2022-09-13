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
    public class WFMTakeModel
    {
        public static void InsertTake(SqlConnection con, SqlTransaction trans, WFMTakeEntity wfmTakeInfo)
        {
            SqlCommand com = new SqlCommand();
            try
            {
                com.Connection = con;
                com.Transaction = trans;
                com.CommandText = "INSERT INTO [dbo].[WFM_TAKE] ([USER_ID],[INCOME_ID],[VALUE_WFM_TAKE],[HUMAN_WFM_TAKE],[GROUP_WFM_TAKE],[TYPE_WFM_TAKE],[DATE_WFM_TAKE],[STATUS_WFM_TAKE],[NOTE_WFM_TAKE]) "
                    + "VALUES (@userId, @spendingId, @valueTake, @humanTake, @groupTake, @typeTake, @dateTake, @statusTake, @noteTake)";
                com.Parameters.AddWithValue("@userId", wfmTakeInfo.UserId);
                com.Parameters.AddWithValue("@spendingId", wfmTakeInfo.IncomeId);
                com.Parameters.AddWithValue("@valueTake", wfmTakeInfo.ValueTake);
                com.Parameters.AddWithValue("@humanTake", wfmTakeInfo.HumanTake);
                com.Parameters.AddWithValue("@groupTake", wfmTakeInfo.GroupTake);
                com.Parameters.AddWithValue("@typeTake", wfmTakeInfo.TypeTake);
                com.Parameters.AddWithValue("@dateTake", wfmTakeInfo.DateTake);
                com.Parameters.AddWithValue("@statusTake", wfmTakeInfo.StatusTake);
                com.Parameters.AddWithValue("@noteTake", wfmTakeInfo.NoteTake);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetTakeInfo(int userId, SearchCondition searchCondition)
        {
            DataTable takeDt = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                sb.Append(" SELECT [USER_ID] ");
                sb.Append(" ,[WFM_TAKE_ID] ");
                sb.Append(" ,[INCOME_ID] ");
                sb.Append(" ,[VALUE_WFM_TAKE] ");
                sb.Append(" ,[HUMAN_WFM_TAKE] ");
                sb.Append(" ,[GROUP_WFM_TAKE] ");
                sb.Append(" ,[TYPE_WFM_TAKE] ");
                sb.Append(" ,CONVERT(varchar, [WFM_TAKE].[DATE_WFM_TAKE], 103) AS [DATE_WFM_TAKE] ");
                sb.Append(" ,[STATUS_WFM_TAKE] ");
                sb.Append(" ,[NOTE_WFM_TAKE] ");
                sb.Append(" ,[DATE_WFM_TAKE] AS [DATE_WFM_TAKE_SORT] ");
                sb.Append(" ,CONVERT(varchar, [WFM_TAKE].[DATE_WFM_TAKE_FINISH], 103) AS [DATE_WFM_TAKE_FINISH] ");
                sb.Append(" ,[NOTE_WFM_TAKE_FINISH] ");
                sb.Append(" FROM [dbo].[WFM_TAKE] ");
                sb.Append(" WHERE ");
                sb.Append(" [USER_ID] = @UserId");
                sb.Append(" AND YEAR(DATE_WFM_TAKE) = @year");
                if (!searchCondition.IsViewAllOfYear)
                {
                    sb.Append(" AND MONTH(DATE_WFM_TAKE) = @month");
                }
                if (searchCondition.StatusSearch != "1")
                {
                    sb.Append(" AND [STATUS_WFM_TAKE] = @status");
                }
                sb.Append(" AND [HUMAN_WFM_TAKE] LIKE @human");
                SqlDataAdapter da = new SqlDataAdapter(sb.ToString(), con);
                da.SelectCommand.Parameters.AddWithValue("@UserId", userId);
                da.SelectCommand.Parameters.AddWithValue("@year", searchCondition.YearSearch);
                if (!searchCondition.IsViewAllOfYear)
                {
                    da.SelectCommand.Parameters.AddWithValue("@month", searchCondition.MonthSearch);
                }
                if (searchCondition.StatusSearch != "1")
                {
                    da.SelectCommand.Parameters.AddWithValue("@status", searchCondition.StatusSearch == "2" ? "0" : "1");
                }
                da.SelectCommand.Parameters.AddWithValue("@human", '%' + searchCondition.NameSearch + '%');
                da.SelectCommand.CommandTimeout = 600;
                da.Fill(takeDt);
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

            return takeDt;
        }
    }
}