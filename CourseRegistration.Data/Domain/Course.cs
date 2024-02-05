
namespace CourseRegistration.Data.Domain;

public class Course
{
    public int Id { get; protected set; }

    private int _courseNumber;

    public int CourseNumber
    {
        get => _courseNumber; set
        {
            if (value <= 0)
            {
                throw new ApplicationException("Course number must be greater than 0");
            }
            _courseNumber = value;
        }
    }

    private string _name;
    public string Name
    {
        get => _name; set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ApplicationException("Name is required");
            }
            _name = value;
        }
    }
    private string _description;

    public string Description
    {
        get => _description; set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ApplicationException("Description is required");
            }
            _description = value;
        }
    }

    public IList<Student> Students { get; set; } = new List<Student>();

}


