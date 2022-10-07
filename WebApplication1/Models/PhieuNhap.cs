using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class PhieuNhap
    {
        public PhieuNhap()
        {
            ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
        }

        public int MaPn { get; set; }
        public int? MaNcc { get; set; }
        public DateTime? NgayNhap { get; set; }
        public bool? DaXoa { get; set; }

        public virtual NhaCungCap? MaNccNavigation { get; set; }
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
    }
}
