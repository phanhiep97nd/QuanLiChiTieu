using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiChiTieu.Models
{
    public class SpendingModel
    {
        internal static int ClickCreateSpending(SqlConnection con, SqlCommand com, SpendingEntity spendingInfo)
        {
            int result = 0;
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "INSERT INTO [dbo].[Spending] ([USER_ID],[VALUE_SPENDING],[TYPE_SPENDING],[DATE_SPENDING],[NOTE_SPENDING]) VALUES (@userId, @valueSpending, @typeSpending, @dateSpending, @noteSpending)";
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
            return result;
        }

        internal static SpendingEntity GetSpendingInfo(SqlConnection con, SqlCommand com, SqlDataReader dr, int id)
        {
            SpendingEntity spendingInfo = new SpendingEntity();
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                com.Connection = con;
                sb.Append(" SELECT * FROM [dbo].[SPENDING] ");
                sb.Append(" WHERE ");
                sb.Append("[SPENDING_ID] = @id");
                com.CommandText = sb.ToString();
                com.Parameters.Add("@id", SqlDbType.Int).Value = id;
                dr = com.ExecuteReader();
                com.Parameters.Clear();
                while (dr.Read())
                {
                    spendingInfo.UserId = int.Parse(dr["USER_ID"].ToString());
                    spendingInfo.ValueSpending = int.Parse(dr["VALUE_SPENDING"].ToString());
                    spendingInfo.TypeSpending = dr["TYPE_SPENDING"].ToString();
                    spendingInfo.DateSpending = DateTime.Parse(dr["DATE_SPENDING"].ToString());
                    spendingInfo.NoteSpending = dr["NOTE_SPENDING"].ToString();
                    spendingInfo.SpendingId = int.Parse(dr["SPENDING_ID"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
            return spendingInfo;
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
