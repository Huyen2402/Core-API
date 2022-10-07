using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Huyen
    {
        public Huyen()
        {
            DonDatHangs = new HashSet<DonDatHang>();
            ThanhViens = new HashSet<ThanhVien>();
            Xas = new HashSet<Xa>();
        }

        public int MaHuyen { get; set; }
        public string? TenHuyen { get; set; }
        public int? MaTinh { get; set; }

        public virtual Tinh? MaTinhNavigation { get; set; }
        public virtual ICollection<DonDatHang> DonDatHangs { get; set; }
        public virtual ICollection<ThanhVien> ThanhViens { get; set; }
        public virtual ICollection<Xa> Xas { get; set; }
    }
}
