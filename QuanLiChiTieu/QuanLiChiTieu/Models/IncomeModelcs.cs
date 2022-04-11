using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiChiTieu.Models
{
    public class IncomeModelcs
    {
        internal static int ClickCreateIncome(SqlConnection con, SqlCommand com, IncomeEntity incomeInfo)
        {
            int result = 0;
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "INSERT INTO [dbo].[INCOME] ([USER_ID],[VALUE_INCOME],[TYPE_INCOME],[DATE_INCOME],[NOTE_INCOME]) VALUES (@userId, @valueIncome, @typeIncome, @dateIncome, @noteIncome)";
                com.Parameters.AddWithValue("@userId", incomeInfo.UserId);
                com.Parameters.AddWithValue("@valueIncome", incomeInfo.ValueIncome);
                com.Parameters.AddWithValue("@typeIncome", incomeInfo.TypeIncome);
                com.Parameters.AddWithValue("@dateIncome", incomeInfo.DateIncome);
                com.Parameters.AddWithValue("@noteIncome", "".Equals(incomeInfo.NoteIncome) ? "NA" : incomeInfo.NoteIncome);
                result = com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        internal static IncomeEntity GetIncomeInfo(SqlConnection con, SqlCommand com, SqlDataReader dr, int id)
        {
            IncomeEntity incomeInfo = new IncomeEntity();
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                com.Connection = con;
                sb.Append(" SELECT * FROM [dbo].[INCOME] ");
                sb.Append(" WHERE ");
                sb.Append("[INCOME_ID] = @id");
                com.CommandText = sb.ToString();
                com.Parameters.Add("@id", SqlDbType.Int).Value = id;
                dr = com.ExecuteReader();
                com.Parameters.Clear();
                while (dr.Read())
                {
                    incomeInfo.UserId = int.Parse(dr["USER_ID"].ToString());
                    incomeInfo.ValueIncome = int.Parse(dr["VALUE_INCOME"].ToString());
                    incomeInfo.TypeIncome = dr["TYPE_INCOME"].ToString();
                    incomeInfo.DateIncome = DateTime.Parse(dr["DATE_INCOME"].ToString());
                    incomeInfo.NoteIncome = dr["NOTE_INCOME"].ToString();
                    incomeInfo.IncomeId = int.Parse(dr["INCOME_ID"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
            return incomeInfo;
        }

        internal static int UpdateIncome(SqlConnection con, SqlCommand com, IncomeEntity incomeInfo)
        {
            int result = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                com.Connection = con;
                sb.Append("UPDATE [dbo].[INCOME]");
                sb.Append(" SET ");
                sb.Append(" [VALUE_INCOME] = @valueIncome");
                sb.Append(", [TYPE_INCOME] = @typeIncome");
                sb.Append(", [DATE_INCOME] = @dateIncome");
                sb.Append(", [NOTE_INCOME] = @noteIncome");
                sb.Append(" WHERE ");
                sb.Append("[INCOME_ID] = @id");
                com.CommandText = sb.ToString();
                com.Parameters.AddWithValue("@valueIncome", incomeInfo.ValueIncome);
                com.Parameters.AddWithValue("@typeIncome", incomeInfo.TypeIncome);
                com.Parameters.AddWithValue("@dateIncome", incomeInfo.DateIncome);
                com.Parameters.AddWithValue("@noteIncome", "".Equals(incomeInfo.NoteIncome) ? "NA" : incomeInfo.NoteIncome);
                com.Parameters.AddWithValue("@id", incomeInfo.IncomeId);
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
