using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiChiTieu.Models
{
    public class IncomeEntity
    {
        private int userId;
        private int valueIncome;
        private string typeIncome;
        private DateTime dateIncome;
        private string noteIncome;

        public int UserId { get => userId; set => userId = value; }
        public int ValueIncome { get => valueIncome; set => valueIncome = value; }
        public string TypeIncome { get => typeIncome; set => typeIncome = value; }
        public DateTime DateIncome { get => dateIncome; set => dateIncome = value; }
        public string NoteIncome { get => noteIncome; set => noteIncome = value; }
    }
}
