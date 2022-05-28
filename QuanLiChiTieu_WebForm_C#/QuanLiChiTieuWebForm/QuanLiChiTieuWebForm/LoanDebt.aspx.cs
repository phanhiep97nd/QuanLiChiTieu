using ClosedXML.Excel;
using QuanLiChiTieu.Models;
using QuanLiChiTieuWebForm.Common;
using QuanLiChiTieuWebForm.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLiChiTieuWebForm
{
    public partial class LoanDebt : System.Web.UI.Page
    {
        #region Private struct Fields
        private string userId = string.Empty;
        private SearchCondition searchCondition = new SearchCondition();
        DataTable dtLoan = new DataTable();
        DataTable dtDebt = new DataTable();
        private string sortLoan = "ASC";
        private string sortDebt = "ASC";

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
                setSearchCondition();
                setDispDetail();
            }
            else
            {
                codeAlert.InnerHtml = string.Empty;
                userId = (string)ViewState["userId"];
                searchCondition = (SearchCondition)ViewState["searchCondition"];
                dtLoan = (DataTable)ViewState["dtLoan"];
                dtDebt = (DataTable)ViewState["dtDebt"];
                sortLoan = (string)ViewState["sortLoan"];
                sortDebt = (string)ViewState["sortDebt"];
            }
        }

        private void Page_PreRender(object sender, System.EventArgs e)
        {
            //codeAlert.InnerHtml = string.Empty;
            ViewState["userId"] = userId;
            ViewState["searchCondition"] = searchCondition;
            ViewState["dtLoan"] = dtLoan;
            ViewState["dtDebt"] = dtDebt;
            ViewState["sortLoan"] = sortLoan;
            ViewState["sortDebt"] = sortDebt;
            setDispSearchRegion();
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
            this.SubmitLoan.Click += SubmitLoan_Click;
            this.SubmitDebt.Click += SubmitDebt_Click;
            this.ViewAllCheckBox.CheckedChanged += ViewAllCheckBox_CheckedChanged;
            this.LinkSortDateLoan.Click += LinkSortDateLoan_Click;
            this.LinkSortHumanLoan.Click += LinkSortHumanLoan_Click;
            this.LinkSortValueLoan.Click += LinkSortValueLoan_Click;
            this.LinkSortStatusLoan.Click += LinkSortStatusLoan_Click;
            this.LinkSortDateDebt.Click += LinkSortDateDebt_Click;
            this.LinkSortHumanDebt.Click += LinkSortHumanDebt_Click;
            this.LinkSortValueDebt.Click += LinkSortValueDebt_Click;
            this.LinkSortStatusDebt.Click += LinkSortStatusDebt_Click;
            this.ExportCsv.Click += ExportCsv_Click;
        }

        private void ExportCsv_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtLoan = LoanModel.GetAllLoan(userId);
                DataTable dtDebt = DebtModel.GetAllDebt(userId);
                dtLoan.TableName = "Danh sach vay";
                dtDebt.TableName = "Danh sach no";
                XLWorkbook wb = new XLWorkbook();
                wb.Worksheets.Add(dtLoan);
                wb.Worksheets.Add(dtDebt);
                string now = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                string fileName = "DATA_LOAN-DEBT_MNG" + "_" + Session["UserName"].ToString() + "_" + now;

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

        private void LinkSortStatusDebt_Click(object sender, EventArgs e)
        {
            if (sortDebt == "Asc")
            {
                sortDebt = "Desc";
            }
            else
            {
                sortDebt = "Asc";
            }
            dtDebt.DefaultView.Sort = "STATUS_DEBT" + " " + sortLoan;
            ElementLoan.InnerHtml = CreateLoanInfoElement(dtLoan).ToString();
            ElementDebt.InnerHtml = CreateDebtInfoElement(dtDebt.DefaultView.ToTable()).ToString();
        }

        private void LinkSortValueDebt_Click(object sender, EventArgs e)
        {
            if (sortDebt == "Asc")
            {
                sortDebt = "Desc";
            }
            else
            {
                sortDebt = "Asc";
            }
            dtDebt.DefaultView.Sort = "VALUE_DEBT" + " " + sortLoan;
            ElementLoan.InnerHtml = CreateLoanInfoElement(dtLoan).ToString();
            ElementDebt.InnerHtml = CreateDebtInfoElement(dtDebt.DefaultView.ToTable()).ToString();
        }

        private void LinkSortHumanDebt_Click(object sender, EventArgs e)
        {
            if (sortDebt == "Asc")
            {
                sortDebt = "Desc";
            }
            else
            {
                sortDebt = "Asc";
            }
            dtDebt.DefaultView.Sort = "HUMAN_DEBT" + " " + sortLoan;
            ElementLoan.InnerHtml = CreateLoanInfoElement(dtLoan).ToString();
            ElementDebt.InnerHtml = CreateDebtInfoElement(dtDebt.DefaultView.ToTable()).ToString();
        }

        private void LinkSortDateDebt_Click(object sender, EventArgs e)
        {
            if (sortDebt == "Asc")
            {
                sortDebt = "Desc";
            }
            else
            {
                sortDebt = "Asc";
            }
            dtDebt.DefaultView.Sort = "DATE_DEBT_SORT" + " " + sortLoan;
            ElementLoan.InnerHtml = CreateLoanInfoElement(dtLoan).ToString();
            ElementDebt.InnerHtml = CreateDebtInfoElement(dtDebt.DefaultView.ToTable()).ToString();
        }

        private void LinkSortStatusLoan_Click(object sender, EventArgs e)
        {
            if (sortLoan == "Asc")
            {
                sortLoan = "Desc";
            }
            else
            {
                sortLoan = "Asc";
            }
            dtLoan.DefaultView.Sort = "STATUS_LOAN" + " " + sortLoan;
            ElementLoan.InnerHtml = CreateLoanInfoElement(dtLoan.DefaultView.ToTable()).ToString();
            ElementDebt.InnerHtml = CreateDebtInfoElement(dtDebt).ToString();
        }

        private void LinkSortValueLoan_Click(object sender, EventArgs e)
        {
            if (sortLoan == "Asc")
            {
                sortLoan = "Desc";
            }
            else
            {
                sortLoan = "Asc";
            }
            dtLoan.DefaultView.Sort = "VALUE_LOAN" + " " + sortLoan;
            ElementLoan.InnerHtml = CreateLoanInfoElement(dtLoan.DefaultView.ToTable()).ToString();
            ElementDebt.InnerHtml = CreateDebtInfoElement(dtDebt).ToString();
        }

        private void LinkSortHumanLoan_Click(object sender, EventArgs e)
        {
            if (sortLoan == "Asc")
            {
                sortLoan = "Desc";
            }
            else
            {
                sortLoan = "Asc";
            }
            dtLoan.DefaultView.Sort = "HUMAN_LOAN" + " " + sortLoan;
            ElementLoan.InnerHtml = CreateLoanInfoElement(dtLoan.DefaultView.ToTable()).ToString();
            ElementDebt.InnerHtml = CreateDebtInfoElement(dtDebt).ToString();
        }

        private void LinkSortDateLoan_Click(object sender, EventArgs e)
        {
            if (sortLoan == "Asc")
            {
                sortLoan = "Desc";
            }
            else
            {
                sortLoan = "Asc";
            }
            dtLoan.DefaultView.Sort = "DATE_LOAN_SORT" + " " + sortLoan;
            ElementLoan.InnerHtml = CreateLoanInfoElement(dtLoan.DefaultView.ToTable()).ToString();
            ElementDebt.InnerHtml = CreateDebtInfoElement(dtDebt).ToString();
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
            setDispDetail();
        }

        private void SubmitDebt_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            SqlTransaction trans = null;

            IncomeEntity incomeInfo = new IncomeEntity();
            DebtEntity debtInfo = new DebtEntity();

            string dateDebt = this.DateDebt.Text;
            string humanDebt = this.HumanDebt.Text;
            string valueDebt = this.ValueDebt.Text;
            string note = this.NoteDebt.Text;
            string pathImgDebt = string.Empty;
            if (this.OFileDebt.HasFile)
            {
                string fileName = this.OFileDebt.FileName;
                string folderPath = Server.MapPath("~/Images");
                pathImgDebt = "../Images/" + fileName;
                string storeImage = Path.Combine(folderPath, fileName);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                this.OFileDebt.SaveAs(storeImage);
            }

            incomeInfo.UserId = int.Parse(userId);
            incomeInfo.DateIncome = DateTime.Parse(dateDebt);
            incomeInfo.ValueIncome = long.Parse(valueDebt);
            incomeInfo.TypeIncome = "9";
            incomeInfo.NoteIncome = "Khoản nợ| Người cho vay: " + humanDebt + " ; Note: " + note;

            debtInfo.UserId = int.Parse(userId);
            debtInfo.DateDebt = DateTime.Parse(dateDebt);
            debtInfo.HumanDebt = humanDebt;
            debtInfo.ValueDebt = long.Parse(valueDebt);
            debtInfo.StatusDebt = "0";
            debtInfo.NoteDebt = note;
            debtInfo.PathImgDebt = pathImgDebt;

            con.Open();
            trans = con.BeginTransaction();
            try
            {
                IncomeModels.InsertIncome(con, trans, incomeInfo);
                debtInfo.IncomeId = IncomeModels.GetLastestIncomeId(con, trans);
                DebtModel.InsertDebt(con, trans, debtInfo);
                this.codeAlert.InnerHtml = Constants.HTML_SUCCESS_IMPORT_DEBT;
                Response.Write(Constants.SCRIPT_ALERT_CLOSE);
                trans.Commit();

                DataTable dtDebt = DebtModel.GetDebtInfo(int.Parse(userId), searchCondition);
                ElementDebt.InnerHtml = CreateDebtInfoElement(dtDebt).ToString();
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

        private void SubmitLoan_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            SqlTransaction trans = null;

            SpendingEntity spendingInfo = new SpendingEntity();
            LoanEntity loanInfo = new LoanEntity();

            string dateLoan = this.DateLoan.Text.Trim();
            string humanLoan = this.HumanLoan.Text.Trim();
            string valueLoan = this.ValueLoan.Text.Trim();
            string note = this.NoteLoan.Text.Trim();
            string pathImgLoan = string.Empty;
            if (this.OFileLoan.HasFile)
            {
                string fileName = this.OFileLoan.FileName;
                string folderPath = Server.MapPath("~/Images");
                pathImgLoan = "~/Images/" + fileName;
                string storeImage = Path.Combine(folderPath, fileName);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                this.OFileLoan.SaveAs(storeImage);
            }

            spendingInfo.UserId = int.Parse(userId);
            spendingInfo.DateSpending = DateTime.Parse(dateLoan);
            spendingInfo.ValueSpending = long.Parse(valueLoan);
            spendingInfo.TypeSpending = "9";
            spendingInfo.NoteSpending = "Khoản cho vay| Người vay: " + humanLoan + " ; Note: " + note;

            loanInfo.UserId = int.Parse(userId);
            loanInfo.DateLoan = DateTime.Parse(dateLoan);
            loanInfo.HumanLoan = humanLoan;
            loanInfo.ValueLoan = long.Parse(valueLoan);
            loanInfo.StatusLoan = "0";
            loanInfo.NoteLoan = note;
            loanInfo.PathImgLoan = pathImgLoan;

            con.Open();
            trans = con.BeginTransaction();
            try
            {
                SpendingModel.InsertSpending(con, trans, spendingInfo);
                loanInfo.SpendingId = SpendingModel.GetLastestSpendingId(con, trans);
                LoanModel.InsertLoan(con, trans, loanInfo);
                this.codeAlert.InnerHtml = Constants.HTML_SUCCESS_IMPORT_LOAN;
                Response.Write(Constants.SCRIPT_ALERT_CLOSE);
                trans.Commit();

                dtLoan = LoanModel.GetLoanInfo(int.Parse(userId), searchCondition);
                ElementLoan.InnerHtml = CreateLoanInfoElement(dtLoan).ToString();
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

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            setSearchCondition();
            setDispDetail();
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

        private StringBuilder CreateLoanInfoElement(DataTable dtLoan)
        {
            StringBuilder element = new StringBuilder();
            foreach (DataRow row in dtLoan.Rows)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("<div class='card {0}'>", row["STATUS_LOAN"].ToString() == "0" ? "card-loan" : "card-loan-done"));
                sb.Append(string.Format("<div class='card-header' id='headingLoan{0}'>", row["LOAN_ID"].ToString()));
                sb.Append("<h5 class='mb-0'>");
                sb.Append("<div class='container'>");
                sb.Append("<div class='row'>");
                sb.Append("<div class='col'>");
                sb.Append(row["DATE_LOAN"].ToString());
                sb.Append("</div>");
                sb.Append("<div class='col'>");
                sb.Append(row["HUMAN_LOAN"].ToString());
                sb.Append("</div>");
                sb.Append("<div class='col'>");
                sb.Append(long.Parse(row["VALUE_LOAN"].ToString()).ToString("###,###"));
                sb.Append(" VND</div>");
                sb.Append("<div class='col'>");
                sb.Append(string.Format("{0} <i class='fa {1}' style='font-size: 20px; color: {2}'></i>", row["STATUS_LOAN"].ToString() == "0" ? "Chưa trả" : "Đã trả", row["STATUS_LOAN"].ToString() == "0" ? "fa-times-circle-o" : "fa-check-circle", row["STATUS_LOAN"].ToString() == "0" ? "red" : "yellow"));
                sb.Append("</div>");
                sb.Append("<div class='col'>");
                sb.Append(string.Format("<a class='btn btn-link' data-toggle='collapse' data-target='#collapseLoan{0}' aria-expanded='true' aria-controls='collapseOne' style='color:#00b8e6'>#Xem Chi tiết</a>", row["LOAN_ID"].ToString()));
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</h5>");
                sb.Append("</div>");
                sb.Append(string.Format("<div id='collapseLoan{0}' class='collapse' aria-labelledby='headingLoan{0}' data-parent='#accordion' runat='server'>", row["LOAN_ID"].ToString()));
                sb.Append("<div class='card-body'>");
                sb.Append("<div class='container'>");
                sb.Append("<div class='row'>");
                sb.Append("<div class='col' style='word-wrap: normal; word-break: break-all;'><h5>Note: ");
                sb.Append(row["NOTE_LOAN"].ToString());
                sb.Append("</h5></div>");
                if (row["PATH_IMG_LOAN"].ToString() != string.Empty)
                {
                    sb.Append("<div class='col'>");
                    sb.Append(string.Format("<img src='{0}' class='img-thumbnail' alt='...' onclick=\"window.open('{1}', '_blank');\">", row["PATH_IMG_LOAN"].ToString().Replace("~", ".."), row["PATH_IMG_LOAN"].ToString().Replace("~/", "")));
                    sb.Append("</div>");
                }
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");
                if (row["STATUS_LOAN"].ToString() == "1")
                {
                    sb.Append("<hr style='color: rgb(54, 109, 138);'>");
                    sb.Append("<div class='container'>");
                    sb.Append("<div class='row'>");
                    sb.Append("<div class='col' style='word-wrap: normal; word-break: break-all;'>");
                    sb.Append(string.Format("<h4>Đã trả ngày : {0}</h4><h5>Note: ", row["DATE_LOAN_FINISH"].ToString()));
                    sb.Append(row["NOTE_LOAN_FINISH"].ToString());
                    sb.Append("</h5></div>");
                    if (row["PATH_IMG_LOAN_FINISH"].ToString() != string.Empty)
                    {
                        sb.Append("<div class='col'>");
                        sb.Append(string.Format("<img src='{0}' class='img-thumbnail' alt='...' onclick=\"window.open('{1}', '_blank');\">", row["PATH_IMG_LOAN_FINISH"].ToString().Replace("~", ".."), row["PATH_IMG_LOAN_FINISH"].ToString().Replace("~/", "")));
                        sb.Append("</div>");
                    }
                    sb.Append("</div>");
                    sb.Append("</div>");
                }
                sb.Append("<hr style='color: rgb(54, 109, 138);'>");
                sb.Append(string.Format("<button type='button' class='btn btn-outline-danger btn-row' onclick='DeleteLoan({0});return false;'>Delete</button>", row["LOAN_ID"].ToString()));
                sb.Append(string.Format("<button type='button' class='btn btn-outline-primary btn-row' onclick=\"OpenEditWindow('loan', {0})\">Edit</button>", row["LOAN_ID"].ToString()));
                sb.Append("</div>");
                sb.Append("</div>");
                element.Append(sb.ToString());
            }

            return element;
        }

        private StringBuilder CreateDebtInfoElement(DataTable dtDebt)
        {
            StringBuilder element = new StringBuilder();
            foreach (DataRow row in dtDebt.Rows)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("<div class='card {0}'>", row["STATUS_DEBT"].ToString() == "0" ? "card-debt" : "card-debt-done"));
                sb.Append(string.Format("<div class='card-header' id='headingDebt{0}'>", row["DEBT_ID"].ToString()));
                sb.Append("<h5 class='mb-0'>");
                sb.Append("<div class='container'>");
                sb.Append("<div class='row'>");
                sb.Append("<div class='col'>");
                sb.Append(row["DATE_DEBT"].ToString());
                sb.Append("</div>");
                sb.Append("<div class='col'>");
                sb.Append(row["HUMAN_DEBT"].ToString());
                sb.Append("</div>");
                sb.Append("<div class='col'>");
                sb.Append(long.Parse(row["VALUE_DEBT"].ToString()).ToString("###,###"));
                sb.Append(" VND</div>");
                sb.Append("<div class='col'>");
                sb.Append(string.Format("{0} <i class='fa {1}' style='font-size: 20px; color: {2}'></i>", row["STATUS_DEBT"].ToString() == "0" ? "Chưa trả" : "Đã trả", row["STATUS_DEBT"].ToString() == "0" ? "fa-times-circle-o" : "fa-check-circle", row["STATUS_DEBT"].ToString() == "0" ? "red" : "yellow"));
                sb.Append("</div>");
                sb.Append("<div class='col'>");
                sb.Append(string.Format("<a class='btn btn-link' data-toggle='collapse' data-target='#collapseDebt{0}' aria-expanded='true' aria-controls='collapseOne' style='color:#00b8e6'>#Xem Chi tiết</a>", row["DEBT_ID"].ToString()));
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</h5>");
                sb.Append("</div>");
                //sb.Append("</div>");
                sb.Append(string.Format("<div id='collapseDebt{0}' class='collapse' aria-labelledby='headingDebt{0}' data-parent='#accordion' runat='server'>", row["DEBT_ID"].ToString()));
                sb.Append("<div class='card-body'>");
                sb.Append("<div class='container'>");
                sb.Append("<div class='row'>");
                sb.Append("<div class='col' style='word-wrap: normal; word-break: break-all;'><h5>Note: ");
                sb.Append(row["NOTE_DEBT"].ToString());
                sb.Append("</h5></div>");
                if (row["PATH_IMG_DEBT"].ToString() != string.Empty)
                {
                    sb.Append("<div class='col'>");
                    sb.Append(string.Format("<img src='{0}' class='img-thumbnail' alt='...' onclick=\"window.open('{1}', '_blank');\">", row["PATH_IMG_DEBT"].ToString().Replace("~", ".."), row["PATH_IMG_DEBT"].ToString().Replace("~/", "")));
                    sb.Append("</div>");
                }
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");
                if (row["STATUS_DEBT"].ToString() == "1")
                {
                    sb.Append("<hr style='color: rgb(54, 109, 138);'>");
                    sb.Append("<div class='container'>");
                    sb.Append("<div class='row'>");
                    sb.Append("<div class='col' style='word-wrap: normal; word-break: break-all;'>");
                    sb.Append(string.Format("<h4>Đã trả ngày : {0}</h4><h5>Note: ", row["DATE_DEBT_FINISH"].ToString()));
                    sb.Append(row["NOTE_DEBT_FINISH"].ToString());
                    sb.Append("</h5></div>");
                    if (row["PATH_IMG_DEBT_FINISH"].ToString() != string.Empty)
                    {
                        sb.Append("<div class='col'>");
                        sb.Append(string.Format("<img src='{0}' class='img-thumbnail' alt='...' onclick=\"window.open('{1}', '_blank');\">", row["PATH_IMG_DEBT_FINISH"].ToString().Replace("~", ".."), row["PATH_IMG_DEBT_FINISH"].ToString().Replace("~/", "")));
                        sb.Append("</div>");
                    }
                    sb.Append("</div>");
                    sb.Append("</div>");
                }
                sb.Append("<hr style='color: rgb(54, 109, 138);'>");
                sb.Append(string.Format("<button type='button' class='btn btn-outline-danger btn-row' onclick='DeleteDebt({0});return false;'>Delete</button>", row["DEBT_ID"].ToString()));
                sb.Append(string.Format("<button type='button' class='btn btn-outline-primary btn-row' onclick=\"OpenEditWindow('debt', {0})\">Edit</button>", row["DEBT_ID"].ToString()));
                sb.Append("</div>");
                sb.Append("</div>");
                element.Append(sb.ToString());
            }

            return element;
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

        private void setDispDetail()
        {
            try
            {
                dtLoan = LoanModel.GetLoanInfo(int.Parse(userId), searchCondition);
                ElementLoan.InnerHtml = CreateLoanInfoElement(dtLoan).ToString();

                dtDebt = DebtModel.GetDebtInfo(int.Parse(userId), searchCondition);
                ElementDebt.InnerHtml = CreateDebtInfoElement(dtDebt).ToString();
            }
            catch (Exception ex)
            {
                Response.Redirect("ErrorPage.aspx?message=" + ex.GetType().Name + ex.Message);
            }
        }

        protected void btnDeleteLoan_Click(object sender, EventArgs e)
        {
            string id = this.IdDelete.Value;
            bool check = LoanModel.DeleteLoan(int.Parse(id));
            if (check)
            {
                setDispDetail();
                this.codeAlert.InnerHtml = Constants.HTML_SUCCESS_DELETE_LOAN;
                Response.Write(Constants.SCRIPT_ALERT_CLOSE);
            }
            else
            {
                this.codeAlert.InnerHtml = Constants.HTML_SUCCESS_DELETE_LOAN;
                Response.Write(Constants.SCRIPT_ALERT_CLOSE);
            }
        }

        protected void btnDeleteDebt_Click(object sender, EventArgs e)
        {
            string id = this.IdDelete.Value;
            bool check = DebtModel.DeleteDebt(int.Parse(id));
            if (check)
            {
                setDispDetail();
                this.codeAlert.InnerHtml = Constants.HTML_SUCCESS_DELETE_DEBT;
                Response.Write(Constants.SCRIPT_ALERT_CLOSE);
            }
            else
            {
                this.codeAlert.InnerHtml = Constants.HTML_SUCCESS_DELETE_DEBT;
                Response.Write(Constants.SCRIPT_ALERT_CLOSE);
            }
        }

    }
}