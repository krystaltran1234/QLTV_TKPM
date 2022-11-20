using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLTV_TKPM.Models;

namespace QLTV_TKPM.Data
{
    public class QLTV_TKPMContext : DbContext
    {
        public QLTV_TKPMContext (DbContextOptions<QLTV_TKPMContext> options)
            : base(options)
        {
        }


        public DbSet<QLTV_TKPM.Models.Thoihanthe> Thoihanthe { get; set; }

        public DbSet<QLTV_TKPM.Models.Theloaisach> Theloaisach { get; set; }

        public DbSet<QLTV_TKPM.Models.Loaidocgia> Loaidocgia { get; set; }

        public DbSet<QLTV_TKPM.Models.Docgia> Docgia { get; set; }

        public DbSet<QLTV_TKPM.Models.Sach> Sach { get; set; }

        public DbSet<QLTV_TKPM.Models.Tuoidocgia> Tuoidocgia { get; set; }

        public DbSet<QLTV_TKPM.Models.Soluongsachmuon> Soluongsachmuon { get; set; }

        public DbSet<QLTV_TKPM.Models.Phieumuonsach> Phieumuonsach { get; set; }

        public DbSet<QLTV_TKPM.Models.Phieumuonchitiet> Phieumuonchitiet { get; set; }

        public DbSet<QLTV_TKPM.Models.Namxuatban> Namxuatban { get; set; }
    }
}
