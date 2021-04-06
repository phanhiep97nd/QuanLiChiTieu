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
            List<IncomeEntity> lstIncomeOverview = new List<IncomeEntity>();
            List<SpendingEntity> lstSpendingOverview = new List<SpendingEntity>();
            List<IncomeEntity> lstIncomeDetail = new List<IncomeEntity>();
            List<SpendingEntity> lstSpendingDetail = new List<SpendingEntity>();
            if (id != idFromSession)
            {
                return Redirect("/Login/Login");
            }
            else
            {
                con.ConnectionString = QuanLiChiTieu.Properties.Resources.ConnectionString;
                lstIncomeOverview = HomeModel.GetListIncome(con, com, dr, Convert.ToInt16(idFromSession), monthOverview == null ? DateTime.Now.Month.ToString() : monthOverview, yearOverview == null ? DateTime.Now.Year.ToString() : yearOverview, sortBy == null ? "DATE_INCOME" : sortBy, sortType == null ? "DESC" : sortType);
                lstSpendingOverview = HomeModel.GetListSpending(con, com, dr, Convert.ToInt16(idFromSession), monthOverview == null ? DateTime.Now.Month.ToString() : monthOverview, yearOverview == null ? DateTime.Now.Year.ToString() : yearOverview, sortBy == null ? "DATE_INCOME" : sortBy, sortType == null ? "DESC" : sortType);
                //lstIncomeDetail = HomeModel.GetListIncome(con, com, dr, Convert.ToInt16(idFromSession), monthDetal == null ? DateTime.Now.Month.ToString() : monthDetal, yearDetail == null ? DateTime.Now.Year.ToString() : yearDetail, sortBy == null ? "DATE_INCOME" : sortBy, sortType == null ? "DESC" : sortType);
                //lstSpendingDetail = HomeModel.GetListSpending(con, com, dr, Convert.ToInt16(idFromSession), monthDetal == null ? DateTime.Now.Month.ToString() : monthDetal, yearDetail == null ? DateTime.Now.Year.ToString() : yearDetail, sortBy == null ? "DATE_INCOME" : sortBy, sortType == null ? "DESC" : sortType);
            }
            ViewBag.userId = idFromSession;
            ViewBag.loginName = loginName;
            ViewBag.lstIncomeOverview = lstIncomeOverview;
            ViewBag.lstSpendingOverview = lstSpendingOverview;
            ViewBag.lstSearchCondition = lstSearchCondition;
            //ViewBag.lstIncomeDetail = lstIncomeDetail;
            //ViewBag.lstSpendingDetail = lstSpendingDetail;
            return View();
        }

    }
}
