using System;
using System.Collections.Generic;

namespace Buoi17_First.Entities
{
    public partial class VHoaDon
    {
        public int MaCt { get; set; }
        public int MaHd { get; set; }
        public int MaHh { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public double GiamGia { get; set; }
        public string MaKh { get; set; } = null!;
        public DateTime NgayDat { get; set; }
        public string TenHh { get; set; } = null!;
        public string TenLoai { get; set; } = null!;
    }
}
