namespace Day_1.DTO
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<string> StudentsName { get; set; } = new List<string>();
    }
}
