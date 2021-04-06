using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiChiTieu.Models
{
    public class Context : DbContext
    {
        public DbSet<UserInfo> UserInfos { get; set; }
    }
}
