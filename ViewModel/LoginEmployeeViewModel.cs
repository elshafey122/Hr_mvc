using System.ComponentModel.DataAnnotations;

namespace mvclab2.ViewModel
{
    public class LoginEmployeeViewModel
    {
        [EmailAddress(ErrorMessage = "you must enter valid email")]
        [Required(ErrorMessage = "you must enter email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "you must enter password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must be between 6 and 20 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        public string Password { get; set; }

        public Boolean Rememberme { get; set; }
    }
}
