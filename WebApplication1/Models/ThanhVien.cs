using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class ThanhVien
    {
        public ThanhVien()
        {
            BinhLuans = new HashSet<BinhLuan>();
            ChatFromUsers = new HashSet<Chat>();
            ChatToUsers = new HashSet<Chat>();
            DonDatHangs = new HashSet<DonDatHang>();
            KhachHangs = new HashSet<KhachHang>();
            TraLoiBinhLuans = new HashSet<TraLoiBinhLuan>();
        }

        public int MaThanhVien { get; set; }
        public string? TaiKhoan { get; set; }
        public string? MatKhau { get; set; }
        public string? HoTen { get; set; }
        public string? DiaChi { get; set; }
        public string? Email { get; set; }
        public string? Sdt { get; set; }
        public int? MaLoaiTv { get; set; }
        public bool? DaKhoa { get; set; }
        public int? MaTinh { get; set; }
        public int? MaHuyen { get; set; }
        public int? MaXa { get; set; }

        public virtual Huyen? MaHuyenNavigation { get; set; }
        public virtual LoaiThanhVien? MaLoaiTvNavigation { get; set; }
        public virtual Tinh? MaTinhNavigation { get; set; }
        public virtual Xa? MaXaNavigation { get; set; }
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }
        public virtual ICollection<Chat> ChatFromUsers { get; set; }
        public virtual ICollection<Chat> ChatToUsers { get; set; }
        public virtual ICollection<DonDatHang> DonDatHangs { get; set; }
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
        public virtual ICollection<TraLoiBinhLuan> TraLoiBinhLuans { get; set; }
    }
}
