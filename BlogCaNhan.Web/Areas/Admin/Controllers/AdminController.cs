using BlogCaNhan.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCaNhan.Web.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        AdminRepository adminRepository;

        public AdminController()
        {
            adminRepository = new AdminRepository();
        }

        public IActionResult DanhSachAdmin(int? page)
        {
            int recordPerPage = 10; // cho phép hiển thị 10 dòng trên 1 trang
            ViewBag.Page = page ?? 1;
            var adminData = adminRepository.DanhSachAdmin(page ?? 1, recordPerPage);
            if (adminData.Count() == 0 && page != 1)
            {
                return RedirectToAction("DanhSachAdmin", routeValues: new { page = 1 });
            }
            else
            {
                return View(adminData);
            }
        }
    }
}
