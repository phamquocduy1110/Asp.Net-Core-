using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Buoi17_First.Entities
{
    public partial class eStore20Context : DbContext
    {
        public eStore20Context()
        {
        }

        public eStore20Context(DbContextOptions<eStore20Context> options)
            : base(options)
        {
        }

        public virtual DbSet<BanBe> BanBes { get; set; } = null!;
        public virtual DbSet<CauHinh> CauHinhs { get; set; } = null!;
        public virtual DbSet<ChiTietHd> ChiTietHds { get; set; } = null!;
        public virtual DbSet<ChuDe> ChuDes { get; set; } = null!;
        public virtual DbSet<GopY> Gopies { get; set; } = null!;
        public virtual DbSet<HangHoa> HangHoas { get; set; } = null!;
        public virtual DbSet<HoaDon> HoaDons { get; set; } = null!;
        public virtual DbSet<HoiDap> HoiDaps { get; set; } = null!;
        public virtual DbSet<KhachHang> KhachHangs { get; set; } = null!;
        public virtual DbSet<Loai> Loais { get; set; } = null!;
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; } = null!;
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; } = null!;
        public virtual DbSet<NhanVien> NhanViens { get; set; } = null!;
        public virtual DbSet<VHangHoa> VHangHoas { get; set; } = null!;
        public virtual DbSet<VHoaDon> VHoaDons { get; set; } = null!;
        public virtual DbSet<YeuThich> YeuThiches { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-2TJNS3V\\MSSQL2019;Database=eStore20;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BanBe>(entity =>
            {
                entity.HasKey(e => e.MaBb)
                    .HasName("PK_Promotions");

                entity.ToTable("BanBe");

                entity.Property(e => e.MaBb).HasColumnName("MaBB");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.Property(e => e.MaHh).HasColumnName("MaHH");

                entity.Property(e => e.MaKh)
                    .HasMaxLength(20)
                    .HasColumnName("MaKH");

                entity.Property(e => e.NgayGui)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.MaHhNavigation)
                    .WithMany(p => p.BanBes)
                    .HasForeignKey(d => d.MaHh)
                    .HasConstraintName("FK_QuangBa_HangHoa");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.BanBes)
                    .HasForeignKey(d => d.MaKh)
                    .HasConstraintName("FK_BanBe_KhachHang");
            });

            modelBuilder.Entity<CauHinh>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CauHinh");

                entity.Property(e => e.SoNgayHetHanQc).HasColumnName("SoNgayHetHanQC");
            });

            modelBuilder.Entity<ChiTietHd>(entity =>
            {
                entity.HasKey(e => e.MaCt)
                    .HasName("PK_OrderDetails");

                entity.ToTable("ChiTietHD");

                entity.Property(e => e.MaCt).HasColumnName("MaCT");

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.MaHh).HasColumnName("MaHH");

                entity.Property(e => e.SoLuong).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.MaHdNavigation)
                    .WithMany(p => p.ChiTietHds)
                    .HasForeignKey(d => d.MaHd)
                    .HasConstraintName("FK_OrderDetails_Orders");

                entity.HasOne(d => d.MaHhNavigation)
                    .WithMany(p => p.ChiTietHds)
                    .HasForeignKey(d => d.MaHh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Products");
            });

            modelBuilder.Entity<ChuDe>(entity =>
            {
                entity.HasKey(e => e.MaCd);

                entity.ToTable("ChuDe");

                entity.Property(e => e.MaCd).HasColumnName("MaCD");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(50)
                    .HasColumnName("MaNV");

                entity.Property(e => e.TenCd)
                    .HasMaxLength(50)
                    .HasColumnName("TenCD");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.ChuDes)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ChuDe_NhanVien");
            });

            modelBuilder.Entity<GopY>(entity =>
            {
                entity.HasKey(e => e.MaGy);

                entity.ToTable("GopY");

                entity.Property(e => e.MaGy)
                    .HasMaxLength(50)
                    .HasColumnName("MaGY");

                entity.Property(e => e.DienThoai).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.Property(e => e.MaCd).HasColumnName("MaCD");

                entity.Property(e => e.NgayGy)
                    .HasColumnType("date")
                    .HasColumnName("NgayGY")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NgayTl)
                    .HasColumnType("date")
                    .HasColumnName("NgayTL");

                entity.Property(e => e.TraLoi).HasMaxLength(50);

                entity.HasOne(d => d.MaCdNavigation)
                    .WithMany(p => p.Gopies)
                    .HasForeignKey(d => d.MaCd)
                    .HasConstraintName("FK_GopY_ChuDe");
            });

            modelBuilder.Entity<HangHoa>(entity =>
            {
                entity.HasKey(e => e.MaHh)
                    .HasName("PK_Products");

                entity.ToTable("HangHoa");

                entity.Property(e => e.MaHh).HasColumnName("MaHH");

                entity.Property(e => e.DonGia).HasDefaultValueSql("((0))");

                entity.Property(e => e.Hinh).HasMaxLength(50);

                entity.Property(e => e.MaNcc)
                    .HasMaxLength(50)
                    .HasColumnName("MaNCC");

                entity.Property(e => e.MoTaDonVi).HasMaxLength(50);

                entity.Property(e => e.NgaySx)
                    .HasColumnType("datetime")
                    .HasColumnName("NgaySX")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TenHh)
                    .HasMaxLength(40)
                    .HasColumnName("TenHH");

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.HangHoas)
                    .HasForeignKey(d => d.MaLoai)
                    .HasConstraintName("FK_Products_Categories");

                entity.HasOne(d => d.MaNccNavigation)
                    .WithMany(p => p.HangHoas)
                    .HasForeignKey(d => d.MaNcc)
                    .HasConstraintName("FK_Products_Suppliers");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHd)
                    .HasName("PK_Orders");

                entity.ToTable("HoaDon");

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.CachThanhToan)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Cash')");

                entity.Property(e => e.CachVanChuyen)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Airline')");

                entity.Property(e => e.DiaChi).HasMaxLength(60);

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.Property(e => e.MaKh)
                    .HasMaxLength(20)
                    .HasColumnName("MaKH");

                entity.Property(e => e.MaVn)
                    .HasMaxLength(50)
                    .HasColumnName("MaVN");

                entity.Property(e => e.NgayCan)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NgayDat)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NgayGiao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1)/(1))/(1900))");
            });

            modelBuilder.Entity<HoiDap>(entity =>
            {
                entity.HasKey(e => e.MaHd);

                entity.ToTable("HoiDap");

                entity.Property(e => e.MaHd)
                    .ValueGeneratedNever()
                    .HasColumnName("MaHD");

                entity.Property(e => e.CauHoi).HasMaxLength(50);

                entity.Property(e => e.MaNv)
                    .HasMaxLength(50)
                    .HasColumnName("MaNV");

                entity.Property(e => e.NgayDua)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TraLoi).HasMaxLength(50);

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.HoiDaps)
                    .HasForeignKey(d => d.MaNv)
                    .HasConstraintName("FK_HoiDap_NhanVien");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKh)
                    .HasName("PK_Customers");

                entity.ToTable("KhachHang");

                entity.Property(e => e.MaKh)
                    .HasMaxLength(20)
                    .HasColumnName("MaKH");

                entity.Property(e => e.DiaChi).HasMaxLength(60);

                entity.Property(e => e.DienThoai).HasMaxLength(24);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Hinh)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Photo.gif')");

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.Property(e => e.MatKhau).HasMaxLength(50);

                entity.Property(e => e.NgaySinh)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Loai>(entity =>
            {
                entity.HasKey(e => e.MaLoai)
                    .HasName("PK_Categories");

                entity.ToTable("Loai");

                entity.Property(e => e.Hinh).HasMaxLength(50);

                entity.Property(e => e.TenLoai).HasMaxLength(50);
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("NguoiDung");

                entity.Property(e => e.DiaChi).HasMaxLength(60);

                entity.Property(e => e.DienThoai).HasMaxLength(24);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Hinh).HasMaxLength(50);

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.Property(e => e.MaNd)
                    .HasMaxLength(20)
                    .HasColumnName("MaND");

                entity.Property(e => e.MatKhau).HasMaxLength(50);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.HasKey(e => e.MaNcc)
                    .HasName("PK_Suppliers");

                entity.ToTable("NhaCungCap");

                entity.Property(e => e.MaNcc)
                    .HasMaxLength(50)
                    .HasColumnName("MaNCC");

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.DienThoai).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Logo).HasMaxLength(50);

                entity.Property(e => e.NguoiLienLac).HasMaxLength(50);

                entity.Property(e => e.TenCongTy).HasMaxLength(50);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv);

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(50)
                    .HasColumnName("MaNV");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.Property(e => e.MatKhau).HasMaxLength(50);
            });

            modelBuilder.Entity<VHangHoa>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vHangHoa");

                entity.Property(e => e.Expr2).HasMaxLength(50);

                entity.Property(e => e.Hinh).HasMaxLength(50);

                entity.Property(e => e.MaHh).HasColumnName("MaHH");

                entity.Property(e => e.MaNcc)
                    .HasMaxLength(50)
                    .HasColumnName("MaNCC");

                entity.Property(e => e.MoTaDonVi).HasMaxLength(50);

                entity.Property(e => e.NgaySx)
                    .HasColumnType("datetime")
                    .HasColumnName("NgaySX");

                entity.Property(e => e.TenCongTy).HasMaxLength(50);

                entity.Property(e => e.TenHh)
                    .HasMaxLength(40)
                    .HasColumnName("TenHH");

                entity.Property(e => e.TenLoai).HasMaxLength(50);
            });

            modelBuilder.Entity<VHoaDon>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vHoaDon");

                entity.Property(e => e.MaCt).HasColumnName("MaCT");

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.MaHh).HasColumnName("MaHH");

                entity.Property(e => e.MaKh)
                    .HasMaxLength(20)
                    .HasColumnName("MaKH");

                entity.Property(e => e.NgayDat).HasColumnType("datetime");

                entity.Property(e => e.TenHh)
                    .HasMaxLength(40)
                    .HasColumnName("TenHH");

                entity.Property(e => e.TenLoai).HasMaxLength(50);
            });

            modelBuilder.Entity<YeuThich>(entity =>
            {
                entity.HasKey(e => e.MaYt)
                    .HasName("PK_Favorites");

                entity.ToTable("YeuThich");

                entity.Property(e => e.MaYt).HasColumnName("MaYT");

                entity.Property(e => e.MaHh).HasColumnName("MaHH");

                entity.Property(e => e.MaKh)
                    .HasMaxLength(20)
                    .HasColumnName("MaKH");

                entity.Property(e => e.MoTa).HasMaxLength(255);

                entity.Property(e => e.NgayChon).HasColumnType("datetime");

                entity.HasOne(d => d.MaHhNavigation)
                    .WithMany(p => p.YeuThiches)
                    .HasForeignKey(d => d.MaHh)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_YeuThich_HangHoa");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.YeuThiches)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Favorites_Customers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
