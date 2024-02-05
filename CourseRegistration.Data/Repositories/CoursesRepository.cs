using CourseRegistration.Data.Domain;
using CourseRegistration.Data.Dto;

namespace CourseRegistration.Data;

public class CoursesRepository
{
    public static void AddOrUpdateCourse(int? id, int courseNumber, string? name, string? description)
    {
        using (var db = new CourseRegistrationContext())
        {
            var course = id != null && id != default ? db.Courses.FirstOrDefault(x => x.Id == id) : null;
            if (id != null && id != default && course == null)
            {
                throw new ApplicationException("Course not found");
            }
            if (course == null)
            {
                var existingCourse = db.Courses.Any(x => x.CourseNumber == courseNumber);
                if (existingCourse)
                {
                    throw new ApplicationException("Course number already exists");
                }
                course = new Course()
                {
                    CourseNumber = courseNumber,
                    Name = name,
                    Description = description
                };
                db.Courses.Add(course);
            }
            else
            {
                course.CourseNumber = courseNumber;
                course.Name = name;
                course.Description = description;
            }

            db.SaveChanges();
        }
    }

    public static void DeleteCourse(int? id)
    {
        if (id == null || id == default)
        {
            throw new ApplicationException("Invalid course id");
        }

        using (var db = new CourseRegistrationContext())
        {
            var course = db.Courses.FirstOrDefault(x => x.Id == id);
            if (course == null)
            {
                throw new ApplicationException("Course not found");
            }
            db.Courses.Remove(course);
            db.SaveChanges();
        }
    }

    public static IList<CourseDto> ListCourses()
    {
        using (var db = new CourseRegistrationContext())
        {
            var list = db.Courses.Select(x => new CourseDto()
            {
                Id = x.Id,
                CourseNumber = x.CourseNumber,
                Name = x.Name,
                Description = x.Description,
                EnrolledStudents = x.Students.Select(y => new StudentDto()
                {
                    Id = y.Id,
                    FirstName = y.FirstName,
                    LastName = y.LastName,
                    Email = y.Email
                }).ToList()
            }).ToList();

            return list;
        }
    }
}
