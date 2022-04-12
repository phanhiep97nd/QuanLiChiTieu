using QuanLiChiTieu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLiChiTieuWebForm
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["loginName"] != null)
                {
                    UserName.Text = Request.QueryString["loginName"];
                }
            }
            else
            {

            }
        }

        protected void SignInBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignIn.aspx", false);
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string loginName = UserName.Text;
            string pass = Password.Text;
            List<string> listErr = Common.Validate.validateLogin(loginName, pass);

            if (listErr.Count != 0)
            {
                codeAlert.InnerHtml = Common.Common.GetErrorMessageValidate(listErr);
            }
            else
            {
                try
                {
                    UserInfo userInfo = new UserInfo();

                    userInfo = Model.LoginModel.GetInfoLogin(loginName);
                    string passEncode = Common.Common.encode(pass, userInfo.EndCodePass);
                    if (passEncode.Equals(userInfo.Pass))
                    {
                        //Session.Add("UserName", userInfo.LoginName);
                        Session["UserName"] = loginName;
                        Response.Redirect("Home.aspx", false);
                    }
                    else
                    {
                        codeAlert.InnerHtml = Common.Constants.LOGIN_FALSE;
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("ErrorPage.aspx?message=" + ex.GetType().Name);
                }
            }
        }
    }
}