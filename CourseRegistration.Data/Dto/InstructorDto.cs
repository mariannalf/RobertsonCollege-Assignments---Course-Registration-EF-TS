namespace CourseRegistration.Data.Dto;

public class InstructorDto
{
    public CourseDto Course { get; internal set; }
    public string Email { get; internal set; }
    public string LastName { get; internal set; }
    public string FirstName { get; internal set; }
    public int Id { get; internal set; }
}
