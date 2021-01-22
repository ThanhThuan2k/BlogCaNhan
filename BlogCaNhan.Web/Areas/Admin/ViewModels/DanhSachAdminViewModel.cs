using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogCaNhan.DTOs;
using PagedList.Core;

namespace BlogCaNhan.Web.Areas.Admin.ViewModels
{
    public class DanhSachAdminViewModel
    {
        public DanhSachAdminViewModel(IPagedList<BlogCaNhan.DTOs.Admin> admins,
            IPagedList<BlogCaNhan.DTOs.Admin> blocked, IPagedList<BlogCaNhan.DTOs.Admin> supper)
        {
            Admins = admins;
            Blocked = blocked;
            Supper = supper;
        }

        public IPagedList<BlogCaNhan.DTOs.Admin> Admins { get; set; }
        public IPagedList<BlogCaNhan.DTOs.Admin> Blocked { get; set; }
        public IPagedList<BlogCaNhan.DTOs.Admin> Supper { get; set; }
    }
}
