using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entity;

namespace QLTV_TKPM.Data
{
    public class QLTV_TKPMContext : DbContext
    {
        public QLTV_TKPMContext (DbContextOptions<QLTV_TKPMContext> options)
            : base(options)
        {
        }


        public DbSet<Thoihanthe> Thoihanthe { get; set; }

        public DbSet<Theloaisach> Theloaisach { get; set; }

        public DbSet<Loaidocgia> Loaidocgia { get; set; }

        public DbSet<Docgia> Docgia { get; set; }

        public DbSet<Sach> Sach { get; set; }

        public DbSet<Tuoidocgia> Tuoidocgia { get; set; }

        public DbSet<Soluongsachmuon> Soluongsachmuon { get; set; }

        public DbSet<Phieumuonsach> Phieumuonsach { get; set; }

        public DbSet<Phieumuonchitiet> Phieumuonchitiet { get; set; }

        public DbSet<Namxuatban> Namxuatban { get; set; }
    }
}
