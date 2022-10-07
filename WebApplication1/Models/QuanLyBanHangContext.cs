using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public partial class QuanLyBanHangContext : DbContext
    {
        public QuanLyBanHangContext()
        {
        }

        public QuanLyBanHangContext(DbContextOptions<QuanLyBanHangContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BinhLuan> BinhLuans { get; set; } = null!;
        public virtual DbSet<Chat> Chats { get; set; } = null!;
        public virtual DbSet<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; } = null!;
        public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; } = null!;
        public virtual DbSet<DonDatHang> DonDatHangs { get; set; } = null!;
        public virtual DbSet<Huyen> Huyens { get; set; } = null!;
        public virtual DbSet<KhachHang> KhachHangs { get; set; } = null!;
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; } = null!;
        public virtual DbSet<LoaiThanhVien> LoaiThanhViens { get; set; } = null!;
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; } = null!;
        public virtual DbSet<NhaSanXuat> NhaSanXuats { get; set; } = null!;
        public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; } = null!;
        public virtual DbSet<SanPham> SanPhams { get; set; } = null!;
        public virtual DbSet<ThanhVien> ThanhViens { get; set; } = null!;
        public virtual DbSet<Tinh> Tinhs { get; set; } = null!;
        public virtual DbSet<TinhTrangGiaoHang> TinhTrangGiaoHangs { get; set; } = null!;
        public virtual DbSet<TraLoiBinhLuan> TraLoiBinhLuans { get; set; } = null!;
        public virtual DbSet<Xa> Xas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=QuanLyBanHang;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SV>(entity => { entity.HasKey(e => e.MSSV); });

            modelBuilder.Entity<BinhLuan>(entity =>
            {
                entity.HasKey(e => e.MaBl);

                entity.ToTable("BinhLuan");

                entity.HasIndex(e => e.MaSp, "IX_FK_BinhLuan_SanPham");

                entity.HasIndex(e => e.MaThanhVien, "IX_FK_BinhLuan_TThanhVien");

                entity.Property(e => e.MaBl).HasColumnName("MaBL");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.NgayTao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NoiDungBl).HasColumnName("NoiDungBL");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.BinhLuans)
                    .HasForeignKey(d => d.MaSp)
                    .HasConstraintName("FK_BinhLuan_SanPham");

                entity.HasOne(d => d.MaThanhVienNavigation)
                    .WithMany(p => p.BinhLuans)
                    .HasForeignKey(d => d.MaThanhVien)
                    .HasConstraintName("FK_BinhLuan_TThanhVien");
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.ToTable("Chat");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Text).HasMaxLength(500);

                entity.HasOne(d => d.FromUser)
                    .WithMany(p => p.ChatFromUsers)
                    .HasForeignKey(d => d.FromUserId)
                    .HasConstraintName("FK_Chat_ThanhVien");

                entity.HasOne(d => d.ToUser)
                    .WithMany(p => p.ChatToUsers)
                    .HasForeignKey(d => d.ToUserId)
                    .HasConstraintName("FK_Chat_ThanhVien1");
            });

            modelBuilder.Entity<ChiTietDonDatHang>(entity =>
            {
                entity.HasKey(e => e.MaChiTietDdh1)
                    .HasName("PK__ChiTietD__49227631C03F7E8D");

                entity.ToTable("ChiTietDonDatHang");

                entity.HasIndex(e => e.MaSp, "IX_FK_ChiTietDonDatHang_SanPham");

                entity.Property(e => e.MaChiTietDdh1).HasColumnName("MaChiTietDDH1");

                entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MaDdh)
                    .HasMaxLength(200)
                    .HasColumnName("MaDDH");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.TenSp)
                    .HasMaxLength(255)
                    .HasColumnName("TenSP");

                entity.HasOne(d => d.MaDdhNavigation)
                    .WithMany(p => p.ChiTietDonDatHangs)
                    .HasForeignKey(d => d.MaDdh)
                    .HasConstraintName("ChiTietDonDatHangtoDonDatHang");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.ChiTietDonDatHangs)
                    .HasForeignKey(d => d.MaSp)
                    .HasConstraintName("FK_ChiTietDonDatHang_SanPham");
            });

            modelBuilder.Entity<ChiTietPhieuNhap>(entity =>
            {
                entity.HasKey(e => e.MaChiTietPn);

                entity.ToTable("ChiTietPhieuNhap");

                entity.HasIndex(e => e.MaPn, "IX_FK_ChiTietPhieuNhap_PhieuNhap");

                entity.HasIndex(e => e.MaSp, "IX_FK_ChiTietPhieuNhap_SanPham");

                entity.Property(e => e.MaChiTietPn).HasColumnName("MaChiTietPN");

                entity.Property(e => e.DonGiaNhap).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MaPn).HasColumnName("MaPN");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.HasOne(d => d.MaPnNavigation)
                    .WithMany(p => p.ChiTietPhieuNhaps)
                    .HasForeignKey(d => d.MaPn)
                    .HasConstraintName("FK_ChiTietPhieuNhap_PhieuNhap");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.ChiTietPhieuNhaps)
                    .HasForeignKey(d => d.MaSp)
                    .HasConstraintName("FK_ChiTietPhieuNhap_SanPham");
            });

            modelBuilder.Entity<DonDatHang>(entity =>
            {
                entity.HasKey(e => e.MaDdh)
                    .HasName("PK__DonDatHa__3D88C804CE79D4D1");

                entity.ToTable("DonDatHang");

                entity.HasIndex(e => e.MaKh, "IX_FK_DonDatHang_ToTable");

                entity.Property(e => e.MaDdh)
                    .HasMaxLength(200)
                    .HasColumnName("MaDDH");

                entity.Property(e => e.HinhThucThanhToan).HasMaxLength(50);

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.NgayDat).HasColumnType("datetime");

                entity.HasOne(d => d.MaHuyenNavigation)
                    .WithMany(p => p.DonDatHangs)
                    .HasForeignKey(d => d.MaHuyen)
                    .HasConstraintName("DonDatHang_Huyen");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.DonDatHangs)
                    .HasForeignKey(d => d.MaKh)
                    .HasConstraintName("DonDatHang_ThanhVien");

                entity.HasOne(d => d.MaTinhNavigation)
                    .WithMany(p => p.DonDatHangs)
                    .HasForeignKey(d => d.MaTinh)
                    .HasConstraintName("DonDatHang_Tinh");

                entity.HasOne(d => d.MaTinhTrangGiaoHangNavigation)
                    .WithMany(p => p.DonDatHangs)
                    .HasForeignKey(d => d.MaTinhTrangGiaoHang)
                    .HasConstraintName("DonDatHang_TTGiaoHang");

                entity.HasOne(d => d.MaXaNavigation)
                    .WithMany(p => p.DonDatHangs)
                    .HasForeignKey(d => d.MaXa)
                    .HasConstraintName("DonDatHang_Xa");
            });

            modelBuilder.Entity<Huyen>(entity =>
            {
                entity.HasKey(e => e.MaHuyen)
                    .HasName("PK__Huyen__0384275124A736AA");

                entity.ToTable("Huyen");

                entity.Property(e => e.TenHuyen).HasMaxLength(200);

                entity.HasOne(d => d.MaTinhNavigation)
                    .WithMany(p => p.Huyens)
                    .HasForeignKey(d => d.MaTinh)
                    .HasConstraintName("FK_TinhtoHuyen");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKh);

                entity.ToTable("KhachHang");

                entity.HasIndex(e => e.MaThanhVien, "IX_FK_KhachHang_ToTable");

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.DiaChi).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenKh)
                    .HasMaxLength(100)
                    .HasColumnName("TenKH");

                entity.HasOne(d => d.MaThanhVienNavigation)
                    .WithMany(p => p.KhachHangs)
                    .HasForeignKey(d => d.MaThanhVien)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_KhachHang_ToTable");
            });

            modelBuilder.Entity<LoaiSanPham>(entity =>
            {
                entity.HasKey(e => e.MaLoaiSp);

                entity.ToTable("loaiSanPham");

                entity.Property(e => e.MaLoaiSp).HasColumnName("MaLoaiSP");

                entity.Property(e => e.TenLoai).HasMaxLength(255);
            });

            modelBuilder.Entity<LoaiThanhVien>(entity =>
            {
                entity.HasKey(e => e.MaLoaiTv);

                entity.ToTable("LoaiThanhVien");

                entity.Property(e => e.MaLoaiTv).HasColumnName("MaLoaiTV");

                entity.Property(e => e.TenLoai).HasMaxLength(50);
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.HasKey(e => e.MaNcc);

                entity.ToTable("NhaCungCap");

                entity.Property(e => e.MaNcc).HasColumnName("MaNCC");

                entity.Property(e => e.DiaChi).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenNcc)
                    .HasMaxLength(100)
                    .HasColumnName("TenNCC");
            });

            modelBuilder.Entity<NhaSanXuat>(entity =>
            {
                entity.HasKey(e => e.MaNsx);

                entity.ToTable("NhaSanXuat");

                entity.Property(e => e.MaNsx).HasColumnName("MaNSX");

                entity.Property(e => e.TenNsx)
                    .HasMaxLength(100)
                    .HasColumnName("TenNSX");

                entity.Property(e => e.ThongTin).HasMaxLength(255);
            });

            modelBuilder.Entity<PhieuNhap>(entity =>
            {
                entity.HasKey(e => e.MaPn);

                entity.ToTable("PhieuNhap");

                entity.HasIndex(e => e.MaNcc, "IX_FK_PhieuNhap_ToTable");

                entity.Property(e => e.MaPn).HasColumnName("MaPN");

                entity.Property(e => e.MaNcc).HasColumnName("MaNCC");

                entity.Property(e => e.NgayNhap).HasColumnType("datetime");

                entity.HasOne(d => d.MaNccNavigation)
                    .WithMany(p => p.PhieuNhaps)
                    .HasForeignKey(d => d.MaNcc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PhieuNhap_ToTable");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp);

                entity.ToTable("SanPham");

                entity.HasIndex(e => e.MaLoaiSp, "IX_FK_SanPham_LoaiSanPham");

                entity.HasIndex(e => e.MaNcc, "IX_FK_SanPham_NhaCungCap");

                entity.HasIndex(e => e.MaNsx, "IX_FK_SanPham_NhaSanXuat");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MaLoaiSp).HasColumnName("MaLoaiSP");

                entity.Property(e => e.MaNcc).HasColumnName("MaNCC");

                entity.Property(e => e.MaNsx).HasColumnName("MaNSX");

                entity.Property(e => e.NgayCapNhat)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Seokeyword)
                    .HasMaxLength(500)
                    .HasColumnName("SEOKeyword");

                entity.Property(e => e.TenSp)
                    .HasMaxLength(255)
                    .HasColumnName("TenSP");

                entity.HasOne(d => d.MaLoaiSpNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaLoaiSp)
                    .HasConstraintName("FK_SanPham_LoaiSanPham");

                entity.HasOne(d => d.MaNccNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaNcc)
                    .HasConstraintName("FK_SanPham_NhaCungCap");

                entity.HasOne(d => d.MaNsxNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaNsx)
                    .HasConstraintName("FK_SanPham_NhaSanXuat");
            });

            modelBuilder.Entity<ThanhVien>(entity =>
            {
                entity.HasKey(e => e.MaThanhVien);

                entity.ToTable("ThanhVien");

                entity.HasIndex(e => e.MaLoaiTv, "IX_FK_ThanhVien_ToTable");

                entity.Property(e => e.DiaChi).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.HoTen).HasMaxLength(100);

                entity.Property(e => e.MaLoaiTv).HasColumnName("MaLoaiTV");

                entity.Property(e => e.MatKhau).HasMaxLength(100);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.TaiKhoan).HasMaxLength(100);

                entity.HasOne(d => d.MaHuyenNavigation)
                    .WithMany(p => p.ThanhViens)
                    .HasForeignKey(d => d.MaHuyen)
                    .HasConstraintName("FK_ThanhVientoHuyen");

                entity.HasOne(d => d.MaLoaiTvNavigation)
                    .WithMany(p => p.ThanhViens)
                    .HasForeignKey(d => d.MaLoaiTv)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ThanhVien_ToTable");

                entity.HasOne(d => d.MaTinhNavigation)
                    .WithMany(p => p.ThanhViens)
                    .HasForeignKey(d => d.MaTinh)
                    .HasConstraintName("FK_ThanhVientoTinh");

                entity.HasOne(d => d.MaXaNavigation)
                    .WithMany(p => p.ThanhViens)
                    .HasForeignKey(d => d.MaXa)
                    .HasConstraintName("FK_ThanhVientoXa");
            });

            modelBuilder.Entity<Tinh>(entity =>
            {
                entity.HasKey(e => e.MaTinh)
                    .HasName("PK__Tinh__4CC544804F4947A2");

                entity.ToTable("Tinh");

                entity.Property(e => e.TenTinh).HasMaxLength(200);
            });

            modelBuilder.Entity<TinhTrangGiaoHang>(entity =>
            {
                entity.HasKey(e => e.MaTinhTrangGiaoHang);

                entity.ToTable("TinhTrangGiaoHang");

                entity.Property(e => e.TenTinhTrang).HasMaxLength(200);
            });

            modelBuilder.Entity<TraLoiBinhLuan>(entity =>
            {
                entity.HasKey(e => e.MaTraLoiBl)
                    .HasName("PK__TraLoiBi__4472685EEBD41AEB");

                entity.ToTable("TraLoiBinhLuan");

                entity.Property(e => e.MaTraLoiBl).HasColumnName("MaTraLoiBL");

                entity.Property(e => e.MaBl).HasColumnName("MaBL");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.NgayTao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NoiDungTraLoi).HasMaxLength(255);

                entity.HasOne(d => d.MaBlNavigation)
                    .WithMany(p => p.TraLoiBinhLuans)
                    .HasForeignKey(d => d.MaBl)
                    .HasConstraintName("FK_TraLoiBinhLuan_BinhLuan");

                entity.HasOne(d => d.MaThanhVienNavigation)
                    .WithMany(p => p.TraLoiBinhLuans)
                    .HasForeignKey(d => d.MaThanhVien)
                    .HasConstraintName("FK_TraLoiBinhLuan_ThanhVien");
            });

            modelBuilder.Entity<Xa>(entity =>
            {
                entity.HasKey(e => e.MaXa)
                    .HasName("PK__Xa__272520C9F06494EC");

                entity.ToTable("Xa");

                entity.Property(e => e.TenXa).HasMaxLength(200);

                entity.HasOne(d => d.MaHuyenNavigation)
                    .WithMany(p => p.Xas)
                    .HasForeignKey(d => d.MaHuyen)
                    .HasConstraintName("FK_HuyentoXa");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<WebApplication1.Models.SV> SV { get; set; }
    }
}
