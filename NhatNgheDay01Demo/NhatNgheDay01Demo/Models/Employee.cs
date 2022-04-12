using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NhatNgheDay01Demo.Models
{
    public class Employee
    {
        [Display(Name = "Mã định danh")]
        public Guid Id { get; set; }

        [Display(Name = "Mã nhân viên")]
        [RegularExpression(@"NV\d{5}", ErrorMessage = "Đúng định dạng NVxxxxx")]
        [Remote(controller: "Buoi09Validation", action: "CheckValidEmployeeId")]
        public string? EmployeeId { get; set; }

        public string? FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Compare("Email", ErrorMessage = "Email không khớp")]
        public string? ConfirmEmail { get; set; }

        [DataType(DataType.Url)]
        public string? Website { get; set; }

        public bool Gender { get; set; }

        [Display(Name = "Ngày sinh")]
        [CheckBirthdate]
        public DateTime? Birthdate { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Lưa chưa hợp lệ")]
        public double Salary { get; set; }

        [DataType(DataType.PhoneNumber)]
        public double Phone { get; set; }

        [MaxLength(255)]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
    }
}
