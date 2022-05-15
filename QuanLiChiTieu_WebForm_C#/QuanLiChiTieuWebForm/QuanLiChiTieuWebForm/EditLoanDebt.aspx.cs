using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLiChiTieuWebForm
{
    public partial class EditLoanDebt : System.Web.UI.Page
    {
        #region Private struct Fields
        private string userId = string.Empty;
        private string typeEdit = string.Empty;
        private string idEdit = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] != null && Session["userId"] != null)
                {
                    userId = Session["userId"].ToString();
                    UserNameLabel.Text = Session["UserName"].ToString();
                }
                else
                {
                    Response.Redirect("Login.aspx", false);
                }

                if (!string.IsNullOrEmpty(Request.QueryString["typeEdit"]))
                {
                    typeEdit = Request.QueryString["typeEdit"];
                }
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    idEdit = Request.QueryString["id"];
                }
                //this.TypeEdit.Text = typeEdit == "loan" ? "DANH SÁCH CHO VAY" : "DANH SÁCH NỢ";
            }
            else
            {

            }
        }

        private void Page_PreRender(object sender, System.EventArgs e)
        {

        }

        #region Control's Event Handlers
        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            this.BtnLogOut.Click += BtnLogOut_Click;
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            string userName = Session["UserName"].ToString();
            Session.Remove("UserName");
            Session.Remove("UserId");
            Response.Redirect("Login.aspx?loginName=" + userName, false);
        }
        #endregion
    }
}