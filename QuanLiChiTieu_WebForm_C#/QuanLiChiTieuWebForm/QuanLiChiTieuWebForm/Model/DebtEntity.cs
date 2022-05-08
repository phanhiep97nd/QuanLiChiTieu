using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiChiTieuWebForm.Model
{
    public class DebtEntity
    {
        private int userId;
        private int incomeId;
        private int DebtId;
        private long valueDebt;
        private string humanDebt;
        private DateTime dateDebt;
        private string statusDebt;
        private string noteDebt;
        private string pathImgDebt;
        private DateTime dateDebtFinish;
        private string noteDebtFinish;
        private string pathImgDebtFinish;

        public int UserId { get => userId; set => userId = value; }
        public int IncomeId { get => incomeId; set => incomeId = value; }
        public int DebtId1 { get => DebtId; set => DebtId = value; }
        public long ValueDebt { get => valueDebt; set => valueDebt = value; }
        public string HumanDebt { get => humanDebt; set => humanDebt = value; }
        public DateTime DateDebt { get => dateDebt; set => dateDebt = value; }
        public string StatusDebt { get => statusDebt; set => statusDebt = value; }
        public string NoteDebt { get => noteDebt; set => noteDebt = value; }
        public string PathImgDebt { get => pathImgDebt; set => pathImgDebt = value; }
        public DateTime DateDebtFinish { get => dateDebtFinish; set => dateDebtFinish = value; }
        public string NoteDebtFinish { get => noteDebtFinish; set => noteDebtFinish = value; }
        public string PathImgDebtFinish { get => pathImgDebtFinish; set => pathImgDebtFinish = value; }
    }
}