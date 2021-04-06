using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiChiTieu.Models
{
    public class HomeModel
    {
        internal static List<IncomeEntity> GetListIncome(SqlConnection con, SqlCommand com, SqlDataReader dr, int userId, string month, string year, string sortBy, string sortType)
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
                if (!"none".Equals(month))
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
                com.Parameters.AddWithValue("@userId", userId);
                if (!"0".Equals(month))
                {
                    com.Parameters.AddWithValue("@month", month);
                }
                com.Parameters.AddWithValue("@year", year);
                //com.Parameters.AddWithValue("@sortBy", sortBy);
                //com.Parameters.AddWithValue("@sortType", sortType);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    IncomeEntity incomeInfo = new IncomeEntity();
                    incomeInfo.UserId = int.Parse(dr["USER_ID"].ToString());
                    incomeInfo.ValueIncome = int.Parse(dr["VALUE_INCOME"].ToString());
                    incomeInfo.TypeIncome = dr["TYPE_INCOME"].ToString();
                    incomeInfo.DateIncome = DateTime.Parse(dr["DATE_INCOME"].ToString());
                    incomeInfo.NoteIncome = dr["NOTE_INCOME"].ToString();
                    lstIncome.Add(incomeInfo);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstIncome;
        }

        internal static List<SpendingEntity> GetListSpending(SqlConnection con, SqlCommand com, SqlDataReader dr, int userId, string month, string year, string sortBy, string sortType)
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
                if ("VALUE_SPENDING".Equals(sortBy))
                {
                    sb.Append(" ORDER BY " + sortBy + "  " + sortType + " , DATE_SPENDING DESC");
                }
                else if ("DATE_SPENDING".Equals(sortBy))
                {
                    sb.Append(" ORDER BY " + sortBy + "  " + sortType + ", VALUE_SPENDING DESC");
                }
                com.CommandText = sb.ToString();
                com.Parameters.AddWithValue("@userIdSpending", userId);
                if (!string.Empty.Equals(month))
                {
                    com.Parameters.AddWithValue("@monthSpending", month);
                }
                com.Parameters.AddWithValue("@yearSpending", year);
                //com.Parameters.AddWithValue("@sortBy", sortBy);
                //com.Parameters.AddWithValue("@sortType", sortType);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    SpendingEntity spendingInfo = new SpendingEntity();
                    spendingInfo.UserId = int.Parse(dr["USER_ID"].ToString());
                    spendingInfo.ValueSpending = int.Parse(dr["VALUE_SPENDING"].ToString());
                    spendingInfo.TypeSpending = dr["TYPE_SPENDING"].ToString();
                    spendingInfo.DateSpending = DateTime.Parse(dr["DATE_SPENDING"].ToString());
                    spendingInfo.NoteSpending = dr["NOTE_SPENDING"].ToString();
                    lstSpending.Add(spendingInfo);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstSpending;
        }
    }
}
