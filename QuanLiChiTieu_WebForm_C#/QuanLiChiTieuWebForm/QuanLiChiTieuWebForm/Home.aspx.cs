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
        #endregion

        #region Protected Fields
        protected System.Web.UI.WebControls.Button BtnLogOut;
        protected System.Web.UI.WebControls.TextBox DateIncome;
        protected System.Web.UI.WebControls.Button SubmitIncome;
        protected System.Web.UI.WebControls.Button SubmitSpending;
        //protected System.Web.UI.WebControls.DropDownList MonthOverView;
        #endregion
        private void Page_Load(object sender, EventArgs e)
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
                MonthOverView.SelectedValue = DateTime.Now.Month.ToString("00");
                int yearNow = int.Parse(DateTime.Now.Year.ToString());
                for(int i = (yearNow - 10); i <= yearNow; i++)
                {
                    YearOverView.Items.Add(i.ToString());
                }
                YearOverView.SelectedValue = yearNow.ToString();
                setOverviewData(DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString("00"), false);
                setDispChart(DateTime.Now.Year.ToString());
            }
            else
            {
                codeAlert.InnerHtml = String.Empty;
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
            this.BtnLogOut.Click += BtnLogOut_Click1;
            this.SubmitIncome.Click += SubmitIncome_Click;
            this.SubmitSpending.Click += SubmitSpending_Click;
			this.MonthOverView.SelectedIndexChanged += MonthOverView_SelectedIndexChanged;
            this.YearOverView.SelectedIndexChanged += YearOverView_SelectedIndexChanged;

            //this.Load += new System.EventHandler(this.Page_Load);
            //this.PreRender += new System.EventHandler(this.Page_PreRender);
        }

        private void YearOverView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string month = MonthOverView.SelectedValue;
            string year = YearOverView.SelectedValue;
            setOverviewData(year, month, false);
            setDispChart(year);
        }

        private void MonthOverView_SelectedIndexChanged(object sender, EventArgs e)
		{
			string month = MonthOverView.SelectedValue;
            string year = YearOverView.SelectedValue;
            setOverviewData(year, month, false);
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
                    setOverviewData(YearOverView.SelectedValue, MonthOverView.SelectedValue, false);
                    setDispChart(YearOverView.SelectedValue);
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
            catch (Exception ex)
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
                    setOverviewData(YearOverView.SelectedValue, MonthOverView.SelectedValue, false);
                    setDispChart(YearOverView.SelectedValue);
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
            catch (Exception ex)
            {
                Response.Redirect("ErrorPage.aspx?message=" + ex.GetType().Name);
            }
        }
        #endregion

        private void setOverviewData(string year, string month, bool isAllofYear)
        {
            try
            {
                //string month = int.Parse(MonthOverView.SelectedValue).ToString("00");
                //string year = YearOverView.SelectedValue;
                DataTable dtIncome = IncomeModels.GetIncomeInfo(int.Parse(userId), year);
                DataTable dtSpending = SpendingModel.GetSpendingInfo(int.Parse(userId), year);
                int totalIncome = 0;
                int totalSpending = 0;
                int[] valueIncome = new int[2];
                int[] valueSpending = new int[9];
                foreach (DataRow dr in dtIncome.Rows)
                {
                    if (dr["DATE_INCOME"].ToString().Split('/')[1].Equals(month))
                    {
                        totalIncome += int.Parse(dr["VALUE_INCOME"].ToString());
                        switch (dr["TYPE_INCOME"].ToString())
                        {
                            case "1":
                                valueIncome[0] = valueIncome[0] + int.Parse(dr["VALUE_INCOME"].ToString());
                                break;
                            case "2":
                                valueIncome[1] = valueIncome[1] + int.Parse(dr["VALUE_INCOME"].ToString());
                                break;
                        }
                    }
                }
                foreach (DataRow dr in dtSpending.Rows)
                {
                    if (dr["DATE_SPENDING"].ToString().Split('/')[1].Equals(month))
                    {
                        totalSpending += int.Parse(dr["VALUE_SPENDING"].ToString());
                        switch (dr["TYPE_SPENDING"].ToString())
                        {
                            case "1":
                                valueSpending[0] = valueSpending[0] + int.Parse(dr["VALUE_SPENDING"].ToString());
                                break;
                            case "2":
                                valueSpending[1] = valueSpending[1] + int.Parse(dr["VALUE_SPENDING"].ToString());
                                break;
                            case "3":
                                valueSpending[2] = valueSpending[2] + int.Parse(dr["VALUE_SPENDING"].ToString());
                                break;
                            case "4":
                                valueSpending[3] = valueSpending[3] + int.Parse(dr["VALUE_SPENDING"].ToString());
                                break;
                            case "5":
                                valueSpending[4] = valueSpending[4] + int.Parse(dr["VALUE_SPENDING"].ToString());
                                break;
                            case "6":
                                valueSpending[5] = valueSpending[5] + int.Parse(dr["VALUE_SPENDING"].ToString());
                                break;
                            case "7":
                                valueSpending[6] = valueSpending[6] + int.Parse(dr["VALUE_SPENDING"].ToString());
                                break;
                            case "8":
                                valueSpending[7] = valueSpending[7] + int.Parse(dr["VALUE_SPENDING"].ToString());
                                break;
                            case "9":
                                valueSpending[8] = valueSpending[8] + int.Parse(dr["VALUE_SPENDING"].ToString());
                                break;
                        }
                    }
                }
                TotalIncome.Text = Common.Common.GetFormatMonney(totalIncome);
                TotalSpending.Text = Common.Common.GetFormatMonney(totalSpending);
                TotalSaveMoney.Text = Common.Common.GetFormatMonney((totalIncome - totalSpending));
                ValueIncomeType1.Text = Common.Common.GetFormatMonney(valueIncome[0]);
                ValueIncomeType2.Text = Common.Common.GetFormatMonney(valueIncome[1]);
                ValueSpendingType1.Text = Common.Common.GetFormatMonney(valueSpending[0]);
                ValueSpendingType2.Text = Common.Common.GetFormatMonney(valueSpending[1]);
                ValueSpendingType3.Text = Common.Common.GetFormatMonney(valueSpending[2]);
                ValueSpendingType4.Text = Common.Common.GetFormatMonney(valueSpending[3]);
                ValueSpendingType5.Text = Common.Common.GetFormatMonney(valueSpending[4]);
                ValueSpendingType6.Text = Common.Common.GetFormatMonney(valueSpending[5]);
                ValueSpendingType7.Text = Common.Common.GetFormatMonney(valueSpending[6]);
                ValueSpendingType8.Text = Common.Common.GetFormatMonney(valueSpending[7]);
                ValueSpendingType9.Text = Common.Common.GetFormatMonney(valueSpending[8]);

                DataSet dsIncome = new DataSet();
                dsIncome.Tables.Add(dtIncome);
                GridView1.DataSource = dsIncome;
                GridView1.DataBind();
                DataSet dsSpending = new DataSet();
                dsSpending.Tables.Add(dtSpending);
                GridView2.DataSource = dsSpending;
                GridView2.DataBind();
            }
            catch (Exception ex)
            {
                Response.Redirect("ErrorPage.aspx?message=" + ex.GetType().Name + ex.Message);
            }
        }

        private void setDispChart(string year)
        {
            string lstIncomePerMonth = string.Empty;
            string lstSpendingPerMonth = string.Empty;
            for(int i = 1; i <= 12; i++)
            {
                lstIncomePerMonth += IncomeModels.GetListIncomePerMonth(userId, i.ToString(), year) + "|";
                lstSpendingPerMonth += SpendingModel.GetListSpendingPerMonth(userId, i.ToString(), year) + "|";
            }
            string script = "window.onload = function() { createChart('" + lstIncomePerMonth + "', '" + lstSpendingPerMonth + "'); };";
            ClientScript.RegisterStartupScript(this.GetType(), "createChart", script, true);
        }
    }
}
