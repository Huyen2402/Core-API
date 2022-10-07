using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class DonDatHang
    {
        public DonDatHang()
        {
            ChiTietDonDatHangs = new HashSet<ChiTietDonDatHang>();
        }

        public DateTime? NgayDat { get; set; }
        public bool? DaThanhToan { get; set; }
        public int? MaKh { get; set; }
        public int? UuDai { get; set; }
        public int? MaTinhTrangGiaoHang { get; set; }
        public string? HinhThucThanhToan { get; set; }
        public int? MaHuyen { get; set; }
        public int? MaTinh { get; set; }
        public int? MaXa { get; set; }
        public string MaDdh { get; set; } = null!;

        public virtual Huyen? MaHuyenNavigation { get; set; }
        public virtual ThanhVien? MaKhNavigation { get; set; }
        public virtual Tinh? MaTinhNavigation { get; set; }
        public virtual TinhTrangGiaoHang? MaTinhTrangGiaoHangNavigation { get; set; }
        public virtual Xa? MaXaNavigation { get; set; }
        public virtual ICollection<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }
    }
}
