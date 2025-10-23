#nullable disable
#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional
namespace Day_1.Migrations
{
    /// <inheritdoc />
    public partial class addCourseclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descraption = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Descraption", "Duration", "CourseName" },
                values: new object[,]
                {
                    { 1, "Learn the fundamentals of C# programming language, including OOP and .NET basics.", 40, "C# Programming" },
                    { 2, "Develop web applications using ASP.NET Core MVC framework.", 45, "ASP.NET Core MVC" },
                    { 3, "Master web design fundamentals using HTML5 and CSS3.", 25, "HTML5 & CSS3" },
                    { 4, "Advanced concepts of JavaScript including ES6 features and asynchronous programming.", 40, "JavaScript Advanced" },
                    { 5, "Build interactive web interfaces using React.js and component-based development.", 50, "React.js Framework" },
                    { 6, "Develop scalable front-end applications using Angular.", 55, "Angular" },
                    { 7, "Introduction to machine learning concepts, models, and algorithms.", 60, "Machine Learning Basics" },
                    { 8, "Explore neural networks and deep learning techniques.", 70, "Deep Learning" },
                    { 9, "Create cross-platform mobile applications using Flutter and Dart.", 45, "Flutter" },
                    { 10, "Build native mobile apps using React Native.", 50, "React Native" },
                    { 11, "Develop Android apps using Kotlin language.", 55, "Android Kotlin" },
                    { 12, "Learn to build iOS applications using Swift.", 55, "iOS Swift" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseName",
                table: "Courses",
                column: "CourseName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
