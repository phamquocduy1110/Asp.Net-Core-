using System.ComponentModel.DataAnnotations;

namespace NhatNgheDay01Demo.Models
{
    public class Employee
    {
        [Display(Name = "Mã định danh")]
        public Guid Id { get; set; }

        [Display(Name = "Mã nhân viên")]
        [RegularExpression(@"NV\d{5}", ErrorMessage = "Đúng định dạng NVxxxxx")]
        public string? EmployeeId { get; set; }

        public string? FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [DataType(DataType.Url)]
        public string? Website { get; set; }
    }
}
