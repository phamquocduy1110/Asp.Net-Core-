using Buoi17_First.Entities;
using Buoi17_First.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi17_First.Controllers
{
    public class CartController : Controller
    {
        private readonly eStore20Context _context;

        public CartController(eStore20Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(Carts);
        }

        const string MY_CART_KEY = "GioHang";

        public List<CartItem> Carts
        {
            get 
            { 
                var gioHang = HttpContext.Session.Get<List<CartItem>>(MY_CART_KEY);
                if(gioHang == null)
                {
                    gioHang = new List<CartItem>();
                }
                return gioHang;
            }
        }

        public IActionResult AddToCart(int id, int qty = 1)
        {
            var gioHang = Carts;
            // Kiểm tra xem mã hàng đã có trong giỏ hay chưa
            var item = gioHang.SingleOrDefault(hh => hh.MaHh == id);

            if(item != null) // Có rồi nè
            {
                item.SoLuong += qty;
            }
            else
            {
                var hangHoa = _context.HangHoas.SingleOrDefault(p => p.MaHh == id);

                if (hangHoa == null)
                {
                    return NotFound();
                }
                item = new CartItem
                {
                    MaHh = id,
                    SoLuong = qty,
                    TenHh = hangHoa.TenHh,
                    DonGia = hangHoa.DonGia.Value,
                    Hinh = hangHoa.Hinh,
                };
                gioHang.Add(item);
            }
            HttpContext.Session.Set(MY_CART_KEY,gioHang);

            return RedirectToAction("Index");
        }
    }
}
