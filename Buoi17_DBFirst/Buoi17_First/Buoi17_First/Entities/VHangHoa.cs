using System;
using System.Collections.Generic;

namespace Buoi17_First.Entities
{
    public partial class VHangHoa
    {
        public int MaHh { get; set; }
        public string TenHh { get; set; } = null!;
        public int MaLoai { get; set; }
        public string? MoTaDonVi { get; set; }
        public double? DonGia { get; set; }
        public string? Hinh { get; set; }
        public DateTime NgaySx { get; set; }
        public double GiamGia { get; set; }
        public int SoLanXem { get; set; }
        public string? MoTa { get; set; }
        public string MaNcc { get; set; } = null!;
        public string TenLoai { get; set; } = null!;
        public int Expr1 { get; set; }
        public string Expr2 { get; set; } = null!;
        public string TenCongTy { get; set; } = null!;
    }
}
