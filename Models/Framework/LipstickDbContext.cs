using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.Framework
{
    public partial class LipstickDbContext : DbContext
    {
        public LipstickDbContext()
            : base("name=LipstickDbContext")
        {
        }

        public virtual DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }
        public virtual DbSet<KichCo> KichCoes { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<MauSac> MauSacs { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<SanPham> ChiTietSanPham { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietSanPham>()
                .Property(e => e.Gia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.Gia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietSanPhams)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);
        }

        
    }
}
