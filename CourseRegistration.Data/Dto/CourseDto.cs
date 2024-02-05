
namespace CourseRegistration.Data.Dto;

public class CourseDto
{
    public int CourseNumber { get; internal set; }
    public int Id { get; internal set; }
    public string Name { get; internal set; }
    public string Description { get; internal set; }
    public List<StudentDto> EnrolledStudents { get; internal set; }
}
