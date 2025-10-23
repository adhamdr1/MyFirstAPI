using Day_1.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_1.Data.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                // Backend Courses
                new Course
    {
        Id = 1,
        Name = "C# Programming",
        Description = "Learn the fundamentals of C# programming language, including OOP and .NET basics.",
        Duration = 40
    },
                new Course
    {
        Id = 2,
        Name = "ASP.NET Core MVC",
        Description = "Develop web applications using ASP.NET Core MVC framework.",
        Duration = 45
    },
            
                // Frontend Courses
                new Course
    {
        Id = 3,
        Name = "HTML5 & CSS3",
        Description = "Master web design fundamentals using HTML5 and CSS3.",
        Duration = 25
    },
                new Course
    {
        Id = 4,
        Name = "JavaScript Advanced",
        Description = "Advanced concepts of JavaScript including ES6 features and asynchronous programming.",
        Duration = 40
    },
                new Course
    {
        Id = 5,
        Name = "React.js Framework",
        Description = "Build interactive web interfaces using React.js and component-based development.",
        Duration = 50
    },
                new Course
    {
        Id = 6,
        Name = "Angular",
        Description = "Develop scalable front-end applications using Angular.",
        Duration = 55
    },
            
                // AI & Data Science Courses
                new Course
    {
        Id = 7,
        Name = "Machine Learning Basics",
        Description = "Introduction to machine learning concepts, models, and algorithms.",
        Duration = 60
    },
                new Course
    {
        Id = 8,
        Name = "Deep Learning",
        Description = "Explore neural networks and deep learning techniques.",
        Duration = 70
    },
            
                // Mobile Development Courses
                new Course
    {
        Id = 9,
        Name = "Flutter",
        Description = "Create cross-platform mobile applications using Flutter and Dart.",
        Duration = 45
    },
                new Course
                {
                    Id = 10,
                    Name = "React Native",
                    Description = "Build native mobile apps using React Native.",
                    Duration = 50
                },
                new Course
    {
        Id = 11,
        Name = "Android Kotlin",
        Description = "Develop Android apps using Kotlin language.",
        Duration = 55
    },
                new Course
    {
        Id = 12,
        Name = "iOS Swift",
        Description = "Learn to build iOS applications using Swift.",
        Duration = 55
    }
            );

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1,  Name = "Backend ", Loc = "Ahmed Ali" },
                new Department { Id = 2,  Name = "Frontend ", Loc = "Mona Salah" },
                new Department { Id = 3,  Name = "FullStack ", Loc = "Omar Khalid" },
                new Department { Id = 4,  Name = "Artificial Intelligence", Loc = "Sara Ahmed" },
                new Department { Id = 5,  Name = "Mobile ", Loc = "Ali Hassan" },
                new Department { Id = 6,  Name = "Data Science", Loc = "Nour Mahmoud" }
                //new Department { Id = 7,  Name = "Cyber Security", ManagerName = "Hassan Kamel" },
                //new Department { Id = 8,  Name = "Cloud Computing", ManagerName = "Fatma Salem" },
                //new Department { Id = 9,  Name = "DevOps", ManagerName = "Karim Adel" },
                //new Department { Id = 10, Name = "UI/UX Design", ManagerName = "Laila Ashraf" },
                //new Department { Id = 11, Name = "Game Development", ManagerName = "Tarek Nasser" },
                //new Department { Id = 12, Name = "Blockchain", ManagerName = "Rana Hisham" },
                //new Department { Id = 13, Name = "Internet of Things", ManagerName = "Walid Ramy" },
                //new Department { Id = 14, Name = "Big Data", ManagerName = "Dina Saad" },
                //new Department { Id = 15, Name = "Machine Learning", ManagerName = "Khaled Farouk" }
            );

            // ✅ Students (30 طالب)
            modelBuilder.Entity<Student>().HasData(
                new Student {  Id = 1,Address ="Alex",FullName = "Ahmed Mohamed", age = 18, DepartmentId = 1 },
                new Student {  Id = 2,Address ="Mansura",FullName = "Mohamed Ali",age = 22, DepartmentId = 5 },
                new Student {  Id = 3,Address ="Gize",FullName = "Hana Magdy",    age = 19, DepartmentId = 2 },
                new Student {  Id = 4,Address ="Cairo",FullName = "Omar Khaled",  age = 23, DepartmentId = 6 },
                new Student {  Id = 5,Address ="Suez",FullName = "Khaled Mahmoud",age = 22, DepartmentId = 4 },
                new Student {  Id = 6,Address ="Alex",FullName = "Nadin Hossam",  age = 21, DepartmentId = 3 }
            //    new Student {  Id = 7,Address ="b.jpg",FullName = "Ibrahim Youssef", BirthDate = new DateTime(2000, 2, 8), YearOfStudy = 1, DepartmentId = 4, ApplicationUserId = "S7" },
            //    new Student {  Id = 8,Address ="b.jpg",FullName = "Youssef Mostafa", BirthDate = new DateTime(2001, 4, 18), YearOfStudy = 2, DepartmentId = 4, ApplicationUserId = "S8" },
            //    new Student {  Id = 9,Address ="g.jpg",FullName = "Nour Farouk", BirthDate = new DateTime(1999, 6, 30), YearOfStudy = 3, DepartmentId = 5, ApplicationUserId = "S9" },
            //    new Student { Id = 10,Address ="b.jpg",FullName = "Nasser Adel", BirthDate = new DateTime(2000, 8, 22), YearOfStudy = 1, DepartmentId = 5, ApplicationUserId = "S10" },
            //    new Student { Id = 11,Address ="b.jpg",FullName = "Adel Saad", BirthDate = new DateTime(2001, 10, 14), YearOfStudy = 2, DepartmentId = 6, ApplicationUserId = "S11" },
            //    new Student { Id = 12,Address ="b.jpg",FullName = "Saad Ramy", BirthDate = new DateTime(1999, 12, 5), YearOfStudy = 3, DepartmentId = 6, ApplicationUserId = "S12" },
            //    new Student { Id = 13,Address ="g.jpg",FullName = "Mena Abdo", BirthDate = new DateTime(2000, 1, 28), YearOfStudy = 1, DepartmentId = 7, ApplicationUserId = "S13" },
            //    new Student { Id = 14,Address ="b.jpg",FullName = "Hisham Farouk", BirthDate = new DateTime(2001, 3, 17), YearOfStudy = 2, DepartmentId = 7, ApplicationUserId = "S14" },
            //    new Student { Id = 15,Address ="b.jpg",FullName = "Farouk Salem", BirthDate = new DateTime(1999, 5, 9), YearOfStudy = 3, DepartmentId = 8, ApplicationUserId = "S15" },
            //    new Student { Id = 16,Address ="b.jpg",FullName = "Salem Ashraf", BirthDate = new DateTime(2000, 7, 31), YearOfStudy = 1, DepartmentId = 8, ApplicationUserId = "S16" },
            //    new Student { Id = 17,Address ="b.jpg",FullName = "Ashraf Kamel", BirthDate = new DateTime(2001, 9, 23), YearOfStudy = 2, DepartmentId = 9, ApplicationUserId = "S17" },
            //    new Student { Id = 18,Address ="b.jpg",FullName = "Kamel Nour", BirthDate = new DateTime(1999, 11, 15), YearOfStudy = 3, DepartmentId = 9, ApplicationUserId = "S18" },
            //    new Student { Id = 19,Address ="g.jpg",FullName = "Nour Hassan", BirthDate = new DateTime(2000, 2, 7), YearOfStudy = 1, DepartmentId = 10, ApplicationUserId = "S19" },
            //    new Student { Id = 20,Address ="b.jpg",FullName = "Hassan Ahmed", BirthDate = new DateTime(2001, 4, 19), YearOfStudy = 2, DepartmentId = 10, ApplicationUserId = "S20" },
            //    new Student { Id = 21,Address ="g.jpg",FullName = "Alyaa Ashrf", BirthDate = new DateTime(1999, 6, 11), YearOfStudy = 3, DepartmentId = 11, ApplicationUserId = "S21" },
            //    new Student { Id = 22,Address ="b.jpg",FullName = "Omar Khaled", BirthDate = new DateTime(2000, 8, 3), YearOfStudy = 1, DepartmentId = 11, ApplicationUserId = "S22" },
            //    new Student { Id = 23,Address ="b.jpg",FullName = "Khaled Ali", BirthDate = new DateTime(2001, 10, 26), YearOfStudy = 2, DepartmentId = 12, ApplicationUserId = "S23" },
            //    new Student { Id = 24,Address ="b.jpg",FullName = "Ali Mohamed", BirthDate = new DateTime(1999, 12, 18), YearOfStudy = 3, DepartmentId = 12, ApplicationUserId = "S24" },
            //    new Student { Id = 25,Address ="g.jpg",FullName = "Jana Mostafa", BirthDate = new DateTime(2000, 2, 9), YearOfStudy = 1, DepartmentId = 13, ApplicationUserId = "S25" },
            //    new Student { Id = 26,Address ="b.jpg",FullName = "Hassan Ibrahim", BirthDate = new DateTime(2001, 4, 1), YearOfStudy = 2, DepartmentId = 13, ApplicationUserId = "S26" },
            //    new Student { Id = 27,Address ="b.jpg",FullName = "Ibrahim Youssef", BirthDate = new DateTime(1999, 5, 24), YearOfStudy = 3, DepartmentId = 14, ApplicationUserId = "S27" },
            //    new Student { Id = 28,Address ="b.jpg",FullName = "Youssef Mostafa", BirthDate = new DateTime(2000, 7, 16), YearOfStudy = 1, DepartmentId = 14, ApplicationUserId = "S28" },
            //    new Student { Id = 29,Address ="b.jpg",FullName = "Mostafa Nasser", BirthDate = new DateTime(2001, 9, 8), YearOfStudy = 2, DepartmentId = 15, ApplicationUserId = "S29" },
            //    new Student { Id = 30,Address ="b.jpg",FullName = "Nasser Adel", BirthDate = new DateTime(1999, 11, 30), YearOfStudy = 3, DepartmentId = 15, ApplicationUserId = "S30" }
            );
        }
    }
}