using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiChiTieu.Models
{
    public class DeleteDetail
    {
        internal static int ClickDeleteDetail(SqlConnection con, SqlCommand com, int id, string type)
        {
            int result = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                con.Open();
                com.Connection = con;
                sb.Append(" DELETE FROM ");
                if (type == "spending")
                {
                    sb.Append("[SPENDING]");
                }
                else if (type == "income")
                {
                    sb.Append("[INCOME]");
                }
                sb.Append(" WHERE ");
                if (type == "spending")
                {
                    sb.Append("[SPENDING_ID] = @id");
                }
                else if (type == "income")
                {
                    sb.Append("[INCOME_ID] = @id");
                }
                com.CommandText = sb.ToString();
                com.Parameters.Add("@id", SqlDbType.Int).Value = id;
                com.Parameters.Add("@type", SqlDbType.VarChar).Value = type;
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
