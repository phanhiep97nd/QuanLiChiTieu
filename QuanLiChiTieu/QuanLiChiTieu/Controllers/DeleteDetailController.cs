using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QuanLiChiTieu.Controllers
{
    public class DeleteDetailController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlConnection con = new SqlConnection();

        public IActionResult DeleteDetail(int id)
        {
            string url = HttpContext.Request.Query["url"];
            string type = HttpContext.Request.Query["type"];
            url = url.Replace("*", "&");
            if (!url.Contains("tab="))
            {
                url += "?tab=detail";
            }
            con.ConnectionString = QuanLiChiTieu.Properties.Resources.ConnectionString;
            int check = Models.DeleteDetail.ClickDeleteDetail(con, com, id, type);
            if (check != 0)
            {
                url += "&message=succesDel";
            }
            else
            {
                url += "&message=errorDel";
            }
            return Redirect(url);
        }
    }
}
