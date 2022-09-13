using QuanLiChiTieu.Models;
using QuanLiChiTieuWebForm.Common;
using QuanLiChiTieuWebForm.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLiChiTieuWebForm
{
    public partial class WeddingMonney : System.Web.UI.Page
    {
        #region Private struct Fields
        private string userId = string.Empty;
        private SearchCondition searchCondition = new SearchCondition();
        DataTable dtGive = new DataTable();
        DataTable dtTake = new DataTable();
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
                this.MonthSearch.SelectedValue = DateTime.Now.Month.ToString("00");
                int yearNow = int.Parse(DateTime.Now.Year.ToString());
                for (int i = (yearNow - 10); i <= yearNow; i++)
                {
                    this.YearSearch.Items.Add(i.ToString());
                }
                this.YearSearch.SelectedValue = yearNow.ToString();
                this.TabIndex.Value = "1";
                setSearchCondition();
                setDispData();
            }
            else
            {
                codeAlert.InnerHtml = string.Empty;
                userId = (string)ViewState["userId"];
                searchCondition = (SearchCondition)ViewState["searchCondition"];
                dtGive = (DataTable)ViewState["dtGive"];
                dtTake = (DataTable)ViewState["dtTake"];
            }
        }

        private void Page_PreRender(object sender, System.EventArgs e)
        {
            ViewState["userId"] = userId;
            ViewState["searchCondition"] = searchCondition;
            ViewState["dtGive"] = dtGive;
            ViewState["dtTake"] = dtTake;
            setDispSearchRegion();
            if(this.TabIndex.Value == "2")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "setDispSecondTab", "setDispSecondTab();", true);
            }
        }

        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            this.BtnLogOut.Click += BtnLogOut_Click;
            this.HomeBtn.Click += HomeBtn_Click;
            this.LoanDebtBtn.Click += LoanDebtBtn_Click;
            this.SubmitGive.Click += SubmitGive_Click;
            this.SubmitTake.Click += SubmitTake_Click;
            this.ViewAllCheckBox.CheckedChanged += ViewAllCheckBox_CheckedChanged;
            this.SearchBtn.Click += SearchBtn_Click;
            this.GridView1.RowEditing += GridView1_RowEditing;
        }

        private void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = dtGive;
            GridView1.DataBind();
            GridView1.Columns[10].Visible = false;
            GridViewRow row = GridView1.Rows[e.NewEditIndex];
            DropDownList listStatusGive = (DropDownList)row.FindControl("EditStatusGive");
            if(listStatusGive.SelectedValue == "0")
            {
                GridView1.Columns[7].Visible = false;
                GridView1.Columns[8].Visible = false;
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            setSearchCondition();
            setDispData();
        }

        private void ViewAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            searchCondition.IsViewAllOfYear = this.ViewAllCheckBox.Checked;
            if (this.ViewAllCheckBox.Checked)
            {
                this.MonthSearchLabel.Visible = false;
                this.MonthSearch.Visible = false;
            }
            else
            {
                this.MonthSearchLabel.Visible = true;
                this.MonthSearch.Visible = true;
            }
            setSearchCondition();
            setDispData();
        }

        private void SubmitTake_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            SqlTransaction trans = null;

            IncomeEntity incomeInfo = new IncomeEntity();
            WFMTakeEntity takeInfo = new WFMTakeEntity();

            string dateTake = this.DateTake.Text.Trim();
            string humanTake = this.HumanTake.Text.Trim();
            string groupTake = this.GroupTake.Text.Trim();
            string valueTake = this.ValueTake.Text.Trim();
            string typeTake = this.TypeTake.Text.Trim();
            string note = this.NoteTake.Text.Trim();

            incomeInfo.UserId = int.Parse(userId);
            incomeInfo.DateIncome = DateTime.Parse(dateTake);
            incomeInfo.ValueIncome = long.Parse(valueTake);
            incomeInfo.TypeIncome = "9";
            string type = string.Empty;
            switch (typeTake)
            {
                case "1":
                    type = "Mừng cưới";
                    break;
                    case "2":
                    type = "Đám hiếu";
                    break;
                    case "3":
                    type = "Mừng nhà";
                    break;
                    case "4":
                    type = "Loại khác-" + note;
                    break;
            }
            incomeInfo.NoteIncome = "Khoản nhận tiền mừng| Người gửi: " + humanTake + " ; Quan hệ: " + groupTake + " ; Loại: " + type + " ; Note: " + note;

            takeInfo.UserId = int.Parse(userId);
            takeInfo.DateTake = DateTime.Parse(dateTake);
            takeInfo.HumanTake = humanTake;
            takeInfo.GroupTake = groupTake;
            takeInfo.ValueTake = long.Parse(valueTake);
            takeInfo.StatusTake = "0";
            takeInfo.TypeTake = typeTake;
            takeInfo.NoteTake = note;

            con.Open();
            trans = con.BeginTransaction();
            try
            {
                IncomeModels.InsertIncome(con, trans, incomeInfo);
                takeInfo.IncomeId = IncomeModels.GetLastestIncomeId(con, trans);
                WFMTakeModel.InsertTake(con, trans, takeInfo);
                this.codeAlert.InnerHtml = Constants.HTML_SUCCESS_IMPORT_TAKE;
                Response.Write(Constants.SCRIPT_ALERT_CLOSE);
                trans.Commit();
                setDispData();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Response.Redirect("ErrorPage.aspx?message=" + ex.GetType().Name + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void SubmitGive_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            SqlTransaction trans = null;

            SpendingEntity spendingInfo = new SpendingEntity();
            WFMGiveEntity giveInfo = new WFMGiveEntity();

            string dateGive = this.DateGive.Text.Trim();
            string humanGive = this.HumanGive.Text.Trim();
            string groupGive = this.GroupGive.Text.Trim();
            string valueGive = this.ValueGive.Text.Trim();
            string typeGive = this.TypeGive.Text.Trim();
            string note = this.NoteGive.Text.Trim();

            spendingInfo.UserId = int.Parse(userId);
            spendingInfo.DateSpending = DateTime.Parse(dateGive);
            spendingInfo.ValueSpending = long.Parse(valueGive);
            spendingInfo.TypeSpending = "9";
            string type = string.Empty;
            switch (typeGive)
            {
                case "1":
                    type = "Mừng cưới";
                    break;
                    case "2":
                    type = "Đám hiếu";
                    break;
                    case "3":
                    type = "Mừng nhà";
                    break;
                    case "4":
                    type = "Loại khác-" + note;
                    break;
            }
            spendingInfo.NoteSpending = "Khoản đi tiền hiếu hỷ| Người nhận: " + humanGive + " ; Quan hệ: " + groupGive + " ; Loại: " + type + " ; Note: " + note;

            giveInfo.UserId = int.Parse(userId);
            giveInfo.DateGive = DateTime.Parse(dateGive);
            giveInfo.HumanGive = humanGive;
            giveInfo.GroupGive = groupGive;
            giveInfo.ValueGive = long.Parse(valueGive);
            giveInfo.StatusGive = "0";
            giveInfo.TypeGive = typeGive;
            giveInfo.NoteGive = note;

            con.Open();
            trans = con.BeginTransaction();
            try
            {
                SpendingModel.InsertSpending(con, trans, spendingInfo);
                giveInfo.SpendingId = SpendingModel.GetLastestSpendingId(con, trans);
                WFMGiveModel.InsertGive(con, trans, giveInfo);
                this.codeAlert.InnerHtml = Constants.HTML_SUCCESS_IMPORT_GIVE;
                Response.Write(Constants.SCRIPT_ALERT_CLOSE);
                trans.Commit();
                setDispData();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Response.Redirect("ErrorPage.aspx?message=" + ex.GetType().Name + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void LoanDebtBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoanDebt.aspx");
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

        private void setSearchCondition()
        {
            searchCondition.IsViewAllOfYear = this.ViewAllCheckBox.Checked;
            if (!this.ViewAllCheckBox.Checked)
            {
                searchCondition.MonthSearch = this.MonthSearch.SelectedValue;
            }
            else
            {
                searchCondition.MonthSearch = string.Empty;
            }
            searchCondition.YearSearch = this.YearSearch.SelectedValue;
            searchCondition.StatusSearch = this.StatusSearch.SelectedValue;
            searchCondition.NameSearch = this.NameSearch.Text;
        }

        private void setDispSearchRegion()
        {
            if (!this.ViewAllCheckBox.Checked)
            {
                this.MonthSearch.SelectedValue = searchCondition.MonthSearch != "" ? searchCondition.MonthSearch : DateTime.Now.Month.ToString("00");
            }
            this.YearSearch.SelectedValue = searchCondition.YearSearch;
            this.StatusSearch.SelectedValue = searchCondition.StatusSearch;
            this.NameSearch.Text = searchCondition.NameSearch;
        }

        private void setDispData()
        {
            dtGive = WFMGiveModel.GetGiveInfo(int.Parse(userId), searchCondition);
            GridView1.DataSource = dtGive;
            GridView1.DataBind();

            dtTake = WFMTakeModel.GetTakeInfo(int.Parse(userId), searchCondition);
            GridView2.DataSource = dtTake;
            GridView2.DataBind();
        }

        public object ShowType(object type)
        {
            object result = string.Empty;
             switch (type)
            {
                case "1":
                    result = "Mừng cưới";
                    break;
                case "2":
                    result = "Đám hiếu";
                    break;
                case "3":
                    result = "Mừng nhà";
                    break;
                case "4":
                    result = "Khác";
                    break;
            }
            return result;
        }
    }
}