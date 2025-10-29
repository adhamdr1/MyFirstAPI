using Day_1.Repositry.Interface;

namespace Day_1.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepositry<Student> StudentRepo { get; }
        IGenericRepositry<Department> DepartmentRepo { get; }
        IGenericRepositry<Course> CourseRepo { get; }
        void Save();
    }
}
