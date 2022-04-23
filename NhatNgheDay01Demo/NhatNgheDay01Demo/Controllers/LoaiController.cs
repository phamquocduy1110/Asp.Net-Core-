using Microsoft.AspNetCore.Mvc;
using NhatNgheDay01Demo.Models;

namespace NhatNgheDay01Demo.Controllers
{
    public class LoaiController : Controller
    {
        public IActionResult Index()
        {
            return View(LoaiDataAccessLayer.GetAll());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var loai = LoaiDataAccessLayer.GetById(id);
            if(loai != null)
            {
                return View(loai);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Loai loai)
        {
            var newLoai = LoaiDataAccessLayer.Add(loai);
            if(newLoai == null)
            {
                return View();
            }
            return RedirectToAction("Edit", new { id = newLoai.MaLoai });
        }
    }
}
