using mvc2.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace mvclab2.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "you must input name maxlength=50")]
        [StringLength(100)]
        public string Name { get; set; }


        [Required(ErrorMessage = "you must input age between")]
        [Range(23, 60, ErrorMessage = "you must input age between 23 60")]
        public int Age { get; set; }

        [Display(Name ="Net Salary")]
        [Required(ErrorMessage = "you must enter valid salary")]
        public double Salary { get; set; }


        [EmailAddress(ErrorMessage = "you must enter valid email")]
        [Required(ErrorMessage = "you must enter email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "you must enter password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must be between 6 and 20 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        public string Password { get; set; }


        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "you must enter confirmed password")]
        [Compare("Password",ErrorMessage ="you should input same password")]
        public string ConfirmPassword { get; set; }



        [DisplayName("OfficeNumber")]
        public int? OfficeId { get; set; }


        public Office? office { get; set; }
    }
}
