using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLiChiTieuWebForm
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }

        protected void SignInBtn_Click(object sender, EventArgs e)
        {
            string loginName = LoginName.Text;
            string pass = Pass.Text;
            string confirmPass = ConfirmPass.Text;
            List<string> listErr = Common.Validate.validateSignIn(loginName, pass, confirmPass);
            if (listErr.Count == 0)
            {
                if (Model.SignInModel.CheckExistLoginName(loginName))
                {
                    listErr.Add(Common.Constants.VALIDATE_EXIST_LOGINNAME);
                }
            }
            if (listErr.Count != 0)
            {
                codeAlert.InnerHtml = Common.Common.GetErrorMessageValidate(listErr);
            }
            else
            {
                try
                {
                    Model.UserInfo userInfo = new Model.UserInfo();
                    userInfo.LoginName = loginName;
                    userInfo.Pass = pass;

                    bool isSignInSucces = Model.SignInModel.SignIn(userInfo);
                    if (isSignInSucces)
                    {
                        Response.Redirect("Login.aspx?loginName=" + loginName, false);
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