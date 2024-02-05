namespace CourseRegistration.Data.Domain;

public class Instructor
{
    private string _firstName;
    private string _lastName;
    private string _email;
    private Course _course;

    public int Id { get; set; }
    public string FirstName
    {
        get => _firstName; set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("First name cannot be null or empty");
            }
            _firstName = value;
        }
    }
    public string LastName
    {
        get => _lastName; set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Last name cannot be null or empty");
            }
            _lastName = value;
        }
    }
    public string Email
    {
        get => _email; set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Email cannot be null or empty");
            }
            if (!value.Contains("@"))
            {
                throw new ArgumentException("Email must contain @");
            }
            if (!value.Contains("."))
            {
                throw new ArgumentException("Email must contain .");
            }
            _email = value;
        }
    }
    public Course Course
    {
        get => _course; set
        {
            if (value == null)
            {
                throw new ArgumentException("Course cannot be null");
            }
            _course = value;
        }
    }
}


