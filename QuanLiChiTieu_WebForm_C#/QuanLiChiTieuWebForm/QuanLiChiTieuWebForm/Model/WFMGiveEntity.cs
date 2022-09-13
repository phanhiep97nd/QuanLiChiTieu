using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiChiTieuWebForm.Model
{
    public class WFMGiveEntity
    {
        private int userId;
        private int spendingId;
        private int giveId;
        private long valueGive;
        private string humanGive;
        private string groupGive;
        private string typeGive;
        private DateTime dateGive;
        private string statusGive;
        private string noteGive;
        private DateTime dateGiveFinish;
        private string noteGiveFinish;

        public int UserId { get => userId; set => userId = value; }
        public int SpendingId { get => spendingId; set => spendingId = value; }
        public int GiveId { get => giveId; set => giveId = value; }
        public long ValueGive { get => valueGive; set => valueGive = value; }
        public string HumanGive { get => humanGive; set => humanGive = value; }
        public string GroupGive { get => groupGive; set => groupGive = value; }
        public DateTime DateGive { get => dateGive; set => dateGive = value; }
        public string StatusGive { get => statusGive; set => statusGive = value; }
        public string NoteGive { get => noteGive; set => noteGive = value; }
        public DateTime DateGiveFinish { get => dateGiveFinish; set => dateGiveFinish = value; }
        public string NoteGiveFinish { get => noteGiveFinish; set => noteGiveFinish = value; }
        public string TypeGive { get => typeGive; set => typeGive = value; }
    }
}