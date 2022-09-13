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
    public class WFMGiveModel
    {
        public static void InsertGive(SqlConnection con, SqlTransaction trans, WFMGiveEntity wfmGiveInfo)
        {
            SqlCommand com = new SqlCommand();
            try
            {
                com.Connection = con;
                com.Transaction = trans;
                com.CommandText = "INSERT INTO [dbo].[WFM_GIVE] ([USER_ID],[SPENDING_ID],[VALUE_WFM_GIVE],[HUMAN_WFM_GIVE],[GROUP_WFM_GIVE],[TYPE_WFM_GIVE],[DATE_WFM_GIVE],[STATUS_WFM_GIVE],[NOTE_WFM_GIVE]) "
                    + "VALUES (@userId, @spendingId, @valueGive, @humanGive, @groupGive, @typeGive, @dateGive, @statusGive, @noteGive)";
                com.Parameters.AddWithValue("@userId", wfmGiveInfo.UserId);
                com.Parameters.AddWithValue("@spendingId", wfmGiveInfo.SpendingId);
                com.Parameters.AddWithValue("@valueGive", wfmGiveInfo.ValueGive);
                com.Parameters.AddWithValue("@humanGive", wfmGiveInfo.HumanGive);
                com.Parameters.AddWithValue("@groupGive", wfmGiveInfo.GroupGive);
                com.Parameters.AddWithValue("@typeGive", wfmGiveInfo.TypeGive);
                com.Parameters.AddWithValue("@dateGive", wfmGiveInfo.DateGive);
                com.Parameters.AddWithValue("@statusGive", wfmGiveInfo.StatusGive);
                com.Parameters.AddWithValue("@noteGive", wfmGiveInfo.NoteGive);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetGiveInfo(int userId, SearchCondition searchCondition)
        {
            DataTable giveDt = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                sb.Append(" SELECT [USER_ID] ");
                sb.Append(" ,[WFM_GIVE_ID] ");
                sb.Append(" ,[SPENDING_ID] ");
                sb.Append(" ,[VALUE_WFM_GIVE] ");
                sb.Append(" ,[HUMAN_WFM_GIVE] ");
                sb.Append(" ,[GROUP_WFM_GIVE] ");
                sb.Append(" ,[TYPE_WFM_GIVE] ");
                sb.Append(" ,CONVERT(varchar, [WFM_GIVE].[DATE_WFM_GIVE], 103) AS [DATE_WFM_GIVE] ");
                sb.Append(" ,[STATUS_WFM_GIVE] ");
                sb.Append(" ,[NOTE_WFM_GIVE] ");
                sb.Append(" ,[DATE_WFM_GIVE] AS [DATE_WFM_GIVE_SORT] ");
                sb.Append(" ,CONVERT(varchar, [WFM_GIVE].[DATE_WFM_GIVE_FINISH], 103) AS [DATE_WFM_GIVE_FINISH] ");
                sb.Append(" ,[NOTE_WFM_GIVE_FINISH] ");
                sb.Append(" FROM [dbo].[WFM_GIVE] ");
                sb.Append(" WHERE ");
                sb.Append(" [USER_ID] = @UserId");
                sb.Append(" AND YEAR(DATE_WFM_GIVE) = @year");
                if (!searchCondition.IsViewAllOfYear)
                {
                    sb.Append(" AND MONTH(DATE_WFM_GIVE) = @month");
                }
                if (searchCondition.StatusSearch != "1")
                {
                    sb.Append(" AND [STATUS_WFM_GIVE] = @status");
                }
                sb.Append(" AND [HUMAN_WFM_GIVE] LIKE @human");
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
                da.Fill(giveDt);
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

            return giveDt;
        }
    }
}