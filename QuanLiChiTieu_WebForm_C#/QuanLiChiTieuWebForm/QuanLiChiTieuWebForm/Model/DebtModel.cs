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
                if (searchCondition.StatusSearch != "1")
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
                if (searchCondition.StatusSearch != "1")
                {
                    da.SelectCommand.Parameters.AddWithValue("@status", searchCondition.StatusSearch == "2" ? "0" : "1");
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

        public static bool DeleteDebt(int idDebt)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            SqlCommand com = new SqlCommand();
            int result = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                com.Connection = con;
                sb.Append("DELETE FROM [dbo].[DEBT]");
                sb.Append(" WHERE ");
                sb.Append("[DEBT_ID] = @id");
                com.CommandText = sb.ToString();
                com.Parameters.AddWithValue("@id", idDebt);
                result = com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result != 0 ? true : false;
        }

        public static DataTable GetDebtById(int debtId)
        {
            DataTable debtDt = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                sb.Append(" SELECT * ");
                sb.Append(" FROM [dbo].[DEBT] ");
                sb.Append(" WHERE ");
                sb.Append(" [DEBT_ID] = @DebtId");
                SqlDataAdapter da = new SqlDataAdapter(sb.ToString(), con);
                da.SelectCommand.Parameters.AddWithValue("@DebtId", debtId);
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

        public static bool DeleteImgDebt(int idEdit, bool isFinishEdit)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            SqlCommand com = new SqlCommand();
            int result = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                com.Connection = con;
                sb.Append("UPDATE [dbo].[DEBT]");
                sb.Append(" SET ");
                if (isFinishEdit)
                {
                    sb.Append(" [PATH_IMG_DEBT_FINISH] = '' ");
                }
                else
                {
                    sb.Append(" [PATH_IMG_DEBT] = '' ");
                }
                sb.Append(" WHERE ");
                sb.Append("[DEBT_ID] = @idEdit");
                com.CommandText = sb.ToString();
                com.Parameters.AddWithValue("@idEdit", idEdit);
                result = com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result != 0 ? true : false;
        }

        public static bool UpdateDebt(DebtEntity debtInfo)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            SqlCommand com = new SqlCommand();
            int result = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                com.Connection = con;
                sb.Append("UPDATE [dbo].[DEBT]");
                sb.Append(" SET ");
                sb.Append(" [DATE_DEBT] = @dateDebt");
                sb.Append(", [HUMAN_DEBT] = @humanDebt");
                sb.Append(", [VALUE_DEBT] = @valueDebt");
                sb.Append(", [NOTE_DEBT] = @noteDebt");
                if (debtInfo.PathImgDebt != string.Empty)
                {
                    sb.Append(", [PATH_IMG_DEBT] = @pathImgDebt");
                }
                sb.Append(", [STATUS_DEBT] = @statusDebt");
                if (debtInfo.StatusDebt == "1")
                {
                    sb.Append(", [DATE_DEBT_FINISH] = @dateDebtFinish");
                    sb.Append(", [NOTE_DEBT_FINISH] = @noteDebtFinish");
                    if (debtInfo.PathImgDebtFinish != string.Empty)
                    {
                        sb.Append(", [PATH_IMG_DEBT_FINISH] = @pathImgDebtFinish");
                    }
                }
                sb.Append(" WHERE ");
                sb.Append("[DEBT_ID] = @id");
                com.CommandText = sb.ToString();
                com.Parameters.AddWithValue("@dateDebt", debtInfo.DateDebt);
                com.Parameters.AddWithValue("@humanDebt", debtInfo.HumanDebt);
                com.Parameters.AddWithValue("@valueDebt", debtInfo.ValueDebt);
                com.Parameters.AddWithValue("@noteDebt", debtInfo.NoteDebt);
                if (debtInfo.PathImgDebt != string.Empty)
                {
                    com.Parameters.AddWithValue("@pathImgDebt", debtInfo.PathImgDebt);
                }
                com.Parameters.AddWithValue("@statusDebt", debtInfo.StatusDebt);
                if (debtInfo.StatusDebt == "1")
                {
                    com.Parameters.AddWithValue("@dateDebtFinish", debtInfo.DateDebtFinish);
                    com.Parameters.AddWithValue("@noteDebtFinish", debtInfo.NoteDebtFinish);
                    if (debtInfo.PathImgDebtFinish != string.Empty)
                    {
                        com.Parameters.AddWithValue("@pathImgDebtFinish", debtInfo.PathImgDebtFinish);
                    }
                }
                com.Parameters.AddWithValue("@id", debtInfo.DebtId1);
                result = com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result != 0 ? true : false;
        }

        public static DataTable GetAllDebt(string userId)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            DataTable dtIncome = new DataTable();
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                sb.Append(" SELECT ");
                sb.Append(" ROW_NUMBER() OVER(ORDER BY [DEBT].[DATE_DEBT]) [ROW_NUM] ");
                sb.Append(" , [USER_INFO].[LOGIN_NAME] ");
                sb.Append(" , [DEBT].[DATE_DEBT] AS [NGAY_VAY] ");
                sb.Append(" , [DEBT].[HUMAN_DEBT] AS [NGUOI_CHO_VAY] ");
                sb.Append(" , [DEBT].[VALUE_DEBT] AS [SO_TIEN] ");
                sb.Append(" , [DEBT].[NOTE_DEBT] AS [GHI_CHU] ");
                sb.Append(" , CASE [DEBT].[STATUS_DEBT] ");
                sb.Append(" WHEN '1' THEN N'✓Đã trả' ");
                sb.Append(" WHEN '0' THEN N'𐄂Chưa trả' ");
                sb.Append(" END AS [TRANG_THAI] ");
                sb.Append(" FROM [dbo].[DEBT] ");
                sb.Append(" LEFT JOIN [dbo].[USER_INFO] ");
                sb.Append(" ON [DEBT].[USER_ID] = [USER_INFO].[USER_ID] ");
                sb.Append(" WHERE ");
                sb.Append(" [DEBT].[USER_ID] = @UserId");
                sb.Append(" ORDER BY [DEBT].[DATE_DEBT] ");
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