using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Xa
    {
        public Xa()
        {
            DonDatHangs = new HashSet<DonDatHang>();
            ThanhViens = new HashSet<ThanhVien>();
        }

        public int MaXa { get; set; }
        public string? TenXa { get; set; }
        public int? MaHuyen { get; set; }

        public virtual Huyen? MaHuyenNavigation { get; set; }
        public virtual ICollection<DonDatHang> DonDatHangs { get; set; }
        public virtual ICollection<ThanhVien> ThanhViens { get; set; }
    }
}
