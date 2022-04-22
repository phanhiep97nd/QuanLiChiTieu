using ClosedXML.Excel;
using QuanLiChiTieu.Models;
using QuanLiChiTieuWebForm.Common;
using QuanLiChiTieuWebForm.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
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
        //protected System.Web.UI.WebControls.Button ViewAllOnYear;
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
                ViewState["SortExpressionIncome"] = "DATE_INCOME_SORT";
                ViewState["sortdrIncome"] = " Asc";
                ViewState["SortExpressionSpending"] = "DATE_SPENDING_SORT";
                ViewState["sortdrSpending"] = " Asc";
                setOverviewData(DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString("00"), false);
                //setDispChart(DateTime.Now.Year.ToString());
            }
            else
            {
                codeAlert.InnerHtml = String.Empty;
                codeAlertIncome.InnerHtml = string.Empty;
                codeAlertSpending.InnerHtml = string.Empty;
                userId = (string)ViewState["userId"];
            }

        }

        private void Page_PreRender(object sender, System.EventArgs e)
        {
            setDispChart(YearOverView.SelectedValue);
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
			this.ViewAllOnYear.CheckedChanged += ViewAllOnYear_CheckedChanged;
            this.GridView1.RowEditing += GridView1_RowEditing;
            this.GridView1.RowCancelingEdit += GridView1_RowCancelingEdit;
            this.GridView1.RowUpdating += GridView1_RowUpdating;
            this.GridView1.RowDeleting += GridView1_RowDeleting;
			this.GridView2.RowEditing += GridView2_RowEditing;
			this.GridView2.RowCancelingEdit += GridView2_RowCancelingEdit;
			this.GridView2.RowUpdating += GridView2_RowUpdating;
			this.GridView2.RowDeleting += GridView2_RowDeleting;
			this.GridView1.PageIndexChanging += GridView1_PageIndexChanging;
			this.GridView2.PageIndexChanging += GridView2_PageIndexChanging;
            this.GridView1.Sorting += GridView1_Sorting;
            this.GridView2.Sorting += GridView2_Sorting;
            this.ExportCsv.Click += ExportCsv_Click;

            //this.Load += new System.EventHandler(this.Page_Load);
            //this.PreRender += new System.EventHandler(this.Page_PreRender);
        }

        private void ExportCsv_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtIncome = IncomeModels.GetAllIncome(userId);
                DataTable dtSpending = SpendingModel.GetAllSpending(userId);
                dtIncome.TableName = "Income";
                dtSpending.TableName = "Spending";
                XLWorkbook wb = new XLWorkbook();
                wb.Worksheets.Add(dtIncome);
                wb.Worksheets.Add(dtSpending);
                string fileName = "DATA_FINANCE_MNG" + "_" + Session["UserName"].ToString() + "_" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + fileName + ".xlsx");
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                MemoryStream MyMemoryStream = new MemoryStream();
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                codeAlert.InnerHtml = Constants.HTML_SUCCESS_EXPORT;
                //Response.Write(Constants.SCRIPT_ALERT_CLOSE);
            }
            catch(Exception ex)
            {
                Response.Redirect("ErrorPage.aspx?message=" + ex.GetType().Name + ex.Message);
            }
            finally
            {
                Response.End();
            }
        }

        private void GridView2_Sorting(object sender, GridViewSortEventArgs e)
        {
            ViewState["SortExpressionSpending"] = e.SortExpression;
            if (Convert.ToString(ViewState["sortdrSpending"]) == " Asc")  
            {  
                ViewState["sortdrSpending"] = " Desc";  
            }  
            else  
            {  
                ViewState["sortdrSpending"] = " Asc";  
            }
            setOverviewData(YearOverView.SelectedValue, MonthOverView.SelectedValue, this.ViewAllOnYear.Checked);
            ClientScript.RegisterStartupScript(this.GetType(), "setDispDetailTab", "setDispDetailTab();", true);
            ClientScript.RegisterStartupScript(this.GetType(), "href", "location.href = '#GridView2';", true);
        }

        private void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            ViewState["SortExpressionIncome"] = e.SortExpression;
            if (Convert.ToString(ViewState["sortdrIncome"]) == " Asc")  
            {  
                ViewState["sortdrIncome"] = " Desc";  
            }  
            else  
            {  
                ViewState["sortdrIncome"] = " Asc";  
            }
            setOverviewData(YearOverView.SelectedValue, MonthOverView.SelectedValue, this.ViewAllOnYear.Checked);
            ClientScript.RegisterStartupScript(this.GetType(), "setDispDetailTab", "setDispDetailTab();", true);
            ClientScript.RegisterStartupScript(this.GetType(), "href", "location.href = '#GridView1';", true);
        }

        private void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			GridView2.PageIndex = e.NewPageIndex;
            setOverviewData(YearOverView.SelectedValue, MonthOverView.SelectedValue, this.ViewAllOnYear.Checked);
            ClientScript.RegisterStartupScript(this.GetType(), "setDispDetailTab", "setDispDetailTab();", true);
            ClientScript.RegisterStartupScript(this.GetType(), "href", "location.href = '#GridView2';", true);
		}

		private void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
            GridView1.PageIndex = e.NewPageIndex;
            setOverviewData(YearOverView.SelectedValue, MonthOverView.SelectedValue, this.ViewAllOnYear.Checked);
            ClientScript.RegisterStartupScript(this.GetType(), "setDispDetailTab", "setDispDetailTab();", true);
            ClientScript.RegisterStartupScript(this.GetType(), "href", "location.href = '#GridView1';", true);
		}

		private void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			int id = int.Parse(GridView2.DataKeys[e.RowIndex].Value.ToString());
            bool check = SpendingModel.DeleteSpending(id);
            if (check)
            {
                GridView2.EditIndex = -1;
                setOverviewData(YearOverView.SelectedValue, MonthOverView.SelectedValue, this.ViewAllOnYear.Checked);
                codeAlertSpending.InnerHtml = Constants.HTML_SUCCESS_DELETE_SPENDING;
                Response.Write(Constants.SCRIPT_ALERT_CLOSE);
            }
            else
            {
                codeAlertSpending.InnerHtml = Constants.HTML_ERROR_DELETE_SPENDING;
            }
            ClientScript.RegisterStartupScript(this.GetType(), "setDispDetailTab", "setDispDetailTab();", true);
            ClientScript.RegisterStartupScript(this.GetType(), "href", "location.href = '#GridView2';", true);
		}

		private void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			string messageErr = string.Empty;
            GridViewRow row = GridView2.Rows[e.RowIndex];
            TextBox textDateSpending = (TextBox)row.FindControl("EditDateSpending");
            TextBox textValueSpending = (TextBox)row.FindControl("EditValueSpending");
            DropDownList textTypeSpending = (DropDownList)row.FindControl("EditTypeSpending");
            TextBox textNoteSpending = (TextBox)row.FindControl("EditNoteSpending");
            if(textDateSpending.Text == string.Empty)
            {
                messageErr += Constants.HTML_ERROR_EDIT_DATE_SPENDING + "\n";
            }
            if(textValueSpending.Text == string.Empty)
            {
                messageErr += Constants.HTML_ERROR_EDIT_VALUE_SPENDING;
            }
            if(messageErr != string.Empty)
            {
                codeAlertSpending.InnerHtml = messageErr;
            }
            else
            {
                int id = int.Parse(GridView2.DataKeys[e.RowIndex].Value.ToString());
                SpendingEntity incomeEditInfo = new SpendingEntity();
                incomeEditInfo.SpendingId = id;
                incomeEditInfo.DateSpending = DateTime.Parse(textDateSpending.Text);
                incomeEditInfo.ValueSpending = long.Parse(textValueSpending.Text);
                incomeEditInfo.TypeSpending = textTypeSpending.SelectedValue;
                incomeEditInfo.NoteSpending = textNoteSpending.Text;
                bool check = SpendingModel.UpdateSpending(incomeEditInfo);
                if (check)
                {
                    GridView2.EditIndex = -1;
                    setOverviewData(YearOverView.SelectedValue, MonthOverView.SelectedValue, this.ViewAllOnYear.Checked);
                    GridView2.Columns[5].Visible = true;
                    codeAlertSpending.InnerHtml = Constants.HTML_SUCCESS_EDIT_SPENDING;
                    Response.Write(Constants.SCRIPT_ALERT_CLOSE);
                }
                else
                {
                    codeAlertSpending.InnerHtml = Constants.HTML_ERROR_EDIT_SPENDING;
                }
            }
            ClientScript.RegisterStartupScript(this.GetType(), "setDispDetailTab", "setDispDetailTab();", true);
            ClientScript.RegisterStartupScript(this.GetType(), "href", "location.href = '#GridView2';", true);
		}

		private void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			GridView2.EditIndex = -1;
            setOverviewData(YearOverView.SelectedValue, MonthOverView.SelectedValue, this.ViewAllOnYear.Checked);
            GridView2.Columns[5].Visible = true;
            ClientScript.RegisterStartupScript(this.GetType(), "setDispDetailTab", "setDispDetailTab();", true);
		}

		private void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
		{
			GridView2.EditIndex = e.NewEditIndex;
            setOverviewData(YearOverView.SelectedValue, MonthOverView.SelectedValue, this.ViewAllOnYear.Checked);
            GridView2.Columns[5].Visible = false;
            ClientScript.RegisterStartupScript(this.GetType(), "setDispDetailTab", "setDispDetailTab();", true);
            ClientScript.RegisterStartupScript(this.GetType(), "href", "location.href = '#GridView2';", true);
		}

		private void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            bool check = IncomeModels.DeleteIncome(id);
            if (check)
            {
                GridView1.EditIndex = -1;
                setOverviewData(YearOverView.SelectedValue, MonthOverView.SelectedValue, this.ViewAllOnYear.Checked);
                codeAlertIncome.InnerHtml = Constants.HTML_SUCCESS_DELETE_INCOME;
                Response.Write(Constants.SCRIPT_ALERT_CLOSE);
            }
            else
            {
                codeAlertIncome.InnerHtml = Constants.HTML_ERROR_DELETE_INCOME;
            }
            ClientScript.RegisterStartupScript(this.GetType(), "setDispDetailTab", "setDispDetailTab();", true);
            ClientScript.RegisterStartupScript(this.GetType(), "href", "location.href = '#GridView1';", true);
        }

        private void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string messageErr = string.Empty;
            GridViewRow row = GridView1.Rows[e.RowIndex];
            TextBox textDateIncome = (TextBox)row.FindControl("EditDateIncome");
            TextBox textValueIncome = (TextBox)row.FindControl("EditValueIncome");
            DropDownList textTypeIncome = (DropDownList)row.FindControl("EditTypeIncome");
            TextBox textNoteIncome = (TextBox)row.FindControl("EditNoteIncome");
            if(textDateIncome.Text == string.Empty)
            {
                messageErr += Constants.HTML_ERROR_EDIT_DATE_INCOME + "\n";
            }
            if(textValueIncome.Text == string.Empty)
            {
                messageErr += Constants.HTML_ERROR_EDIT_VALUE_INCOME;
            }
            if(messageErr != string.Empty)
            {
                codeAlertIncome.InnerHtml = messageErr;
            }
            else
            {
                int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
                IncomeEntity incomeEditInfo = new IncomeEntity();
                incomeEditInfo.IncomeId = id;
                incomeEditInfo.DateIncome = DateTime.Parse(textDateIncome.Text);
                incomeEditInfo.ValueIncome = long.Parse(textValueIncome.Text);
                incomeEditInfo.TypeIncome = textTypeIncome.SelectedValue;
                incomeEditInfo.NoteIncome = textNoteIncome.Text;
                bool check = IncomeModels.UpdateIncome(incomeEditInfo);
                if (check)
                {
                    GridView1.EditIndex = -1;
                    setOverviewData(YearOverView.SelectedValue, MonthOverView.SelectedValue, this.ViewAllOnYear.Checked);
                    GridView1.Columns[5].Visible = true;
                    codeAlertIncome.InnerHtml = Constants.HTML_SUCCESS_EDIT_INCOME;
                    Response.Write(Constants.SCRIPT_ALERT_CLOSE);
                }
                else
                {
                    codeAlertIncome.InnerHtml = Constants.HTML_ERROR_EDIT_INCOME;
                }
            }
            ClientScript.RegisterStartupScript(this.GetType(), "setDispDetailTab", "setDispDetailTab();", true);
            ClientScript.RegisterStartupScript(this.GetType(), "href", "location.href = '#GridView1';", true);
        }

        private void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            setOverviewData(YearOverView.SelectedValue, MonthOverView.SelectedValue, this.ViewAllOnYear.Checked);
            GridView1.Columns[5].Visible = true;
            ClientScript.RegisterStartupScript(this.GetType(), "setDispDetailTab", "setDispDetailTab();", true);
        }

        private void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            setOverviewData(YearOverView.SelectedValue, MonthOverView.SelectedValue, this.ViewAllOnYear.Checked);
            GridView1.Columns[5].Visible = false;
            ClientScript.RegisterStartupScript(this.GetType(), "setDispDetailTab", "setDispDetailTab();", true);
            ClientScript.RegisterStartupScript(this.GetType(), "href", "location.href = '#GridView1';", true);
        }

        private void ViewAllOnYear_CheckedChanged(object sender, EventArgs e)
		{
            setOverviewData(YearOverView.SelectedValue, MonthOverView.SelectedValue, this.ViewAllOnYear.Checked);
			ClientScript.RegisterStartupScript(this.GetType(), "setDispDetailTab", "setDispDetailTab();", true);
		}

		private void YearOverView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string month = MonthOverView.SelectedValue;
            string year = YearOverView.SelectedValue;
            setOverviewData(year, month, this.ViewAllOnYear.Checked);
            //setDispChart(year);
        }

        private void MonthOverView_SelectedIndexChanged(object sender, EventArgs e)
		{
			string month = MonthOverView.SelectedValue;
            string year = YearOverView.SelectedValue;
            setOverviewData(year, month, this.ViewAllOnYear.Checked);
		}

		private void SubmitSpending_Click(object sender, EventArgs e)
        {
            try
            {
                SpendingEntity spendingInfo = new SpendingEntity();
                spendingInfo.UserId = int.Parse(userId);
                spendingInfo.DateSpending = DateTime.Parse(DateSpending.Text);
                spendingInfo.ValueSpending = long.Parse(ValueSpending.Text);
                spendingInfo.TypeSpending = TypeSpending.SelectedValue;
                spendingInfo.NoteSpending = NoteSpending.Text;
                bool check = SpendingModel.ClickCreateSpending(spendingInfo);
                if (check)
                {
                    setOverviewData(YearOverView.SelectedValue, MonthOverView.SelectedValue, this.ViewAllOnYear.Checked);
                    //setDispChart(YearOverView.SelectedValue);
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
            string userName = Session["UserName"].ToString();
            Session.Remove("UserName");
            Session.Remove("UserId");
            Response.Redirect("Login.aspx?loginName=" + userName, false);
        }

        private void SubmitIncome_Click(object sender, EventArgs e)
        {
            try
            {
                IncomeEntity incomeInfo = new IncomeEntity();
                incomeInfo.UserId = int.Parse(userId);
                incomeInfo.DateIncome = DateTime.Parse(DateIncome.Text);
                incomeInfo.ValueIncome = long.Parse(ValueIncome.Text);
                incomeInfo.TypeIncome = TypeIncome.SelectedValue;
                incomeInfo.NoteIncome = NoteIncome.Text;
                bool check = IncomeModels.ClickCreateIncome(incomeInfo);
                if (check)
                {
                    setOverviewData(YearOverView.SelectedValue, MonthOverView.SelectedValue, this.ViewAllOnYear.Checked);
                    //setDispChart(YearOverView.SelectedValue);
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
                //dtIncome.Columns[2].DataType = typeof(DateTime);
                DataTable dtSpending = SpendingModel.GetSpendingInfo(int.Parse(userId), year);
                //dtSpending.Columns[2].DataType = typeof(DateTime);
                DataTable dtIncomeInMonth = dtIncome.Clone();
                //DataTable dtIncomeInMonth = new DataTable();
                DataTable dtSpendingInMonth = dtSpending.Clone();
                //DataTable dtSpendingInMonth = new DataTable();
                long totalIncome = 0;
                long totalSpending = 0;
                long[] valueIncome = new long[2];
                long[] valueSpending = new long[9];
                foreach (DataRow dr in dtIncome.Rows)
                {
                    if (dr["DATE_INCOME"].ToString().Split('/')[1].Equals(month))
                    {
                        dtIncomeInMonth.ImportRow(dr);
                        totalIncome += long.Parse(dr["VALUE_INCOME"].ToString());
                        switch (dr["TYPE_INCOME"].ToString())
                        {
                            case "1":
                                valueIncome[0] = valueIncome[0] + long.Parse(dr["VALUE_INCOME"].ToString());
                                break;
                            case "2":
                                valueIncome[1] = valueIncome[1] + long.Parse(dr["VALUE_INCOME"].ToString());
                                break;
                        }
                    }
                }
                foreach (DataRow dr in dtSpending.Rows)
                {
                    if (dr["DATE_SPENDING"].ToString().Split('/')[1].Equals(month))
                    {
                        dtSpendingInMonth.ImportRow(dr);
                        totalSpending += long.Parse(dr["VALUE_SPENDING"].ToString());
                        switch (dr["TYPE_SPENDING"].ToString())
                        {
                            case "1":
                                valueSpending[0] = valueSpending[0] + long.Parse(dr["VALUE_SPENDING"].ToString());
                                break;
                            case "2":
                                valueSpending[1] = valueSpending[1] + long.Parse(dr["VALUE_SPENDING"].ToString());
                                break;
                            case "3":
                                valueSpending[2] = valueSpending[2] + long.Parse(dr["VALUE_SPENDING"].ToString());
                                break;
                            case "4":
                                valueSpending[3] = valueSpending[3] + long.Parse(dr["VALUE_SPENDING"].ToString());
                                break;
                            case "5":
                                valueSpending[4] = valueSpending[4] + long.Parse(dr["VALUE_SPENDING"].ToString());
                                break;
                            case "6":
                                valueSpending[5] = valueSpending[5] + long.Parse(dr["VALUE_SPENDING"].ToString());
                                break;
                            case "7":
                                valueSpending[6] = valueSpending[6] + long.Parse(dr["VALUE_SPENDING"].ToString());
                                break;
                            case "8":
                                valueSpending[7] = valueSpending[7] + long.Parse(dr["VALUE_SPENDING"].ToString());
                                break;
                            case "9":
                                valueSpending[8] = valueSpending[8] + long.Parse(dr["VALUE_SPENDING"].ToString());
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

                dtIncome.DefaultView.Sort = ViewState["SortExpressionIncome"].ToString() + ViewState["sortdrIncome"].ToString();
                dtIncomeInMonth.DefaultView.Sort = ViewState["SortExpressionIncome"].ToString() + ViewState["sortdrIncome"].ToString();
                dtSpending.DefaultView.Sort = ViewState["SortExpressionSpending"].ToString() + ViewState["sortdrSpending"].ToString();
                dtSpendingInMonth.DefaultView.Sort = ViewState["SortExpressionSpending"].ToString() + ViewState["sortdrSpending"].ToString();

                //DataSet dsIncome = new DataSet();
                //dsIncome.Tables.Add(isAllofYear ? dtIncome : dtIncomeInMonth);
                GridView1.DataSource = isAllofYear ? dtIncome : dtIncomeInMonth;
                GridView1.DataBind();
                //DataSet dsSpending = new DataSet();
                //dsSpending.Tables.Add(isAllofYear ? dtSpending : dtSpendingInMonth);
                GridView2.DataSource = isAllofYear ? dtSpending : dtSpendingInMonth;
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
            long totalIncome = 0;
            long totalSpending = 0;
            for(int i = 1; i <= 12; i++)
            {
                long income = IncomeModels.GetListIncomePerMonth(userId, i.ToString(), year);
                long spending = SpendingModel.GetListSpendingPerMonth(userId, i.ToString(), year);
                totalIncome += income;
                totalSpending += spending;
                lstIncomePerMonth += income + "|";
                lstSpendingPerMonth += spending + "|";
            }
            TotalIncomeOfYear.Text = "Tổng thu nhập năm " + YearOverView.SelectedValue + ": " + (totalIncome == 0 ? "0" : totalIncome.ToString("###,###")) + "VND";
            TotalSpendingOfYear.Text = "Tổng chi tiêu năm " + YearOverView.SelectedValue + ": " + (totalSpending == 0 ? "0" : totalSpending.ToString("###,###")) + "VND";
            TotalSaveMoneyOfYear.Text = "Tổng tích lũy năm " + YearOverView.SelectedValue + ": " + ((totalIncome - totalSpending) == 0 ? "0" : (totalIncome - totalSpending).ToString("###,###")) + "VND";
            string script = "window.onload = function() { createChart('" + lstIncomePerMonth + "', '" + lstSpendingPerMonth + "'); };";
            ClientScript.RegisterStartupScript(this.GetType(), "createChart", script, true);
        }

        public object ShowTypeSpending(object type)
        {
            object result = string.Empty;
             switch (type)
            {
                case "1":
                    result = "Nhà/Sinh hoạt phí";
                    break;
                case "2":
                    result = "Ăn uống";
                    break;
                case "3":
                    result = "Mua sắm";
                    break;
                case "4":
                    result = "Quỹ tài chính/Bảo hiểm";
                    break;
                case "5":
                    result = "Trả nợ vay";
                    break;
                case "6":
                    result = "Trả nợ vay";
                    break;
                case "7":
                    result = "Trả nợ vay";
                    break;
                case "8":
                    result = "Trả nợ vay";
                    break;
                case "9":
                    result = "Khác";
                    break;
            }
            return result;
        }
    }
}
