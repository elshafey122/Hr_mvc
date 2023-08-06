namespace mvc2.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Emp_Project>? emp_projects { get; set; }

    }
}
