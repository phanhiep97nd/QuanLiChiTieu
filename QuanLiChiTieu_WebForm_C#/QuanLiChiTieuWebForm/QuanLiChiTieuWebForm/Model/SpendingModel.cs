﻿using System;
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
                sb.Append(" SELECT [USER_ID] ");
                sb.Append(" ,[SPENDING_ID] ");
                sb.Append(" ,[VALUE_SPENDING] ");
                sb.Append(" ,CONVERT(varchar, [SPENDING].[DATE_SPENDING], 103) AS [DATE_SPENDING] ");
                sb.Append(" ,[TYPE_SPENDING] ");
                sb.Append(" ,[NOTE_SPENDING] ");
                sb.Append(" FROM [dbo].[SPENDING] ");
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

        public static long GetListSpendingPerMonth(string userId, string month, string year)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            SqlCommand com = new SqlCommand();
            long result = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                com.Connection = con;
                sb.Append(" SELECT SUM(VALUE_SPENDING) FROM [dbo].[SPENDING] ");
                sb.Append(" WHERE ");
                sb.Append("[USER_ID] = @userId");
                sb.Append(" AND ");
                sb.Append(" MONTH(DATE_SPENDING) = @month AND ");
                sb.Append(" YEAR(DATE_SPENDING) = @year ");
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

        public static bool UpdateSpending(SpendingEntity SpendingInfo)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            SqlCommand com = new SqlCommand();
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
            return result != 0 ? true : false;
        }

        public static bool DeleteSpending(int idSpending)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            SqlCommand com = new SqlCommand();
            int result = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                com.Connection = con;
                sb.Append("DELETE FROM [dbo].[SPENDING]");
                sb.Append(" WHERE ");
                sb.Append("[SPENDING_ID] = @id");
                com.CommandText = sb.ToString();
                com.Parameters.AddWithValue("@id", idSpending);
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
