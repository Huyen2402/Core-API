using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class NhaSanXuat
    {
        public NhaSanXuat()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public int MaNsx { get; set; }
        public string? TenNsx { get; set; }
        public string? ThongTin { get; set; }
        public string? Logo { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
