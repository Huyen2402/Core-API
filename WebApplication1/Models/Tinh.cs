using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Tinh
    {
        public Tinh()
        {
            DonDatHangs = new HashSet<DonDatHang>();
            Huyens = new HashSet<Huyen>();
            ThanhViens = new HashSet<ThanhVien>();
        }

        public int MaTinh { get; set; }
        public string? TenTinh { get; set; }

        public virtual ICollection<DonDatHang> DonDatHangs { get; set; }
        public virtual ICollection<Huyen> Huyens { get; set; }
        public virtual ICollection<ThanhVien> ThanhViens { get; set; }
    }
}
