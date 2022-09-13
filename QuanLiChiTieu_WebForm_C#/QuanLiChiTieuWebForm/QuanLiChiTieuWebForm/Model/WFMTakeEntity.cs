using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiChiTieuWebForm.Model
{
    public class WFMTakeEntity
    {
        private int userId;
        private int incomeId;
        private int giveId;
        private long valueTake;
        private string humanTake;
        private string groupTake;
        private string typeTake;
        private DateTime dateTake;
        private string statusTake;
        private string noteTake;
        private DateTime dateTakeFinish;
        private string noteTakeFinish;

        public int UserId { get => userId; set => userId = value; }
        public int IncomeId { get => incomeId; set => incomeId = value; }
        public int GiveId { get => giveId; set => giveId = value; }
        public long ValueTake { get => valueTake; set => valueTake = value; }
        public string HumanTake { get => humanTake; set => humanTake = value; }
        public string GroupTake { get => groupTake; set => groupTake = value; }
        public DateTime DateTake { get => dateTake; set => dateTake = value; }
        public string StatusTake { get => statusTake; set => statusTake = value; }
        public string NoteTake { get => noteTake; set => noteTake = value; }
        public DateTime DateTakeFinish { get => dateTakeFinish; set => dateTakeFinish = value; }
        public string NoteTakeFinish { get => noteTakeFinish; set => noteTakeFinish = value; }
        public string TypeTake { get => typeTake; set => typeTake = value; }
    }
}