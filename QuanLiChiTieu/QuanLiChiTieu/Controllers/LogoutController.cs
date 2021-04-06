using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuanLiChiTieu.Controllers
{
    public class LogoutController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlConnection con = new SqlConnection();

        public IActionResult Logout(int id)
        {
            con.ConnectionString = QuanLiChiTieu.Properties.Resources.ConnectionString;
            var idFromSession = HttpContext.Session.GetInt32("sessionLogin");
            if (idFromSession != null)
            {
                Models.Login.changeLoginStatus(con, com, id, false);
                HttpContext.Session.Clear();
            }                
            return Redirect("/Login/Login");
        }
    }
}