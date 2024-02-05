using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseRegistration.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.CourseId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseNumber", "Description", "Name" },
                values: new object[] { 1, 101, "Basic Math", "Math" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseNumber", "Description", "Name" },
                values: new object[] { 2, 102, "Basic Science", "Science" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseNumber", "Description", "Name" },
                values: new object[] { 3, 103, "Basic History", "History" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseNumber", "Description", "Name" },
                values: new object[] { 4, 104, "Basic English", "English" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseNumber", "Description", "Name" },
                values: new object[] { 5, 105, "Basic Art", "Art" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 1, "john.doe@example.com", "John", "Doe", "1234567890" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 2, "jane.smith@example.com", "Jane", "Smith", "9876543210" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 3, "alice.johnson@example.com", "Alice", "Johnson", "5555555555" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 4, "bob.williams@example.com", "Bob", "Williams", "6666666666" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 5, "emily.brown@example.com", "Emily", "Brown", "7777777777" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 6, "michael.jones@example.com", "Michael", "Jones", "8888888888" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 7, "olivia.taylor@example.com", "Olivia", "Taylor", "9999999999" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 8, "william.clark@example.com", "William", "Clark", "1111111111" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 9, "sophia.lewis@example.com", "Sophia", "Lewis", "2222222222" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 10, "james.hall@example.com", "James", "Hall", "3333333333" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 11, "ava.young@example.com", "Ava", "Young", "4444444444" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 12, "benjamin.lee@example.com", "Benjamin", "Lee", "5555555555" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 13, "mia.walker@example.com", "Mia", "Walker", "6666666666" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 14, "ethan.hall@example.com", "Ethan", "Hall", "7777777777" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 15, "isabella.gonzalez@example.com", "Isabella", "Gonzalez", "8888888888" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 16, "alexander.harris@example.com", "Alexander", "Harris", "9999999999" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 17, "charlotte.king@example.com", "Charlotte", "King", "1111111111" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 18, "daniel.wright@example.com", "Daniel", "Wright", "2222222222" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 19, "scarlett.lopez@example.com", "Scarlett", "Lopez", "3333333333" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 20, "henry.scott@example.com", "Henry", "Scott", "4444444444" });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "CourseId", "Email", "FirstName", "LastName" },
                values: new object[] { 1, 1, "john.doe@example.com", "John", "Doe" });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "CourseId", "Email", "FirstName", "LastName" },
                values: new object[] { 2, 2, "jane.smith@example.com", "Jane", "Smith" });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "CourseId", "Email", "FirstName", "LastName" },
                values: new object[] { 3, 3, "michael.johnson@example.com", "Michael", "Johnson" });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "CourseId", "Email", "FirstName", "LastName" },
                values: new object[] { 4, 4, "emily.brown@example.com", "Emily", "Brown" });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "CourseId", "Email", "FirstName", "LastName" },
                values: new object[] { 5, 5, "david.wilson@example.com", "David", "Wilson" });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 1, 9 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 1, 10 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 1, 11 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 1, 19 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 1, 20 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 2, 7 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 3, 10 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 3, 14 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 3, 15 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 3, 19 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 3, 20 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 4, 2 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 4, 9 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 4, 10 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 4, 11 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 5, 1 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 5, 2 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 5, 5 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 5, 11 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 5, 12 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 5, 17 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 5, 19 });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 5, 20 });

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_CourseId",
                table: "Instructors",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
