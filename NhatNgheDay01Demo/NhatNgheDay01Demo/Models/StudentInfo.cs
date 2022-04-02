using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NhatNgheDay01Demo.Models
{
    public class StudentInfo
    {
        [Display(Name = "Mã sinh viên")]
        [Required(ErrorMessage = "*")]
        public string StudentId { get; set; }

        [Display(Name = "Họ tên sinh viên")]
        [Required(ErrorMessage = "*")]
        [MinLength(5, ErrorMessage = "Tên sinh viên phải tối thiểu 5 ký tự")]
        public string FullName { get; set; }

        [Display(Name = "Điểm trung bình")]
        [Range(0, 10, ErrorMessage = "Điểm trung bình phải từ 0 đến 10")]
        public double Grade { get; set; }

        [Display(Name = "Xếp loại")]
        public string Rating { get; set; }
    }
}
