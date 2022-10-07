using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class TraLoiBinhLuan
    {
        public int MaTraLoiBl { get; set; }
        public string? NoiDungTraLoi { get; set; }
        public int? MaBl { get; set; }
        public int? MaThanhVien { get; set; }
        public DateTime? NgayTao { get; set; }
        public int? MaSp { get; set; }

        public virtual BinhLuan? MaBlNavigation { get; set; }
        public virtual ThanhVien? MaThanhVienNavigation { get; set; }
    }
}
