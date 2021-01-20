using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlogCaNhan.DTOs
{
    [Table("BaiViet")]
    public class BaiViet
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }

        [DisplayName("Nội dung")] // using using System.ComponentModel.DataAnnotations.Schema;

        public string NoiDung { get; set; }

        [MaxLength(500)]
        [DisplayName("Đường dẫn ảnh")]
        public string DuongDanAnh { get; set; }

        [NotMapped]
        [DisplayName("Ảnh bài viết")]
        public IFormFile AnhBaiViet { get; set; }

        [MaxLength(500)]
        [DisplayName("Tác giả")]
        public string TacGia { get; set; }

        [DisplayName("Ngày đăng")]
        public DateTime? NgayDang { get; set; }

        [Column(Order = 1)]
        [DisplayName("Lượt xem")]
        public int LuotXem { get; set; }

        [MaxLength(500)]
        [DisplayName("Alias")]
        public string Alias { get; set; }

        [DisplayName("Thuộc thể loại")]
        public int? IdTheLoai { get; set; }

        [ForeignKey("IdTheLoai")]
        public TheLoai theLoai { get; set; }
    }
}
