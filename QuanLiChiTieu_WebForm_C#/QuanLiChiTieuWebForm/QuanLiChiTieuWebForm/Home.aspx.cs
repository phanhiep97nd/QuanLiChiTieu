using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLiChiTieuWebForm
{
    public partial class Home : Page
    {
        #region Protected Fields
        protected System.Web.UI.WebControls.Button BtnLogOut;
        protected System.Web.UI.WebControls.TextBox DateIncome;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    UserNameLabel.Text = Session["UserName"].ToString();
                }
                else
                {
                    Response.Redirect("Login.aspx", false);
                }
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
            this.BtnLogOut.Click += BtnLogOut_Click1;

			this.Load += new System.EventHandler(this.Page_Load);
			this.PreRender += new System.EventHandler(this.Page_PreRender);
		}
        #endregion

        private void BtnLogOut_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx?loginName=" + Session["UserName"].ToString(), false);
            Session.Remove("UserName");
        }
    }
}