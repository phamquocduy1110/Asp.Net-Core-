using System.ComponentModel.DataAnnotations;

namespace Buoi17_First.ViewModels
{
    public class LoginViewModel
    {
        [MaxLength(30)]
        [Display(Name = "User name")]
        public string? UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }
    }
}
