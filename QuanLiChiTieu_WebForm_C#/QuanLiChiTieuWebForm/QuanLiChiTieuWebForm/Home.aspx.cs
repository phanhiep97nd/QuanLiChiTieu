using QuanLiChiTieu.Models;
using QuanLiChiTieuWebForm.Common;
using QuanLiChiTieuWebForm.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLiChiTieuWebForm
{
    public partial class Home : Page
    {
        #region Private struct Fields
        private string userId = string.Empty;
        private DataTable dtIncome = new DataTable();
        private DataTable dtSpending = new DataTable();
		#endregion

		#region Protected Fields
		protected System.Web.UI.WebControls.Button BtnLogOut;
        protected System.Web.UI.WebControls.TextBox DateIncome;
        protected System.Web.UI.WebControls.Button SubmitIncome;
        protected System.Web.UI.WebControls.Button SubmitSpending;
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
                dtIncome = IncomeModels.GetIncomeInfo(int.Parse(userId), DateTime.Now.Year.ToString());
                dtSpending = SpendingModel.GetSpendingInfo(int.Parse(userId), DateTime.Now.Year.ToString());
            }
            else
            {
                codeAlert.InnerHtml = String.Empty;
                userId	= (string) ViewState["userId"];
            }

        }

        private void Page_PreRender(object sender, System.EventArgs e)
        {
            ViewState["userId"]      = userId;
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
			this.SubmitIncome.Click += SubmitIncome_Click;
            this.SubmitSpending.Click += SubmitSpending_Click;

            this.Load += new System.EventHandler(this.Page_Load);
			this.PreRender += new System.EventHandler(this.Page_PreRender);
		}

        private void SubmitSpending_Click(object sender, EventArgs e)
        {
            try
			{
                SpendingEntity spendingInfo = new SpendingEntity();
                spendingInfo.UserId = int.Parse(userId);
                spendingInfo.DateSpending = DateTime.Parse(DateSpending.Text);
                spendingInfo.ValueSpending = int.Parse(ValueSpending.Text);
                spendingInfo.TypeSpending = TypeSpending.SelectedValue;
                spendingInfo.NoteSpending = NoteSpending.Text;
                bool check = SpendingModel.ClickCreateSpending(spendingInfo);
			    if (check)
			    {
                    DateSpending.Text = string.Empty;
                    ValueSpending.Text = string.Empty;
                    TypeSpending.SelectedValue = "1";
                    NoteSpending.Text = string.Empty;
                    codeAlert.InnerHtml = Constants.HTML_SUCCESS_IMPORT_SPENDING;
                    Response.Write(Constants.SCRIPT_ALERT_CLOSE);
			    }
				else
				{
                    codeAlert.InnerHtml = Constants.HTML_ERROR_IMPORT_SPENDING;
				}
			}
            catch(Exception ex)
			{
                Response.Redirect("ErrorPage.aspx?message=" + ex.GetType().Name);
			}
        }

        private void BtnLogOut_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx?loginName=" + Session["UserName"].ToString(), false);
            Session.Remove("UserName");
            Session.Remove("UserId");
        }

        private void SubmitIncome_Click(object sender, EventArgs e)
		{
			try
			{
                IncomeEntity incomeInfo = new IncomeEntity();
                incomeInfo.UserId = int.Parse(userId);
                incomeInfo.DateIncome = DateTime.Parse(DateIncome.Text);
                incomeInfo.ValueIncome = int.Parse(ValueIncome.Text);
                incomeInfo.TypeIncome = TypeIncome.SelectedValue;
                incomeInfo.NoteIncome = NoteIncome.Text;
                bool check = IncomeModels.ClickCreateIncome(incomeInfo);
			    if (check)
			    {
                    DateIncome.Text = string.Empty;
                    ValueIncome.Text = string.Empty;
                    TypeIncome.SelectedValue = "1";
                    NoteIncome.Text = string.Empty;
                    codeAlert.InnerHtml = Constants.HTML_SUCCESS_IMPORT_INCOME;
                    Response.Write(Constants.SCRIPT_ALERT_CLOSE);
			    }
				else
				{
                    codeAlert.InnerHtml = Constants.HTML_ERROR_IMPORT_INCOME;
				}
			}
            catch(Exception ex)
			{
                Response.Redirect("ErrorPage.aspx?message=" + ex.GetType().Name);
			}
		}
		#endregion

        private void setOverviewData(DataTable dtIncome, DataTable dtSpending, string month)
        {
            DataRow[] drIncome = dtIncome.Select(" MONTH(DATE_INCOME) = '" + month + "'");
            DataRow[] drSpending = dtSpending.Select(" MONTH(DATE_SPENDING) = '" + month + "'");
        }

    }
}