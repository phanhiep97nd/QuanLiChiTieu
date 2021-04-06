using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuanLiChiTieu.Function;

namespace QuanLiChiTieu.Controllers
{
    public class SignInController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlConnection con = new SqlConnection();
        SqlDataReader dr;

        [HttpPost]
        public IActionResult ClickSign()
        {
            Models.UserInfo userInfo = new Models.UserInfo();
            userInfo.LoginName = HttpContext.Request.Form["loginName"];
            userInfo.Pass = HttpContext.Request.Form["pass"];
            List<string> lstErr = new List<string>();
            lstErr = Validate.validateSignIn(userInfo.LoginName, userInfo.Pass, HttpContext.Request.Form["confirmPass"]);
            if(lstErr.Count == 0)
            {
                con.ConnectionString = QuanLiChiTieu.Properties.Resources.ConnectionString;
                if (Models.SignIn.IsExistLoginName(con, com, dr, userInfo.LoginName))
                {
                    lstErr.Add("Tên đăng nhập đã tồn tại!");
                }
                else
                {
                    Models.SignIn.ClickSignIn(con, com, userInfo);
                }
            }
            if(lstErr.Count != 0)
            {
                ViewBag.LoginName = userInfo.LoginName;
                return View("SignIn", lstErr);
            }
            ViewBag.LoginName = userInfo.LoginName;
            ViewBag.SignInSuccess = "Đăng kí thành công!";
            return View("/Views/Login/Login.cshtml");
        }

        public IActionResult SignIn()
        {
            return View();
        }
    }
}