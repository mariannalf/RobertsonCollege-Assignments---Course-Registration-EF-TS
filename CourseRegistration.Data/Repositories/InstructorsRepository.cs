using CourseRegistration.Data.Domain;
using CourseRegistration.Data.Dto;

namespace CourseRegistration.Data;

public class InstructorsRepository
{
    public static void AddOrUpdateInstructor(int? id, string? firstName, string? lastName, string? email, int? courseId)
    {
        using (var db = new CourseRegistrationContext())
        {
            var instructor = id != null && id != default ? db.Instructors.FirstOrDefault(x => x.Id == id) : null;
            if (id != null && id != default && instructor == null)
            {
                throw new ApplicationException("Instructor not found");
            }
            var course = db.Courses.FirstOrDefault(x => x.Id == courseId);
            if (course == null)
            {
                throw new ApplicationException("Course not found");
            }

            if (instructor == null)
            {
                var existingEmail = db.Instructors.Any(x => x.Email == email);
                if (existingEmail)
                {
                    throw new ApplicationException("Instructor email already exists");
                }
                instructor = new Instructor()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Course = course
                };
                db.Instructors.Add(instructor);
            }
            else
            {
                instructor.FirstName = firstName;
                instructor.LastName = lastName;
                instructor.Email = email;
                instructor.Course = course;
            }

            db.SaveChanges();
        }
    }
    public static void DeleteInstructor(int? id)
    {
        if (id == null || id == default)
        {
            throw new ApplicationException("Invalid instructor id");
        }

        using (var db = new CourseRegistrationContext())
        {
            var instructor = db.Instructors.FirstOrDefault(x => x.Id == id);
            if (instructor == null)
            {
                throw new ApplicationException("Instructor not found");
            }
            db.Instructors.Remove(instructor);
            db.SaveChanges();
        }
    }

    public static IList<InstructorDto> ListInstructors()
    {
        using (var db = new CourseRegistrationContext())
        {
            var list = db.Instructors.Select(x => new InstructorDto()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Course = new CourseDto()
                {
                    Id = x.Course.Id,
                    Name = x.Course.Name
                }
            }).ToList();

            return list;
        }
    }
}
