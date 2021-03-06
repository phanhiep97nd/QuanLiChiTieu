using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiChiTieu.Models
{
    public class IncomeEntity
    {
        private int userId;
        private long valueIncome;
        private string typeIncome;
        private DateTime dateIncome;
        private string noteIncome;
        private int incomeId;

        public int UserId { get => userId; set => userId = value; }
        public long ValueIncome { get => valueIncome; set => valueIncome = value; }
        public string TypeIncome { get => typeIncome; set => typeIncome = value; }
        public DateTime DateIncome { get => dateIncome; set => dateIncome = value; }
        public string NoteIncome { get => noteIncome; set => noteIncome = value; }
        public int IncomeId { get => incomeId; set => incomeId = value; }
    }
}
