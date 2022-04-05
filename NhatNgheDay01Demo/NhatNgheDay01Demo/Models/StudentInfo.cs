using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NhatNgheDay01Demo.Models
{
    public class StudentInfo
    {
        [Display(Name = "Mã sinh viên")]
        public string StudentId { get; set; }

        [Display(Name = "Họ tên sinh viên")]
        [MinLength(5, ErrorMessage = "Tên sinh viên phải tối thiểu 5 ký tự")]
        public string FullName { get; set; }

        [Display(Name = "Điểm trung bình")]
        [Range(0, 10, ErrorMessage = "Điểm trung bình phải từ 0 đến 10")]
        public double Grade { get; set; }

        [Display(Name = "Xếp loại")]
        public string? Rating {
            get
            {
                if (Grade < 5)
                {
                    return "Kém";
                }
                else if (Grade < 7)
                {
                    return "Trung bình";
                }
                else if (Grade < 8.5)
                {
                    return "Khá";
                }
                else
                {
                    return "Giỏi";
                }
            }
        }
    }
}
