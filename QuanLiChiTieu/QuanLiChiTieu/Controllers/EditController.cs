using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuanLiChiTieu.Controllers
{
    public class EditController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlConnection con = new SqlConnection();
        SqlDataReader dr;
        public IActionResult Edit(int id)
        {
            var idFromSession = HttpContext.Session.GetInt32("sessionLogin");
            if (idFromSession == null)
            {
                return Redirect("/Login/Login");
            }
            else
            {
                con.ConnectionString = QuanLiChiTieu.Properties.Resources.ConnectionString;
                string typeEdit = HttpContext.Request.Query["typeEdit"];
                ViewBag.typeEdit = typeEdit;
                if (typeEdit == "income")
                {
                    Models.IncomeEntity incomeInfo = new Models.IncomeEntity();
                    incomeInfo = Models.IncomeModelcs.GetIncomeInfo(con, com, dr, id);
                    ViewBag.IncomeInfo = incomeInfo;
                }
                else if(typeEdit == "spending")
                {
                    Models.SpendingEntity spendingInfo = new Models.SpendingEntity();
                    spendingInfo = Models.SpendingModel.GetSpendingInfo(con, com, dr, id);
                    ViewBag.SpendingInfo = spendingInfo;
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult ClickEdit()
        {
            var idFromSession = HttpContext.Session.GetInt32("sessionLogin");
            if (idFromSession == null)
            {
                return Redirect("/Login/Login");
            }
            else
            {
                con.ConnectionString = QuanLiChiTieu.Properties.Resources.ConnectionString;
                String typeEdit = HttpContext.Request.Form["typeEdit"];
                int userId = Convert.ToUInt16(idFromSession);
                int value = int.Parse(HttpContext.Request.Form["value"]);
                String type = HttpContext.Request.Form["type"];
                DateTime date = DateTime.Parse(HttpContext.Request.Form["date"]);
                String Note = HttpContext.Request.Form["note"];
                int id = int.Parse(HttpContext.Request.Form["id"]);
                int check = 0;
                if (typeEdit == "income")
                {
                    Models.IncomeEntity incomeInfo = new Models.IncomeEntity();
                    incomeInfo.DateIncome = date;
                    incomeInfo.ValueIncome = value;
                    incomeInfo.TypeIncome = type;
                    incomeInfo.NoteIncome = Note;
                    incomeInfo.IncomeId = id;
                    check = Models.IncomeModelcs.UpdateIncome(con, com, incomeInfo);
                }
                else if(typeEdit == "spending")
                {
                    Models.SpendingEntity SpendingInfo = new Models.SpendingEntity();
                    SpendingInfo.DateSpending = date;
                    SpendingInfo.ValueSpending = value;
                    SpendingInfo.TypeSpending = type;
                    SpendingInfo.NoteSpending = Note;
                    SpendingInfo.SpendingId = id;
                    check = Models.SpendingModel.UpdateSpending(con, com, SpendingInfo);
                }
                if (check != 0)
                {
                    return Redirect("/Home/Index/" + userId + "?tab=detail");
                }
                else
                {
                    return View("Edit", "Đã có lỗi!");
                }
            }
        }
    }
}
