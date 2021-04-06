using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
    }
}
