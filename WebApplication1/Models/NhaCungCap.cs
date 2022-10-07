using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class NhaCungCap
    {
        public NhaCungCap()
        {
            PhieuNhaps = new HashSet<PhieuNhap>();
            SanPhams = new HashSet<SanPham>();
        }

        public int MaNcc { get; set; }
        public string? TenNcc { get; set; }
        public string? DiaChi { get; set; }
        public string? Email { get; set; }
        public string? Sdt { get; set; }
        public string? Fax { get; set; }

        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
