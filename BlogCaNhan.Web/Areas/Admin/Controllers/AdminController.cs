using BlogCaNhan.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogCaNhan.Web.Areas.Admin.ViewModels;
using BlogCaNhan.DTOs;
using BlogCaNhan.Web.Common;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace BlogCaNhan.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        AdminRepository adminRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public AdminController(IHostingEnvironment environment = null)
        {
            hostingEnvironment = environment;
            adminRepository = new AdminRepository();
        }

        public IActionResult DanhSachAdmin(int? page)
        {
            int recordPerPage = 10; // cho phép hiển thị 10 dòng trên 1 trang
            ViewBag.Page = page ?? 1;
            var admin = adminRepository.DanhSachAdmin(page ?? 1, recordPerPage);
            var blocked = adminRepository.AdminBlocked(page ?? 1, recordPerPage);
            var supper = adminRepository.SupperAdmin(page ?? 1, recordPerPage);

            DanhSachAdminViewModel model = new DanhSachAdminViewModel(admin, blocked, supper);

            if (admin.Count() == 0 && page != 1)
            {
                return RedirectToAction("DanhSachAdmin", routeValues: new { page = 1 });
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult ThemMoi(CreateAdminViewModel newAdmin)
        {
            if (ModelState.IsValid)
            {
                if (newAdmin.Avatar != null)
                {
                    var uniqueFileName = PasswordHelper.GetUniqueFileName(newAdmin.Avatar.FileName);
                    var uploads = Path.Combine(hostingEnvironment.WebRootPath, "upload");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    newAdmin.Avatar.CopyTo(new FileStream(filePath, FileMode.Create));
                    newAdmin.PathAvatar = uniqueFileName;
                }

                newAdmin.Salt = PasswordHelper.CreateSalt(4, 8);
                newAdmin.Password = PasswordHelper.EncryptSHA512(newAdmin.Password, newAdmin.Username);
                adminRepository.ThemMoi(newAdmin);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Fail");
            }
        }

        public IActionResult Block(int id = 0)
        {
            var block = adminRepository.Block(id);
            if (block)
            {
                return Ok(new AjaxResponse(true, "Khóa tài khoản thành công", 200));
            }
            else
            {
                return Ok(new AjaxResponse(false, "Đã xảy ra lỗi trong quá trình thực hiện", 404));
            }
        }

        public IActionResult Unlock(int id = 0)
        {
            var unlock = adminRepository.Unlock(id);
            if(unlock)
            {
                return Ok(new AjaxResponse(true, "Mở khóa thành công", 200));
            }
            else
            {
                return Ok(new AjaxResponse(false, "Vui lòng thử lại sau ít phút nữa", 404));
            }
        }

        public IActionResult Update(BlogCaNhan.DTOs.Admin infomation)
        {
            if(ModelState.IsValid)
            {
                if (infomation.Avatar != null)
                {
                    var uniqueFileName = PasswordHelper.GetUniqueFileName(infomation.Avatar.FileName);
                    var uploads = Path.Combine(hostingEnvironment.WebRootPath, "upload");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    infomation.Avatar.CopyTo(new FileStream(filePath, FileMode.Create));
                    infomation.PathAvatar = uniqueFileName;
                }
                var result = adminRepository.Update(infomation);
                if(result)
                {
                    return Ok(new AjaxResponse(true, "Cập nhật thành công", 200));
                }
                else
                {
                    return Ok(new AjaxResponse(false, "Cập nhật thất bại", 505));
                }
            }
            else
            {
                return Ok(new AjaxResponse(false, "Vui lòng kiểm tra thông tin", 404));
            }    
        }
    }
}
