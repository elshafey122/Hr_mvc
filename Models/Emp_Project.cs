using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace mvc2.Models
{
    public class Emp_Project
    {
        public int Emp_id { get; set; }
        public int Project_id { get; set; }
        public int Working_hours { get; set; }
        public Employee? employees { get; set; }
        public Project? projects { get; set; }
    }
}
