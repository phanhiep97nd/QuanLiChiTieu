using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiChiTieu.Models;

namespace QuanLiChiTieu.Controllers
{
    public class HomeController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlConnection con = new SqlConnection();
        SqlDataReader dr;

        public IActionResult Index(int id)
        {
            //return Content(userName + pass);
            //HomeModel homeModel = new HomeModel();
            List<string> lstSearchCondition = new List<string>();
            var idFromSession = HttpContext.Session.GetInt32("sessionLogin");
            var loginName = HttpContext.Session.GetString("loginName");
            string monthOverview = HttpContext.Request.Query["monthOverview"];
            lstSearchCondition.Add(monthOverview == null ? DateTime.Now.Month.ToString() : monthOverview);
            string yearOverview = HttpContext.Request.Query["yearOverview"];
            lstSearchCondition.Add(yearOverview == null ? DateTime.Now.Year.ToString() : yearOverview);
            string searchDetailBy = HttpContext.Request.Query["searchDetailBy"];
            lstSearchCondition.Add(searchDetailBy == null ? "1" : searchDetailBy);
            string monthDetal = HttpContext.Request.Query["monthDetal"];
            lstSearchCondition.Add(monthDetal == null ? DateTime.Now.Month.ToString() : monthDetal);
            string yearDetail = HttpContext.Request.Query["yearDetail"];
            lstSearchCondition.Add(yearDetail == null ? DateTime.Now.Year.ToString() : yearDetail);
            string sortBy = HttpContext.Request.Query["sortBy"];
            lstSearchCondition.Add(sortBy == null ? "DATE_INCOME" : sortBy);
            string sortType = HttpContext.Request.Query["sortType"];
            lstSearchCondition.Add(sortType == null ? "DESC" : sortType);
            string tab = HttpContext.Request.Query["tab"];
            lstSearchCondition.Add(tab == null ? "overview" : tab);
            string message = HttpContext.Request.Query["message"];
            List<IncomeEntity> lstIncomeOverview = new List<IncomeEntity>();
            List<SpendingEntity> lstSpendingOverview = new List<SpendingEntity>();
            List<IncomeEntity> lstIncomeDetail = new List<IncomeEntity>();
            List<SpendingEntity> lstSpendingDetail = new List<SpendingEntity>();
            List<int> lstIncomePerMonth = new List<int>();
            List<int> lstSpendingPerMonth = new List<int>();
            if (id != idFromSession)
            {
                return Redirect("/Login/Login");
            }
            else
            {
                con.ConnectionString = QuanLiChiTieu.Properties.Resources.ConnectionString;
                HomeModel homeModel = new HomeModel();
                lstIncomeOverview = homeModel.GetListIncome(con, com, dr, Convert.ToInt16(idFromSession), monthOverview == null ? DateTime.Now.Month.ToString() : monthOverview, yearOverview == null ? DateTime.Now.Year.ToString() : yearOverview, sortBy == null ? "DATE_INCOME" : sortBy, sortType == null ? "DESC" : sortType);
                lstSpendingOverview = homeModel.GetListSpending(con, com, dr, Convert.ToInt16(idFromSession), monthOverview == null ? DateTime.Now.Month.ToString() : monthOverview, yearOverview == null ? DateTime.Now.Year.ToString() : yearOverview, sortBy == null ? "DATE_INCOME" : sortBy, sortType == null ? "DESC" : sortType);
                lstIncomeDetail = homeModel.GetListIncome(con, com, dr, Convert.ToInt16(idFromSession), monthDetal == null ? DateTime.Now.Month.ToString() : monthDetal, yearDetail == null ? DateTime.Now.Year.ToString() : yearDetail, sortBy == null ? "DATE_INCOME" : sortBy, sortType == null ? "DESC" : sortType);
                lstSpendingDetail = homeModel.GetListSpending(con, com, dr, Convert.ToInt16(idFromSession), monthDetal == null ? DateTime.Now.Month.ToString() : monthDetal, yearDetail == null ? DateTime.Now.Year.ToString() : yearDetail, sortBy == null ? "DATE_INCOME" : sortBy, sortType == null ? "DESC" : sortType);
                for(int i = 1; i <= 12; i++)
                {
                    lstIncomePerMonth.Add(homeModel.GetListIncomePerMonth(con, com, Convert.ToInt16(idFromSession), i.ToString(), yearDetail == null ? DateTime.Now.Year.ToString() : yearDetail));
                    lstSpendingPerMonth.Add(homeModel.GetListSpendingPerMonth(con, com, Convert.ToInt16(idFromSession), i.ToString(), yearDetail == null ? DateTime.Now.Year.ToString() : yearDetail));
                }
            }
            ViewBag.userId = idFromSession;
            ViewBag.loginName = loginName;
            ViewBag.lstIncomeOverview = lstIncomeOverview;
            ViewBag.lstSpendingOverview = lstSpendingOverview;
            ViewBag.lstSearchCondition = lstSearchCondition;
            ViewBag.lstIncomeDetail = lstIncomeDetail;
            ViewBag.lstSpendingDetail = lstSpendingDetail;
            ViewBag.lstIncomePerMonth = lstIncomePerMonth;
            ViewBag.lstSpendingPerMonth = lstSpendingPerMonth;
            if(message == "succesDel")
            {
                ViewBag.message = "Xoa thanh cong!!!!";
            }
            else if (message == "errorDel")
            {
                ViewBag.message = "Xay ra loi ! Khong xoa thanh cong!!!";
            }
            return View();
        }

    }
}
