using BlogCaNhan.Data.Repositories;
using BlogCaNhan.Web.Areas.Admin.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogCaNhan.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        AdminRepository AdminRepository;

        public LoginController()
        {
            AdminRepository = new AdminRepository();
        }

        [Route("login")]
        public IActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("DanhSach", "Admin",routeValues: new {area = "Admin"});
            }
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var account = AdminRepository.Login(model.Username, model.Password);
            if (account != null)
            {
                var claims = new List<Claim> 
                {
                    new Claim(ClaimTypes.Name, model.Username),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var claimsIdentity = new ClaimsIdentity(claims, "Cookies");

                await HttpContext.SignInAsync("Cookies",
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties()
                    {
                        IsPersistent = model.RememberMe,
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(240)
                    });
                return RedirectToAction("ShowList", "BaiViet", routeValues: new { area = "Admin" });
            }
            else
            {
                ModelState.AddModelError("", "Sai tên đăng nhập hoặc mật khẩu");
                ModelState.AddModelError("", "Hãy liên admin nếu bạn nghĩ đây là lỗi.");
                return View(model);
            }
        }
    }
}