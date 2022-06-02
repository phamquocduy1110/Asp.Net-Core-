using System.ComponentModel.DataAnnotations;

namespace Buoi17_First.ViewModels
{
    public class RegisterViewModel
    {
        public string? FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        public string? Phone { get; set; }

        [MaxLength(30)]
        public string? UserName { get; set; }

        public string? Password { get; set; }

       
    }
}
