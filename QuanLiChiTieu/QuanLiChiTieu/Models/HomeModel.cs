using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiChiTieu.Models
{
    public class HomeModel
    {
        public List<IncomeEntity> GetListIncome(SqlConnection con, SqlCommand com, SqlDataReader dr, int userId, string month, string year, string sortBy, string sortType)
        {
            List<IncomeEntity> lstIncome = new List<IncomeEntity>();
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                com.Connection = con;
                sb.Append(" SELECT * FROM [dbo].[INCOME] ");
                sb.Append(" WHERE ");
                sb.Append("[USER_ID] = @userId");
                sb.Append(" AND ");
                if (!"0".Equals(month))
                {
                    sb.Append(" MONTH(DATE_INCOME) = @month AND ");
                }
                sb.Append(" YEAR(DATE_INCOME) = @year");
                if ("VALUE_INCOME".Equals(sortBy))
                {
                    sb.Append(" ORDER BY "+ sortBy+"  " +sortType+" , DATE_INCOME DESC");
                }
                else if ("DATE_INCOME".Equals(sortBy))
                {
                    sb.Append(" ORDER BY " + sortBy + "  " + sortType + ", VALUE_INCOME DESC");
                }
                com.CommandText = sb.ToString();
                //com.Parameters.AddWithValue("@userId", userId);
                com.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
                if (!"0".Equals(month))
                {
                    //com.Parameters.AddWithValue("@month", month);
                    com.Parameters.Add("@month", SqlDbType.VarChar).Value = month;
                }
                //com.Parameters.AddWithValue("@year", year);
                com.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
                //com.Parameters.AddWithValue("@sortBy", sortBy);
                //com.Parameters.AddWithValue("@sortType", sortType);
                dr = com.ExecuteReader();
                com.Parameters.Clear();
                while (dr.Read())
                {
                    IncomeEntity incomeInfo = new IncomeEntity();
                    incomeInfo.UserId = int.Parse(dr["USER_ID"].ToString());
                    incomeInfo.ValueIncome = int.Parse(dr["VALUE_INCOME"].ToString());
                    incomeInfo.TypeIncome = dr["TYPE_INCOME"].ToString();
                    incomeInfo.DateIncome = DateTime.Parse(dr["DATE_INCOME"].ToString());
                    incomeInfo.NoteIncome = dr["NOTE_INCOME"].ToString();
                    incomeInfo.IncomeId = int.Parse(dr["INCOME_ID"].ToString());
                    lstIncome.Add(incomeInfo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
            return lstIncome;
        }

        public List<SpendingEntity> GetListSpending(SqlConnection con, SqlCommand com, SqlDataReader dr, int userId, string month, string year, string sortBy, string sortType)
        {
            List<SpendingEntity> lstSpending = new List<SpendingEntity>();
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                com.Connection = con;
                sb.Append(" SELECT * FROM [dbo].[SPENDING] ");
                sb.Append(" WHERE ");
                sb.Append("[USER_ID] = @userIdSpending");
                sb.Append(" AND ");
                if (!"0".Equals(month))
                {
                    sb.Append(" MONTH(DATE_SPENDING) = @monthSpending AND ");
                }
                sb.Append(" YEAR(DATE_SPENDING) = @yearSpending ");
                if ("VALUE_INCOME".Equals(sortBy))
                {
                    sb.Append(" ORDER BY " + " VALUE_SPENDING " + "  " + sortType + " , DATE_SPENDING DESC");
                }
                else if ("DATE_INCOME".Equals(sortBy))
                {
                    sb.Append(" ORDER BY " + " DATE_SPENDING " + "  " + sortType + ", VALUE_SPENDING DESC");
                }
                com.CommandText = sb.ToString();
                //com.Parameters.AddWithValue("@userIdSpending", userId);
                com.Parameters.Add("@userIdSpending", SqlDbType.Int).Value = userId;
                if (!"0".Equals(month))
                {
                    //com.Parameters.AddWithValue("@monthSpending", month);
                    com.Parameters.Add("@monthSpending", SqlDbType.VarChar).Value = month;
                }
                //com.Parameters.AddWithValue("@yearSpending", year);
                com.Parameters.Add("@yearSpending", SqlDbType.VarChar).Value = year;
                //com.Parameters.AddWithValue("@sortBy", sortBy);
                //com.Parameters.AddWithValue("@sortType", sortType);
                dr = com.ExecuteReader();
                com.Parameters.Clear();
                while (dr.Read())
                {
                    SpendingEntity spendingInfo = new SpendingEntity();
                    spendingInfo.UserId = int.Parse(dr["USER_ID"].ToString());
                    spendingInfo.ValueSpending = int.Parse(dr["VALUE_SPENDING"].ToString());
                    spendingInfo.TypeSpending = dr["TYPE_SPENDING"].ToString();
                    spendingInfo.DateSpending = DateTime.Parse(dr["DATE_SPENDING"].ToString());
                    spendingInfo.NoteSpending = dr["NOTE_SPENDING"].ToString();
                    spendingInfo.SpendingId = int.Parse(dr["SPENDING_ID"].ToString());
                    lstSpending.Add(spendingInfo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
            return lstSpending;
        }

        public int GetListIncomePerMonth(SqlConnection con, SqlCommand com, int userId, string month, string year)
        {
            int result = 0;
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
                result = int.Parse(Convert.ToString(total) == "" ? "0" : Convert.ToString(total));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
            return result;
        }

        public int GetListSpendingPerMonth(SqlConnection con, SqlCommand com, int userId, string month, string year)
        {
            int result = 0;
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
                result = int.Parse(Convert.ToString(total) == "" ? "0" : Convert.ToString(total));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
            return result;
        }
    }
}
