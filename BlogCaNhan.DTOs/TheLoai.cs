using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlogCaNhan.DTOs
{
    [Index("Url", IsUnique = true)]
    [Table("TheLoai")]
    public class TheLoai
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(500, ErrorMessage = "Vượt quá độ dài cố định")]
        public string TenTheLoai { get; set; }

        [MaxLength(500, ErrorMessage = "Vượt quá độ dài cố định")]
        public string Url { get; set; }
    }
}