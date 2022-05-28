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
    public class LoanModel
    {
        public static void InsertLoan(SqlConnection con, SqlTransaction trans, LoanEntity loanInfo)
        {
            SqlCommand com = new SqlCommand();
            try
            {
                com.Connection = con;
                com.Transaction = trans;
                com.CommandText = "INSERT INTO [dbo].[LOAN] ([USER_ID],[SPENDING_ID],[VALUE_LOAN],[HUMAN_LOAN],[DATE_LOAN],[STATUS_LOAN],[NOTE_LOAN],[PATH_IMG_LOAN]) VALUES (@userId, @spendingId, @valueLoan, @humanLoan, @dateLoan, @statusLoan, @noteLoan, @pathImgLoan)";
                com.Parameters.AddWithValue("@userId", loanInfo.UserId);
                com.Parameters.AddWithValue("@spendingId", loanInfo.SpendingId);
                com.Parameters.AddWithValue("@valueLoan", loanInfo.ValueLoan);
                com.Parameters.AddWithValue("@humanLoan", loanInfo.HumanLoan);
                com.Parameters.AddWithValue("@dateLoan", loanInfo.DateLoan);
                com.Parameters.AddWithValue("@statusLoan", loanInfo.StatusLoan);
                com.Parameters.AddWithValue("@noteLoan", loanInfo.NoteLoan);
                com.Parameters.AddWithValue("@pathImgLoan", loanInfo.PathImgLoan);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetLoanInfo(int userId, SearchCondition searchCondition)
        {
            DataTable loanDt = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                sb.Append(" SELECT [USER_ID] ");
                sb.Append(" ,[LOAN_ID] ");
                sb.Append(" ,[SPENDING_ID] ");
                sb.Append(" ,[VALUE_LOAN] ");
                sb.Append(" ,[HUMAN_LOAN] ");
                sb.Append(" ,CONVERT(varchar, [LOAN].[DATE_LOAN], 103) AS [DATE_LOAN] ");
                sb.Append(" ,[STATUS_LOAN] ");
                sb.Append(" ,[NOTE_LOAN] ");
                sb.Append(" ,[DATE_LOAN] AS [DATE_LOAN_SORT] ");
                sb.Append(" ,[PATH_IMG_LOAN] ");
                sb.Append(" ,CONVERT(varchar, [LOAN].[DATE_LOAN_FINISH], 103) AS [DATE_LOAN_FINISH] ");
                sb.Append(" ,[NOTE_LOAN_FINISH] ");
                sb.Append(" ,[PATH_IMG_LOAN_FINISH] ");
                sb.Append(" FROM [dbo].[LOAN] ");
                sb.Append(" WHERE ");
                sb.Append(" [USER_ID] = @UserId");
                sb.Append(" AND YEAR(DATE_LOAN) = @year");
                if (!searchCondition.IsViewAllOfYear)
                {
                    sb.Append(" AND MONTH(DATE_LOAN) = @month");
                }
                if (searchCondition.StatusSearch != "1")
                {
                    sb.Append(" AND [STATUS_LOAN] = @status");
                }
                sb.Append(" AND [HUMAN_LOAN] LIKE @human");
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
                da.Fill(loanDt);
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

            return loanDt;
        }

        public static bool DeleteLoan(int idLoan)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            SqlCommand com = new SqlCommand();
            int result = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                com.Connection = con;
                sb.Append("DELETE FROM [dbo].[LOAN]");
                sb.Append(" WHERE ");
                sb.Append("[LOAN_ID] = @id");
                com.CommandText = sb.ToString();
                com.Parameters.AddWithValue("@id", idLoan);
                result = com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result != 0 ? true : false;
        }

        public static DataTable GetLoanById(int loanId)
        {
            DataTable loanDt = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                sb.Append(" SELECT * ");
                sb.Append(" FROM [dbo].[LOAN] ");
                sb.Append(" WHERE ");
                sb.Append(" [LOAN_ID] = @LoanId");
                SqlDataAdapter da = new SqlDataAdapter(sb.ToString(), con);
                da.SelectCommand.Parameters.AddWithValue("@LoanId", loanId);
                da.SelectCommand.CommandTimeout = 600;
                da.Fill(loanDt);
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

            return loanDt;
        }

        public static bool DeleteImgLoan(int idEdit, bool isFinishEdit)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            SqlCommand com = new SqlCommand();
            int result = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                com.Connection = con;
                sb.Append("UPDATE [dbo].[LOAN]");
                sb.Append(" SET ");
                if (isFinishEdit)
                {
                    sb.Append(" [PATH_IMG_LOAN_FINISH] = '' ");
                }
                else
                {
                    sb.Append(" [PATH_IMG_LOAN] = '' ");
                }
                sb.Append(" WHERE ");
                sb.Append("[LOAN_ID] = @idEdit");
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

        public static bool UpdateLoan(LoanEntity loanInfo)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            SqlCommand com = new SqlCommand();
            int result = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                com.Connection = con;
                sb.Append("UPDATE [dbo].[LOAN]");
                sb.Append(" SET ");
                sb.Append(" [DATE_LOAN] = @dateLoan");
                sb.Append(", [HUMAN_LOAN] = @humanLoan");
                sb.Append(", [VALUE_LOAN] = @valueLoan");
                sb.Append(", [NOTE_LOAN] = @noteLoan");
                if (loanInfo.PathImgLoan != string.Empty)
                {
                    sb.Append(", [PATH_IMG_LOAN] = @pathImgLoan");
                }
                sb.Append(", [STATUS_LOAN] = @statusLoan");
                if (loanInfo.StatusLoan == "1")
                {
                    sb.Append(", [DATE_LOAN_FINISH] = @dateLoanFinish");
                    sb.Append(", [NOTE_LOAN_FINISH] = @noteLoanFinish");
                    if (loanInfo.PathImgLoanFinish != string.Empty)
                    {
                        sb.Append(", [PATH_IMG_LOAN_FINISH] = @pathImgLoanFinish");
                    }
                }
                sb.Append(" WHERE ");
                sb.Append("[LOAN_ID] = @id");
                com.CommandText = sb.ToString();
                com.Parameters.AddWithValue("@dateLoan", loanInfo.DateLoan);
                com.Parameters.AddWithValue("@humanLoan", loanInfo.HumanLoan);
                com.Parameters.AddWithValue("@valueLoan", loanInfo.ValueLoan);
                com.Parameters.AddWithValue("@noteLoan", loanInfo.NoteLoan);
                if (loanInfo.PathImgLoan != string.Empty)
                {
                    com.Parameters.AddWithValue("@pathImgLoan", loanInfo.PathImgLoan);
                }
                com.Parameters.AddWithValue("@statusLoan", loanInfo.StatusLoan);
                if (loanInfo.StatusLoan == "1")
                {
                    com.Parameters.AddWithValue("@dateLoanFinish", loanInfo.DateLoanFinish);
                    com.Parameters.AddWithValue("@noteLoanFinish", loanInfo.NoteLoanFinish);
                    if (loanInfo.PathImgLoanFinish != string.Empty)
                    {
                        com.Parameters.AddWithValue("@pathImgLoanFinish", loanInfo.PathImgLoanFinish);
                    }
                }
                com.Parameters.AddWithValue("@id", loanInfo.LoanId1);
                result = com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result != 0 ? true : false;
        }

        public static DataTable GetAllLoan(string userId)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            DataTable dtIncome = new DataTable();
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                sb.Append(" SELECT ");
                sb.Append(" ROW_NUMBER() OVER(ORDER BY [LOAN].[DATE_LOAN]) [ROW_NUM] ");
                sb.Append(" , [USER_INFO].[LOGIN_NAME] ");
                sb.Append(" , [LOAN].[DATE_LOAN] AS [NGAY_CHO_VAY] ");
                sb.Append(" , [LOAN].[HUMAN_LOAN] AS [NGUOI_VAY] ");
                sb.Append(" , [LOAN].[VALUE_LOAN] AS [SO_TIEN] ");
                sb.Append(" , [LOAN].[NOTE_LOAN] AS [GHI_CHU] ");
                sb.Append(" , CASE [LOAN].[STATUS_LOAN] ");
                sb.Append(" WHEN '1' THEN N'✓Đã trả' ");
                sb.Append(" WHEN '0' THEN N'𐄂Chưa trả' ");
                sb.Append(" END AS [TRANG_THAI] ");
                sb.Append(" FROM [dbo].[LOAN] ");
                sb.Append(" LEFT JOIN [dbo].[USER_INFO] ");
                sb.Append(" ON [LOAN].[USER_ID] = [USER_INFO].[USER_ID] ");
                sb.Append(" WHERE ");
                sb.Append(" [LOAN].[USER_ID] = @UserId");
                sb.Append(" ORDER BY [LOAN].[DATE_LOAN] ");
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