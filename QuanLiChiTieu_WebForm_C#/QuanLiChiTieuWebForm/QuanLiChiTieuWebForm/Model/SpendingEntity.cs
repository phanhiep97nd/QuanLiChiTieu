using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiChiTieu.Models
{
    public class SpendingEntity
    {
        private int userId;
        private long valueSpending;
        private string typeSpending;
        private DateTime dateSpending;
        private string noteSpending;
        private int spendingId;

        public int UserId { get => userId; set => userId = value; }
        public long ValueSpending { get => valueSpending; set => valueSpending = value; }
        public string TypeSpending { get => typeSpending; set => typeSpending = value; }
        public DateTime DateSpending { get => dateSpending; set => dateSpending = value; }
        public string NoteSpending { get => noteSpending; set => noteSpending = value; }
        public int SpendingId { get => spendingId; set => spendingId = value; }
    }
}
