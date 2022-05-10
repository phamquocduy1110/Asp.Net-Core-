using Buoi17_First.Entities;
using Buoi17_First.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Buoi17_First.Controllers
{
    public class DemoController : Controller
    {
        private readonly eStore20Context _context;

        public IActionResult ThongKe()
        {
            var data = _context.ChiTietHds.GroupBy(cthd => cthd.MaHhNavigation.MaLoaiNavigation.TenLoai).Select(cthdg => new ThongKeViewModel
            {
                Loai = cthdg.Key,
                DoanhThu = cthdg.Sum(s => s.SoLuong * s.DonGia * (1 - s.GiamGia)),
                SoHH = cthdg.Count(),
                GiaTB = cthdg.Average(s => s.DonGia),
            });

            return View(data.ToList());
        }

        public IActionResult ThongKeKhachHang()
        {
            var data = _context.ChiTietHds
            .GroupBy(cthd => new
            {
                cthd.MaHdNavigation.MaKh,
                cthd.MaHdNavigation.MaKhNavigation.HoTen,
                cthd.MaHdNavigation.MaKhNavigation.DienThoai,
            })
            .Select(cthdg => new
            {
                MaKh = cthdg.Key.MaKh,
                HoTenKhachHang = cthdg.Key.HoTen,
                SoDt = cthdg.Key.DienThoai,
                DoanhThu = cthdg.Sum(s => s.SoLuong * s.DonGia * (1 - s.GiamGia)),
            });

            return Json(data);
        }

        public IActionResult ThongKeTheoNam()
        {
            var data = _context.ChiTietHds
            .GroupBy(cthd => new
            {
                cthd.MaHhNavigation.MaLoaiNavigation.TenLoai,
                cthd.MaHdNavigation.NgayDat.Year
            })
            .Select(cthdg => new
            {
                Loai = cthdg.Key.TenLoai,
                Nam = cthdg.Key.Year,
                DoanhThu = cthdg.Sum(s => s.SoLuong * s.DonGia * (1 - s.GiamGia)),
            });

            return Json(data);
        }


        public DemoController(eStore20Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Hàm phân trang + tìm kiếm
        /// </summary>
        /// <param name="search">Từ khóa cần tìm</param>
        /// <param name="p">Trang thứ mấy</param>
        /// <returns></returns>
        public IActionResult Index(string search, int p = 1, string sortBy = "DonGia", bool ascSort = true)
        {
            var dsHangHoa = _context.HangHoas.AsQueryable();

            // Filter
            if (!string.IsNullOrEmpty(search))
            {
                dsHangHoa = dsHangHoa.Where(p => p.TenHh.Contains(search));
            }

            // Sort
            switch (sortBy)
            {
                case "DonGia":
                    dsHangHoa = ascSort ? dsHangHoa.OrderBy(p => p.DonGia) : dsHangHoa.OrderByDescending(p => p.DonGia);
                    break;
                case "TenHh":
                    dsHangHoa = ascSort ? dsHangHoa.OrderBy(p => p.TenHh) : dsHangHoa.OrderByDescending(p => p.TenHh);
                    break;
            }
            ViewBag.SortBy = sortBy;
            ViewBag.AscSort = ascSort;

            // Paging
            const int SoPhanTuMoiTrang = 9;

            ViewBag.TrangHienTai = p;
            ViewBag.TongSoTrang = Math.Ceiling(1.0 * dsHangHoa.Count() / SoPhanTuMoiTrang);
            dsHangHoa = dsHangHoa.Skip((p - 1) * SoPhanTuMoiTrang).Take(SoPhanTuMoiTrang);

            var data = dsHangHoa.Select(hh => new KetQuaTimKiemViewModel
            {
                MaHh = hh.MaHh,
                TenHh = hh.TenHh,
                DonGia = hh.DonGia.Value,
                NgaySX = hh.NgaySx,
                Loai = hh.MaLoaiNavigation.TenLoai,
            }).ToList();

            return View(data);
        }
    }
}
