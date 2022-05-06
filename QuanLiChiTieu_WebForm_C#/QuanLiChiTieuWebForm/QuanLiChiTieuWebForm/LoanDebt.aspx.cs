using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLiChiTieuWebForm
{
    public partial class LoanDebt : System.Web.UI.Page
    {
        #region Private struct Fields
        private string userId = string.Empty;

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
                this.YearSearch.SelectedValue = DateTime.Now.Month.ToString("00");
                int yearNow = int.Parse(DateTime.Now.Year.ToString());
                for(int i = (yearNow - 10); i <= yearNow; i++)
                {
                    this.YearSearch.Items.Add(i.ToString());
                }
                this.YearSearch.SelectedValue = yearNow.ToString();
			}
			else
			{
                 userId = (string)ViewState["userId"];
			}
        }

        private void Page_PreRender(object sender, System.EventArgs e)
        {
            ViewState["userId"] = userId;
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
			this.HomeBtn.Click += HomeBtn_Click;
			this.SearchBtn.Click += SearchBtn_Click;
		}

		private void SearchBtn_Click(object sender, EventArgs e)
		{
            Console.WriteLine("Test");
		}

		private void HomeBtn_Click(object sender, EventArgs e)
		{
			Response.Redirect("Home.aspx");
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