namespace Day_1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int? age { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        // [JsonIgnore] // is not the best way 
        public virtual Department? Department { get; set; }
    }
}
