using System.ComponentModel.DataAnnotations;

namespace Buoi17_First.Models
{
    public class LoaiViewModel
    {
        [Display(Name="Mã loại")]
        public int MaLoai { get; set; }

        [Display(Name="Tên loại")]
        [MaxLength(50)]
        public string? TenLoai { get; set; }

        [Display(Name="Mô tả")]
        [DataType(DataType.MultilineText)]
        public string? MoTa { get; set; }
        
        [Display(Name="Hình ảnh")]
        public string? Hinh { get; set; }
    }
}
