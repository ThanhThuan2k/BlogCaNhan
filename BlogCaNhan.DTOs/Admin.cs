using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlogCaNhan.DTOs
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [NotMapped]
        [DisplayName("Ảnh đại diện")]
        public IFormFile Avatar { get; set; }

        [DisplayName("Đường dẫn ảnh đại diện")]
        public string PathAvatar { get; set; }

        [DisplayName("Tên đăng nhập")]
        [MaxLength(500, ErrorMessage = "Vượt quá độ dài tối thiểu")]
        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        public string Username { get; set; }

        [DisplayName("Mật khẩu")]
        [MinLength(4, ErrorMessage = "Mật khẩu quá yếu")]
        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Email")]
        [MaxLength(500, ErrorMessage = "Vượt quá độ dài cố định")]
        public string Email { get; set; }

        [MaxLength(13, ErrorMessage = "Số điện thoại không hợp lệ")]
        [DisplayName("Số điện thoại")]
        public string SDT { get; set; }

        [DisplayName("Bị khóa")]
        public bool isBlock { get; set; }

        [DisplayName("Supper admin")]
        public bool isSupper { get; set; }

        [DisplayName("Ngày tạo tài khoản")]
        public DateTime NgayTao { get; set; }

        [DisplayName("Họ và tên")]
        public string HoTen { get; set; }

        [DisplayName("Giới tính")]
        public bool? isMale { get; set; }

        [DisplayName("Quê quán")]
        [MaxLength(1000, ErrorMessage = "Vượt quá độ dài cố định")]
        public string QueQuan { get; set; }

        [DisplayName("Ngày sinh")]
        public DateTime NgaySinh { get; set; }

        [DisplayName("Chuỗi ngẫu nhiên")]
        [MaxLength(1000, ErrorMessage = "Vượt quá giới hạn cố định")]
        public string Salt { get; set; }

        public DateTime? lastLogin { get; set; }
    }
}
