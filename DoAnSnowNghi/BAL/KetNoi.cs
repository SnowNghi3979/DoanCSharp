using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DoAnSnowNghi.BAL
{
    public partial class KetNoi : DbContext
    {
        internal IEnumerable<object> HoaDonBan;

        public KetNoi()
            : base("name=KetNoi")
        {
        }

        public virtual DbSet<Chatlieu1> Chatlieu1 { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<Hang1> Hang1 { get; set; }
        public virtual DbSet<HoaDonBan> HoaDonBans { get; set; }
        public virtual DbSet<Khach2> Khach2 { get; set; }
        public virtual DbSet<NguoiDung1> NguoiDung1 { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chatlieu1>()
                .Property(e => e.Machatlieu)
                .IsUnicode(false);
        }
    }
}
