using System;
using System.Collections.Generic;

namespace Buoi17_First.Entities
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            ChuDes = new HashSet<ChuDe>();
            HoiDaps = new HashSet<HoiDap>();
        }

        public string MaNv { get; set; } = null!;
        public string HoTen { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? MatKhau { get; set; }

        public virtual ICollection<ChuDe> ChuDes { get; set; }
        public virtual ICollection<HoiDap> HoiDaps { get; set; }
    }
}
