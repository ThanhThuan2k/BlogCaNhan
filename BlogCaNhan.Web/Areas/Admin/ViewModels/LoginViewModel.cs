using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCaNhan.Web.Areas.Admin.ViewModel
{
    public class LoginViewModel
    {
        [DisplayName("Username")]
        [Required]
        public string Username { get; set; }

        [DisplayName("Password")]
        [MinLength(4, ErrorMessage = "Trường này không được để trống")]
        public string Password { get; set; }

        [DisplayName("Remember me")]
        public bool RememberMe { get; set; }
    }
}
