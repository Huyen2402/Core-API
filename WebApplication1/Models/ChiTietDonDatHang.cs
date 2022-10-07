using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class ChiTietDonDatHang
    {
        public string? MaDdh { get; set; }
        public int? MaSp { get; set; }
        public string? TenSp { get; set; }
        public int? SoLuong { get; set; }
        public decimal? DonGia { get; set; }
        public int MaChiTietDdh1 { get; set; }

        public virtual DonDatHang? MaDdhNavigation { get; set; }
        public virtual SanPham? MaSpNavigation { get; set; }
    }
}
