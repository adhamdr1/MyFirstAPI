using Day_1.Repositry;
using Day_1.Repositry.Interface;
using Day_1.UnitOfWork.Interface;

namespace Day_1.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly AppDbContext context;

        IGenericRepositry<Student> studentRepo;
        IGenericRepositry<Department> departmentRepo;
        IGenericRepositry<Course> courseRepo;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        public IGenericRepositry<Student> StudentRepo
        {
            get
            {
                if (studentRepo == null) 
                {
                    studentRepo = new GenericRepositry<Student>(context);
                }
                return studentRepo;
            }      
        }

        public IGenericRepositry<Department> DepartmentRepo
        {
            get
            {
                if (departmentRepo == null)
                {
                    departmentRepo = new GenericRepositry<Department>(context);
                }
                return departmentRepo;
            }
        }

        public IGenericRepositry<Course> CourseRepo
        {
            get
            {
                if (courseRepo == null)
                {
                    courseRepo = new GenericRepositry<Course>(context);
                }
                return courseRepo;
            }
        }

        public void Dispose() => context.Dispose();

        public void Save() => context.SaveChanges();

    }
}
