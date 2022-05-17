using Buoi17_First.Entities;
using Buoi17_First.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi17_First.Controllers
{
    public class AjaxController : Controller
    {
        private readonly eStore20Context _context;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ServerTime()
        {
            return Content(DateTime.Now.ToString("dd/MM/yyy hh:mm:ss"));
        }

        #region Simple Search
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string keyword)
        {
            var dsHangHoa = _context.HangHoas.Where(p => p.TenHh.Contains(keyword));

            var data = dsHangHoa.Select(hh => new KetQuaTimKiemViewModel
            {
                MaHh = hh.MaHh,
                TenHh = hh.TenHh,
                DonGia = hh.DonGia.Value,
                NgaySX = hh.NgaySx,
                Loai = hh.MaLoaiNavigation.TenLoai
            }).ToList();
            return PartialView("TimKiemPartial", data);
        }

        #endregion

        public AjaxController(eStore20Context context)
        {
            _context = context;
        }

        #region Tìm kiếm - trả về JSON
        public IActionResult TimKiem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HandleSearch(string keyword, double? from, double? to)
        {
            var data = _context.HangHoas.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.Where(p => p.TenHh.Contains(keyword));
            }
            if (from.HasValue)
            {
                data = data.Where(p => p.DonGia.Value >= from);
            }
            if (to.HasValue)
            {
                data = data.Where(p => p.DonGia.Value <= to);
            }
            var result = data.Select(p => new
            {
                HangHoa = p.TenHh,
                GiaBan = p.DonGia.Value,
                Loai = p.MaLoaiNavigation.TenLoai
            }).ToList();
            return Json(result);
        }
        #endregion

    }
}
