using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class BinhLuan
    {
        public BinhLuan()
        {
            TraLoiBinhLuans = new HashSet<TraLoiBinhLuan>();
        }

        public int MaBl { get; set; }
        public string? NoiDungBl { get; set; }
        public int? MaThanhVien { get; set; }
        public int? MaSp { get; set; }
        public DateTime? NgayTao { get; set; }

        public virtual SanPham? MaSpNavigation { get; set; }
        public virtual ThanhVien? MaThanhVienNavigation { get; set; }
        public virtual ICollection<TraLoiBinhLuan> TraLoiBinhLuans { get; set; }
    }
}
