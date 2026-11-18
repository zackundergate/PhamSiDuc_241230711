using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhamSiDuc_241230711.Models;

public partial class Sach
{
    [Key]
    public int MaSach { get; set; }
    
    public int MaTl { get; set; }
    [Required(ErrorMessage ="Tên sách không được để trống")]
    public string TenSach { get; set; } = null!;
    [Required(ErrorMessage = "Vui lòng nhập giá")]
    [Range(50,1000,ErrorMessage ="Nhập giá từ 50 đến 1000")]
    public decimal? Gia { get; set; }
    [RegularExpression(@".*\.(jpg|jpeg|png|webp)$",ErrorMessage ="Nhập ảnh đúng định dạng")]
    public string? Anh { get; set; }
    [ForeignKey("MaTl")]
    public virtual TheLoai? MaTlNavigation { get; set; } 
}
