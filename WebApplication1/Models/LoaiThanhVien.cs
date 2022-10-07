using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class LoaiThanhVien
    {
        public LoaiThanhVien()
        {
            ThanhViens = new HashSet<ThanhVien>();
        }

        public int MaLoaiTv { get; set; }
        public string? TenLoai { get; set; }
        public int? UuDai { get; set; }

        public virtual ICollection<ThanhVien> ThanhViens { get; set; }
    }
}
