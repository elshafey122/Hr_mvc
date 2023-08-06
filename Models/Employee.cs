using System.ComponentModel.DataAnnotations.Schema;

namespace mvc2.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [ForeignKey("office")]
        public int? OfficeId { get; set; }
        public Office? office { get; set; }
        public List<Emp_Project>? emp_projects { get; set; }
    }
}
