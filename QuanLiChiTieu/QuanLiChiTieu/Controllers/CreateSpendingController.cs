using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuanLiChiTieu.Controllers
{
    public class CreateSpendingController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlConnection con = new SqlConnection();
        SqlDataReader dr;

        public IActionResult CreateSpending()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ClickCreateSpending()
        {
            var idFromSession = HttpContext.Session.GetInt32("sessionLogin");
            if (idFromSession == null)
            {
                return Redirect("/Login/Login");
            }
            else
            {
                con.ConnectionString = QuanLiChiTieu.Properties.Resources.ConnectionString;
                Models.SpendingEntity spendingInfo = new Models.SpendingEntity();
                spendingInfo.UserId = Convert.ToUInt16(idFromSession);
                spendingInfo.ValueSpending = int.Parse(HttpContext.Request.Form["valueSpending"]);
                spendingInfo.TypeSpending = HttpContext.Request.Form["typeSpending"];
                spendingInfo.DateSpending = DateTime.Parse(HttpContext.Request.Form["dateSpending"]);
                spendingInfo.NoteSpending = HttpContext.Request.Form["noteSpending"];
                int check = Models.SpendingModel.ClickCreateSpending(con, com, spendingInfo);
                if (check != 0)
                {
                    return Redirect("/Home/Index/" + spendingInfo.UserId);
                }
                else
                {
                    return View("CreateSpending", "Đã có lỗi!");
                }
            }
        }
    }
}