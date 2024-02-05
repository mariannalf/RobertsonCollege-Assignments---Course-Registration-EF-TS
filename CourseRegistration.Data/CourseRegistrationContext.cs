using CourseRegistration.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace CourseRegistration.Data;

public class CourseRegistrationContext : DbContext
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Instructor> Instructors { get; set; }

    public string DbPath { get; }

    public CourseRegistrationContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "course-registration-context.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Student>()
            .HasMany(x => x.EnrolledCourses)
            .WithMany(x => x.Students)
            .UsingEntity(
                "StudentCourses",
                l => l.HasOne(typeof(Course)).WithMany().HasForeignKey("CourseId").HasPrincipalKey(nameof(Course.Id)),
                r => r.HasOne(typeof(Student)).WithMany().HasForeignKey("StudentId").HasPrincipalKey(nameof(Student.Id)),
                j =>
                {
                    j.HasKey("CourseId", "StudentId");
                    j.HasData(
                        new { CourseId = 1, StudentId = 2 },
                        new { CourseId = 1, StudentId = 3 },
                        new { CourseId = 1, StudentId = 9 },
                        new { CourseId = 1, StudentId = 10 },
                        new { CourseId = 1, StudentId = 11 },
                        new { CourseId = 1, StudentId = 19 },
                        new { CourseId = 1, StudentId = 20 },
                        new { CourseId = 2, StudentId = 1 },
                        new { CourseId = 2, StudentId = 2 },
                        new { CourseId = 2, StudentId = 7 },
                        new { CourseId = 3, StudentId = 10 },
                        new { CourseId = 3, StudentId = 14 },
                        new { CourseId = 3, StudentId = 15 },
                        new { CourseId = 3, StudentId = 19 },
                        new { CourseId = 3, StudentId = 20 },
                        new { CourseId = 4, StudentId = 1 },
                        new { CourseId = 4, StudentId = 2 },
                        new { CourseId = 4, StudentId = 9 },
                        new { CourseId = 4, StudentId = 10 },
                        new { CourseId = 4, StudentId = 11 },
                        new { CourseId = 5, StudentId = 1 },
                        new { CourseId = 5, StudentId = 2 },
                        new { CourseId = 5, StudentId = 5 },
                        new { CourseId = 5, StudentId = 11 },
                        new { CourseId = 5, StudentId = 12 },
                        new { CourseId = 5, StudentId = 17 },
                        new { CourseId = 5, StudentId = 19 },
                        new { CourseId = 5, StudentId = 20 }
                    );
                });

        modelBuilder.Entity<Course>().HasData(
            new { Id = 1, CourseNumber = 101, Name = "Math", Description = "Basic Math" },
            new { Id = 2, CourseNumber = 102, Name = "Science", Description = "Basic Science" },
            new { Id = 3, CourseNumber = 103, Name = "History", Description = "Basic History" },
            new { Id = 4, CourseNumber = 104, Name = "English", Description = "Basic English" },
            new { Id = 5, CourseNumber = 105, Name = "Art", Description = "Basic Art" }
        );

        modelBuilder.Entity<Instructor>().HasData(
            new { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", CourseId = 1 },
            new { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", CourseId = 2 },
            new { Id = 3, FirstName = "Michael", LastName = "Johnson", Email = "michael.johnson@example.com", CourseId = 3 },
            new { Id = 4, FirstName = "Emily", LastName = "Brown", Email = "emily.brown@example.com", CourseId = 4 },
            new { Id = 5, FirstName = "David", LastName = "Wilson", Email = "david.wilson@example.com", CourseId = 5 }
        );

        modelBuilder.Entity<Student>().HasData(
            new { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Phone = "1234567890" },
            new { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Phone = "9876543210" },
            new { Id = 3, FirstName = "Alice", LastName = "Johnson", Email = "alice.johnson@example.com", Phone = "5555555555" },
            new { Id = 4, FirstName = "Bob", LastName = "Williams", Email = "bob.williams@example.com", Phone = "6666666666" },
            new { Id = 5, FirstName = "Emily", LastName = "Brown", Email = "emily.brown@example.com", Phone = "7777777777" },
            new { Id = 6, FirstName = "Michael", LastName = "Jones", Email = "michael.jones@example.com", Phone = "8888888888" },
            new { Id = 7, FirstName = "Olivia", LastName = "Taylor", Email = "olivia.taylor@example.com", Phone = "9999999999" },
            new { Id = 8, FirstName = "William", LastName = "Clark", Email = "william.clark@example.com", Phone = "1111111111" },
            new { Id = 9, FirstName = "Sophia", LastName = "Lewis", Email = "sophia.lewis@example.com", Phone = "2222222222" },
            new { Id = 10, FirstName = "James", LastName = "Hall", Email = "james.hall@example.com", Phone = "3333333333" },
            new { Id = 11, FirstName = "Ava", LastName = "Young", Email = "ava.young@example.com", Phone = "4444444444" },
            new { Id = 12, FirstName = "Benjamin", LastName = "Lee", Email = "benjamin.lee@example.com", Phone = "5555555555" },
            new { Id = 13, FirstName = "Mia", LastName = "Walker", Email = "mia.walker@example.com", Phone = "6666666666" },
            new { Id = 14, FirstName = "Ethan", LastName = "Hall", Email = "ethan.hall@example.com", Phone = "7777777777" },
            new { Id = 15, FirstName = "Isabella", LastName = "Gonzalez", Email = "isabella.gonzalez@example.com", Phone = "8888888888" },
            new { Id = 16, FirstName = "Alexander", LastName = "Harris", Email = "alexander.harris@example.com", Phone = "9999999999" },
            new { Id = 17, FirstName = "Charlotte", LastName = "King", Email = "charlotte.king@example.com", Phone = "1111111111" },
            new { Id = 18, FirstName = "Daniel", LastName = "Wright", Email = "daniel.wright@example.com", Phone = "2222222222" },
            new { Id = 19, FirstName = "Scarlett", LastName = "Lopez", Email = "scarlett.lopez@example.com", Phone = "3333333333" },
            new { Id = 20, FirstName = "Henry", LastName = "Scott", Email = "henry.scott@example.com", Phone = "4444444444" }
        );


    }
}
