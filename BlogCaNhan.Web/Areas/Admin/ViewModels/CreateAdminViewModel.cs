using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCaNhan.Web.Areas.Admin.ViewModels
{
    public class CreateAdminViewModel : BlogCaNhan.DTOs.Admin
    {
        [DisplayName("Nhập lại mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp")]
        public string NhapLaiMatKhau { get; set; }
    }
}
