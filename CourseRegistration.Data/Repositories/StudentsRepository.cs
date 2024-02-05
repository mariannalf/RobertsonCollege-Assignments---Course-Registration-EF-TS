using CourseRegistration.Data.Domain;
using CourseRegistration.Data.Dto;

namespace CourseRegistration.Data;

public class StudentsRepository
{
    public static IList<StudentDto> ListStudents()
    {
        using (var db = new CourseRegistrationContext())
        {
            var list = db.Students.Select(x => new StudentDto()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Phone = x.Phone
            }).ToList();

            return list;
        }
    }

    public static void AddOrUpdateStudent(int? id, string? firstName, string? lastName, string? email, string? phoneNumber)
    {
        using (var db = new CourseRegistrationContext())
        {
            var student = id != null && id != default ? db.Students.FirstOrDefault(x => x.Id == id) : null;
            if (id != null && id != default && student == null)
            {
                throw new ApplicationException("Student not found");
            }

            if (student == null)
            {
                var existingEmail = db.Students.Any(x => x.Email == email);
                if (existingEmail)
                {
                    throw new ApplicationException("Student email already exists");
                }
                student = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Phone = phoneNumber
                };
                db.Students.Add(student);
            }
            else
            {
                student.FirstName = firstName;
                student.LastName = lastName;
                student.Email = email;
                student.Phone = phoneNumber;
            }

            db.SaveChanges();
        }
    }
    public static void DeleteStudent(int? id)
    {
        if (id == null || id == default)
        {
            throw new ApplicationException("Invalid Student id");
        }

        using (var db = new CourseRegistrationContext())
        {
            var student = db.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                throw new ApplicationException("Student not found");
            }
            db.Students.Remove(student);
            db.SaveChanges();
        }
    }
}