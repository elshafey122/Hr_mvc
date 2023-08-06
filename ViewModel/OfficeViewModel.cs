using mvc2.Models;
using System.ComponentModel.DataAnnotations;

namespace mvclab2.ViewModel
{
    public class OfficeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="you must enter name")]
        [MaxLength(50,ErrorMessage ="enter less than 50 letters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "you must enter location")]
        [MaxLength(50, ErrorMessage = "enter less than 50 letters")]
        public string Location { get; set; }
        public List<Employee>? employees { get; set; }
    }
}
