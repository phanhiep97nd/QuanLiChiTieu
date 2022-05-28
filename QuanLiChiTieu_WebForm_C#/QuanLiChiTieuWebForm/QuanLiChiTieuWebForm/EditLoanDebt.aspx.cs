using QuanLiChiTieuWebForm.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
                this.TypeEditLabel.Text = typeEdit == "loan" ? "DANH SÁCH CHO VAY" : "DANH SÁCH NỢ";
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    idEdit = Request.QueryString["id"];
                }
                SetDispForm();
            }
            else
            {
                typeEdit = ViewState["typeEdit"].ToString();
                idEdit = ViewState["idEdit"].ToString();
            }
        }

        private void Page_PreRender(object sender, System.EventArgs e)
        {
            ViewState["typeEdit"] = typeEdit;
            ViewState["idEdit"] = idEdit;
        }

        #region Control's Event Handlers
        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            this.BtnDelImg.Click += BtnDelImg_Click;
            this.StatusEditCheckBox.CheckedChanged += StatusEditCheckBox_CheckedChanged;
            this.BtnDelImgFinish.Click += BtnDelImgFinish_Click;
            this.SubmitEditBtn.Click += SubmitEditBtn_Click;
        }

        private void SubmitEditBtn_Click(object sender, EventArgs e)
        {
            bool check = false;
            try
            {
                if (typeEdit == "loan")
                {
                    LoanEntity loanInfo = new LoanEntity();
                    loanInfo.LoanId1 = int.Parse(idEdit);
                    loanInfo.DateLoan = DateTime.Parse(this.DateEdit.Text);
                    loanInfo.HumanLoan = this.HumanEdit.Text;
                    loanInfo.ValueLoan = long.Parse(this.ValueEdit.Text);
                    loanInfo.NoteLoan = this.NoteEdit.Text;
                    if (this.OFileEdit.HasFile)
                    {
                        string fileName = this.OFileEdit.FileName;
                        string folderPath = Server.MapPath("~/Images");
                        loanInfo.PathImgLoan = "~/Images/" + fileName;
                        string storeImage = Path.Combine(folderPath, fileName);
                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }
                        this.OFileEdit.SaveAs(storeImage);
                    }
                    else
                    {
                        loanInfo.PathImgLoan = string.Empty;
                    }
                    loanInfo.StatusLoan = this.StatusEditCheckBox.Checked ? "1" : "0";
                    if (this.StatusEditCheckBox.Checked)
                    {
                        loanInfo.DateLoanFinish = DateTime.Parse(this.DateEditFinish.Text);
                        loanInfo.NoteLoanFinish = this.NoteEditFinish.Text;
                        if (this.OFileEditFinish.HasFile)
                        {
                            string fileName = this.OFileEditFinish.FileName;
                            string folderPath = Server.MapPath("~/Images");
                            loanInfo.PathImgLoanFinish = "~/Images/" + fileName;
                            string storeImage = Path.Combine(folderPath, fileName);
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }
                            this.OFileEditFinish.SaveAs(storeImage);
                        }
                        else
                        {
                            loanInfo.PathImgLoanFinish = "";
                        }
                    }
                    check = LoanModel.UpdateLoan(loanInfo);
                }
                else if (typeEdit == "debt")
                {
                    DebtEntity debtInfo = new DebtEntity();
                    debtInfo.DebtId1 = int.Parse(idEdit);
                    debtInfo.DateDebt = DateTime.Parse(this.DateEdit.Text);
                    debtInfo.HumanDebt = this.HumanEdit.Text;
                    debtInfo.ValueDebt = long.Parse(this.ValueEdit.Text);
                    debtInfo.NoteDebt = this.NoteEdit.Text;
                    if (this.OFileEdit.HasFile)
                    {
                        string fileName = this.OFileEdit.FileName;
                        string folderPath = Server.MapPath("~/Images");
                        debtInfo.PathImgDebt = "~/Images/" + fileName;
                        string storeImage = Path.Combine(folderPath, fileName);
                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }
                        this.OFileEdit.SaveAs(storeImage);
                    }
                    else
                    {
                        debtInfo.PathImgDebt = string.Empty;
                    }
                    debtInfo.StatusDebt = this.StatusEditCheckBox.Checked ? "1" : "0";
                    if (this.StatusEditCheckBox.Checked)
                    {
                        debtInfo.DateDebtFinish = DateTime.Parse(this.DateEditFinish.Text);
                        debtInfo.NoteDebtFinish = this.NoteEditFinish.Text;
                        if (this.OFileEditFinish.HasFile)
                        {
                            string fileName = this.OFileEditFinish.FileName;
                            string folderPath = Server.MapPath("~/Images");
                            debtInfo.PathImgDebtFinish = "~/Images/" + fileName;
                            string storeImage = Path.Combine(folderPath, fileName);
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }
                            this.OFileEditFinish.SaveAs(storeImage);
                        }
                        else
                        {
                            debtInfo.PathImgDebtFinish = "";
                        }
                    }
                    check = DebtModel.UpdateDebt(debtInfo);
                }
                if (check)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "closePopup", typeEdit == "loan" ? "closeUpdateWindow('loan')" : "closeUpdateWindow('debt')", true);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("ErrorPage.aspx?message=" + ex.GetType().Name + ex.Message);
            }
        }

        private void BtnDelImgFinish_Click(object sender, EventArgs e)
        {
            bool check = false;
            if (typeEdit == "loan")
            {
                check = LoanModel.DeleteImgLoan(int.Parse(idEdit), true);
            }
            else if (typeEdit == "debt")
            {
                check = DebtModel.DeleteImgDebt(int.Parse(idEdit), true);
            }
            if (check)
            {
                this.OFileEditFinish.Visible = true;
                this.PictureEditFinish.ImageUrl = string.Empty;
                this.BtnDelImgFinish.Visible = false;
                this.NotiDelImgFinish.InnerHtml = ">> Ảnh đã xóa";
            }
        }

        private void StatusEditCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.StatusEditCheckBox.Checked)
            {
                this.FinishRegion.Visible = true;
            }
            else
            {
                this.FinishRegion.Visible = false;
            }
        }

        private void BtnDelImg_Click(object sender, EventArgs e)
        {
            bool check = false;
            if (typeEdit == "loan")
            {
                check = LoanModel.DeleteImgLoan(int.Parse(idEdit), false);
            }
            else if (typeEdit == "debt")
            {
                check = DebtModel.DeleteImgDebt(int.Parse(idEdit), false);
            }
            if (check)
            {
                this.OFileEdit.Visible = true;
                this.PictureEdit.ImageUrl = string.Empty;
                this.BtnDelImg.Visible = false;
                this.NotiDelImg.InnerHtml = ">> Ảnh đã xóa";
            }
        }
        #endregion

        private void SetDispForm()
        {
            if (typeEdit.Equals("loan"))
            {
                DataTable dtLoan = LoanModel.GetLoanById(int.Parse(idEdit));
                this.DateEdit.Text = DateTime.Parse(dtLoan.Rows[0]["DATE_LOAN"].ToString()).ToString("yyyy-MM-dd");
                this.HumanEdit.Text = dtLoan.Rows[0]["HUMAN_LOAN"].ToString();
                this.ValueEdit.Text = dtLoan.Rows[0]["VALUE_LOAN"].ToString();
                this.NoteEdit.Text = dtLoan.Rows[0]["NOTE_LOAN"].ToString();
                this.PictureEdit.ImageUrl = dtLoan.Rows[0]["PATH_IMG_LOAN"].ToString().Replace('~', '.');
                if (dtLoan.Rows[0]["PATH_IMG_LOAN"].ToString() == string.Empty)
                {
                    this.BtnDelImg.Visible = false;
                    this.OFileEdit.Visible = true;
                }
                else
                {
                    this.BtnDelImg.Visible = true;
                    this.OFileEdit.Visible = false;
                }
                if (dtLoan.Rows[0]["STATUS_LOAN"].ToString() == "1")
                {
                    this.StatusEditCheckBox.Checked = true;
                    this.FinishRegion.Visible = true;
                    this.DateEditFinish.Text = DateTime.Parse(dtLoan.Rows[0]["DATE_LOAN_FINISH"].ToString()).ToString("yyyy-MM-dd");
                    this.NoteEditFinish.Text = dtLoan.Rows[0]["NOTE_LOAN_FINISH"].ToString();
                    this.PictureEditFinish.ImageUrl = dtLoan.Rows[0]["PATH_IMG_LOAN_FINISH"].ToString().Replace('~', '.');
                    if (dtLoan.Rows[0]["PATH_IMG_LOAN_FINISH"].ToString() == string.Empty)
                    {
                        this.BtnDelImgFinish.Visible = false;
                        this.OFileEditFinish.Visible = true;
                    }
                    else
                    {
                        this.BtnDelImgFinish.Visible = true;
                        this.OFileEditFinish.Visible = false;
                    }
                }
                else
                {
                    this.StatusEditCheckBox.Checked = false;
                    this.FinishRegion.Visible = false;
                    this.BtnDelImgFinish.Visible = false;
                }
            }
            else if (typeEdit.Equals("debt"))
            {
                DataTable dtDebt = DebtModel.GetDebtById(int.Parse(idEdit));
                this.DateEdit.Text = DateTime.Parse(dtDebt.Rows[0]["DATE_DEBT"].ToString()).ToString("yyyy-MM-dd");
                this.HumanEdit.Text = dtDebt.Rows[0]["HUMAN_DEBT"].ToString();
                this.ValueEdit.Text = dtDebt.Rows[0]["VALUE_DEBT"].ToString();
                this.NoteEdit.Text = dtDebt.Rows[0]["NOTE_DEBT"].ToString();
                this.PictureEdit.ImageUrl = dtDebt.Rows[0]["PATH_IMG_DEBT"].ToString().Replace('~', '.');
                if (dtDebt.Rows[0]["PATH_IMG_DEBT"].ToString() == string.Empty)
                {
                    this.BtnDelImg.Visible = false;
                    this.OFileEdit.Visible = true;
                }
                else
                {
                    this.BtnDelImg.Visible = true;
                    this.OFileEdit.Visible = false;
                }
                if (dtDebt.Rows[0]["STATUS_DEBT"].ToString() == "1")
                {
                    this.StatusEditCheckBox.Checked = true;
                    this.FinishRegion.Visible = true;
                    this.DateEditFinish.Text = DateTime.Parse(dtDebt.Rows[0]["DATE_DEBT_FINISH"].ToString()).ToString("yyyy-MM-dd");
                    this.NoteEditFinish.Text = dtDebt.Rows[0]["NOTE_DEBT_FINISH"].ToString();
                    this.PictureEditFinish.ImageUrl = dtDebt.Rows[0]["PATH_IMG_DEBT_FINISH"].ToString().Replace('~', '.');
                    if (dtDebt.Rows[0]["PATH_IMG_DEBT_FINISH"].ToString() == string.Empty)
                    {
                        this.BtnDelImgFinish.Visible = false;
                        this.OFileEditFinish.Visible = true;
                    }
                    else
                    {
                        this.BtnDelImgFinish.Visible = true;
                        this.OFileEditFinish.Visible = false;
                    }
                }
                else
                {
                    this.StatusEditCheckBox.Checked = false;
                    this.FinishRegion.Visible = false;
                    this.BtnDelImgFinish.Visible = false;
                }
            }
        }
    }
}