using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiChiTieu.Models
{
    public class UserInfo
    {
        private int id;
        private string loginName;
        private string pass;
        private string endCodePass;
        private string loginTime;
        private int loginStatus;

        public int Id { get => id; set => id = value; }
        public string LoginName { get => loginName; set => loginName = value; }
        public string Pass { get => pass; set => pass = value; }
        public string EndCodePass { get => endCodePass; set => endCodePass = value; }
        public string LoginTime { get => loginTime; set => loginTime = value; }
        public int LoginStatus { get => loginStatus; set => loginStatus = value; }
    }
}
