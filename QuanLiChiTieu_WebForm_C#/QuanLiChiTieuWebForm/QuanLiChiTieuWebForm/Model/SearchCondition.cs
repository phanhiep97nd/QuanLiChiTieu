using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLiChiTieuWebForm.Model
{
    [Serializable]
    public class SearchCondition
    {
        private bool isViewAllOfYear;
        private string monthSearch;
        private string yearSearch;
        private string statusSearch;
        private string nameSearch;

        public bool IsViewAllOfYear { get => isViewAllOfYear; set => isViewAllOfYear = value; }
        public string MonthSearch { get => monthSearch; set => monthSearch = value; }
        public string YearSearch { get => yearSearch; set => yearSearch = value; }
        public string StatusSearch { get => statusSearch; set => statusSearch = value; }
        public string NameSearch { get => nameSearch; set => nameSearch = value; }
    }
}