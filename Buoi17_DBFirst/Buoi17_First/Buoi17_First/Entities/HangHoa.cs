﻿using System;
using System.Collections.Generic;

namespace Buoi17_First.Entities
{
    public partial class HangHoa
    {
        public HangHoa()
        {
            BanBes = new HashSet<BanBe>();
            ChiTietHds = new HashSet<ChiTietHd>();
            YeuThiches = new HashSet<YeuThich>();
        }

        public int MaHh { get; set; }
        public string TenHh { get; set; } = null!;
        public int? MaLoai { get; set; }
        public string? MoTaDonVi { get; set; }
        public double? DonGia { get; set; }
        public string? Hinh { get; set; }
        public DateTime NgaySx { get; set; }
        public double GiamGia { get; set; }
        public int SoLanXem { get; set; }
        public string? MoTa { get; set; }
        public string? MaNcc { get; set; }

        public virtual Loai? MaLoaiNavigation { get; set; }
        public virtual NhaCungCap? MaNccNavigation { get; set; }
        public virtual ICollection<BanBe> BanBes { get; set; }
        public virtual ICollection<ChiTietHd> ChiTietHds { get; set; }
        public virtual ICollection<YeuThich> YeuThiches { get; set; }
    }
}