using mvc2.Models;
using System.ComponentModel.DataAnnotations;

namespace mvclab2.ViewModel
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "you must enter name")]
        [MaxLength(50, ErrorMessage = "enter less than 50 letters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "you must enter Description")]
        [MaxLength(50, ErrorMessage = "enter less than 50 letters")]
        public string Description { get; set; }
        public List<Emp_Project>? emp_projects { get; set; }
    }
}
