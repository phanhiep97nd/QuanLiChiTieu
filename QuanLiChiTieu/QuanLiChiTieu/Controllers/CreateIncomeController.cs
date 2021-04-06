using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuanLiChiTieu.Controllers
{
    public class CreateIncomeController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlConnection con = new SqlConnection();
        SqlDataReader dr;

        public IActionResult CreateIncome()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult ClickCreateIncome()
        {
            var idFromSession = HttpContext.Session.GetInt32("sessionLogin");
            if(idFromSession == null)
            {
                return Redirect("/Login/Login");
            }
            else
            {
                con.ConnectionString = QuanLiChiTieu.Properties.Resources.ConnectionString;
                Models.IncomeEntity incomeInfo = new Models.IncomeEntity();
                incomeInfo.UserId = Convert.ToUInt16(idFromSession);
                incomeInfo.ValueIncome = int.Parse(HttpContext.Request.Form["valueIncome"]);
                incomeInfo.TypeIncome = HttpContext.Request.Form["typeIncome"];
                incomeInfo.DateIncome = DateTime.Parse(HttpContext.Request.Form["dateIncome"]);
                incomeInfo.NoteIncome = HttpContext.Request.Form["noteIncome"];
                int check = Models.IncomeModelcs.ClickCreateIncome(con, com, incomeInfo);
                if (check != 0)
                {
                    return Redirect("/Home/Index/" + incomeInfo.UserId);
                }
                else
                {
                    return View("CreateIncome", "Đã có lỗi!");
                }
            }
        }
    }
}