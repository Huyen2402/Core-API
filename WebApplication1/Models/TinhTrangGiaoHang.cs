using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class TinhTrangGiaoHang
    {
        public TinhTrangGiaoHang()
        {
            DonDatHangs = new HashSet<DonDatHang>();
        }

        public int MaTinhTrangGiaoHang { get; set; }
        public string? TenTinhTrang { get; set; }

        public virtual ICollection<DonDatHang> DonDatHangs { get; set; }
    }
}
