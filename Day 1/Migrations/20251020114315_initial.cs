#nullable disable
#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional
namespace Day_1.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Location", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Ahmed Ali", "Backend " },
                    { 2, "Mona Salah", "Frontend " },
                    { 3, "Omar Khalid", "FullStack " },
                    { 4, "Sara Ahmed", "Artificial Intelligence" },
                    { 5, "Ali Hassan", "Mobile " },
                    { 6, "Nour Mahmoud", "Data Science" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "DepartmentId", "FullName", "Age" },
                values: new object[,]
                {
                    { 1, "Alex", 1, "Ahmed Mohamed", 18 },
                    { 2, "Mansura", 5, "Mohamed Ali", 22 },
                    { 3, "Gize", 2, "Hana Magdy", 19 },
                    { 4, "Cairo", 6, "Omar Khaled", 23 },
                    { 5, "Suez", 4, "Khaled Mahmoud", 22 },
                    { 6, "Alex", 3, "Nadin Hossam", 21 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentId",
                table: "Students",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
