using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class KhachHang
    {
        public int MaKh { get; set; }
        public string? TenKh { get; set; }
        public string? DiaChi { get; set; }
        public string? Email { get; set; }
        public string? Sdt { get; set; }
        public int? MaThanhVien { get; set; }

        public virtual ThanhVien? MaThanhVienNavigation { get; set; }
    }
}
