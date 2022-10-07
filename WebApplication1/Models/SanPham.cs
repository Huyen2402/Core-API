using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            BinhLuans = new HashSet<BinhLuan>();
            ChiTietDonDatHangs = new HashSet<ChiTietDonDatHang>();
            ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
        }

        public int MaSp { get; set; }
        public string? TenSp { get; set; }
        public decimal? DonGia { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public string? MoTa { get; set; }
        public string? HinhAnh { get; set; }
        public int? SoLuongTon { get; set; }
        public int? LuotBinhLuan { get; set; }
        public int? SoLanMua { get; set; }
        public int? Moi { get; set; }
        public int? MaNcc { get; set; }
        public int? MaNsx { get; set; }
        public int? MaLoaiSp { get; set; }
        public bool? DaXoa { get; set; }
        public string? HinhAnh1 { get; set; }
        public string? HinhAnh2 { get; set; }
        public string? HinhAnh3 { get; set; }
        public string? Seokeyword { get; set; }

        public virtual LoaiSanPham? MaLoaiSpNavigation { get; set; }
        public virtual NhaCungCap? MaNccNavigation { get; set; }
        public virtual NhaSanXuat? MaNsxNavigation { get; set; }
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }
        public virtual ICollection<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
    }
}
