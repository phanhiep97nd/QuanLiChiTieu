using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiChiTieuWebForm.Model
{
    public class LoanEntity
    {
        private int userId;
        private int spendingId;
        private int LoanId;
        private long valueLoan;
        private string humanLoan;
        private DateTime dateLoan;
        private string statusLoan;
        private string noteLoan;
        private string pathImgLoan;
        private DateTime dateLoanFinish;
        private string noteLoanFinish;
        private string pathImgLoanFinish;

        public int UserId { get => userId; set => userId = value; }
        public int SpendingId { get => spendingId; set => spendingId = value; }
        public int LoanId1 { get => LoanId; set => LoanId = value; }
        public long ValueLoan { get => valueLoan; set => valueLoan = value; }
        public string HumanLoan { get => humanLoan; set => humanLoan = value; }
        public DateTime DateLoan { get => dateLoan; set => dateLoan = value; }
        public string StatusLoan { get => statusLoan; set => statusLoan = value; }
        public string NoteLoan { get => noteLoan; set => noteLoan = value; }
        public string PathImgLoan { get => pathImgLoan; set => pathImgLoan = value; }
        public DateTime DateLoanFinish { get => dateLoanFinish; set => dateLoanFinish = value; }
        public string NoteLoanFinish { get => noteLoanFinish; set => noteLoanFinish = value; }
        public string PathImgLoanFinish { get => pathImgLoanFinish; set => pathImgLoanFinish = value; }
    }
}