using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiChiTieu.Function;
using QuanLiChiTieu.Models;

namespace QuanLiChiTieu.Controllers
{
    public class LoginController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlConnection con = new SqlConnection();
        SqlDataReader dr;

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ClickLogin()
        {
            int id = 0;
            Models.UserInfo userInfo = new Models.UserInfo();
            List<string> lstErr = new List<string>();
            string loginNameInput = HttpContext.Request.Form["loginName"];
            string passInput = HttpContext.Request.Form["pass"];
            lstErr = Validate.validateLogin(loginNameInput, passInput);
            if (lstErr.Count == 0)
            {
                con.ConnectionString = QuanLiChiTieu.Properties.Resources.ConnectionString;
                userInfo = Models.Login.GetInfoLogin(con, com, dr, loginNameInput);
                string passEncode = EncodePass.encode(passInput, userInfo.EndCodePass);
                if (passEncode.Equals(userInfo.Pass))
                {
                    id = userInfo.Id;
                    Models.Login.changeLoginStatus(con, com, id, true);
                }
                else
                {
                    lstErr.Add("Tài khoản hoặc mật khẩu chưa chính xác");
                }
            }
            if (lstErr.Count != 0)
            {
                ViewBag.LoginName = loginNameInput;
                return View("Login", lstErr);
            }
            HttpContext.Session.SetString("loginName", loginNameInput);
            HttpContext.Session.SetInt32("sessionLogin",id);
            return Redirect("/Home/Index/" + id);
        }
    }
}