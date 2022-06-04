using AutoMapper;
using Buoi17_First.Data;
using Buoi17_First.Utils;
using Buoi17_First.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Buoi17_First.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public CustomerController(ShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var customer = _mapper.Map<Customer>(model);
                    customer.IsActive = true;//false ==> link/mail ==> change active true
                    customer.RandomKey = MyTool.GetRandom();
                    customer.Password = model.Password!.ToSHA512Hash(customer.RandomKey);

                    _context.Add(customer);
                    _context.SaveChanges();
                    return RedirectToAction("Login");
                } catch
                {
                    return View();
                }
            }

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var customer = _context.Customers.SingleOrDefault(c => c.UserName == model.UserName);

                if(customer == null)
                {
                    ModelState.AddModelError("loi", "User này không có");
                    return View();
                }
                if(!customer.IsActive)
                {
                    ModelState.AddModelError("loi", "User này chưa kích hoạt sử dụng");
                    return View();
                }
                if(customer.Password != model.Password!.ToSHA512Hash(customer.RandomKey))
                {
                    ModelState.AddModelError("loi", "Sai thông tin đăng nhập");
                    return View();
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, customer.FullName!),
                    new Claim("Username", customer.UserName!),
                    new Claim("UserId", customer.CustomerId.ToString()),
                };

                var claimIdentity = new ClaimsIdentity(claims, "login");
                var principal = new ClaimsPrincipal(claimIdentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public async Task<IActionResult> Logut(Guid id)
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
