namespace Day_1.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Loc { get; set; }
        public virtual ICollection<Student>? Students { get; set; }
    }
}
