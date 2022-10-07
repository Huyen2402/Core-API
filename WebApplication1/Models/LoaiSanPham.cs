using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class LoaiSanPham
    {
        public LoaiSanPham()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public int MaLoaiSp { get; set; }
        public string? TenLoai { get; set; }
        public bool? DaXoa { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
