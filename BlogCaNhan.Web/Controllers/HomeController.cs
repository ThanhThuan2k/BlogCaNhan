using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogCaNhan.Data;
using BlogCaNhan.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BlogCaNhan.Web.Controllers
{
    public class HomeController : Controller
    {
        BlogCaNhanDbContext db = new BlogCaNhanDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ThemTheLoai()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ThemTheLoai(TheLoai theloai)
        {
            //db.TheLoai.Add(theloai);
            //db.SaveChanges();
            return View();
        }
    }
}