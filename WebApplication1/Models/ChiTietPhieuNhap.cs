using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class ChiTietPhieuNhap
    {
        public int MaChiTietPn { get; set; }
        public int? MaPn { get; set; }
        public int? MaSp { get; set; }
        public decimal? DonGiaNhap { get; set; }
        public int? SoLuongNhap { get; set; }

        public virtual PhieuNhap? MaPnNavigation { get; set; }
        public virtual SanPham? MaSpNavigation { get; set; }
    }
}
