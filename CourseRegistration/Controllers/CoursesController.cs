using CourseRegistration.Data;
using CourseRegistration.Data.Domain;
using CourseRegistration.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegistration.Controllers;

public class CoursesController : Controller
{
    public IActionResult Index()
    {
        var courses = CoursesRepository.ListCourses();
        return View(courses);
    }

    [HttpPost]
    public IActionResult Index([FromForm] int? id, [FromForm] int courseNumber, [FromForm] string? name, [FromForm] string? description)
    {
        try
        {
            CoursesRepository.AddOrUpdateCourse(id, courseNumber, name, description);
        }
        catch (Exception e)
        {
            ModelState.AddModelError("Error", e.Message);
        }

        var courses = CoursesRepository.ListCourses();
        return View(courses);
    }

    [HttpDelete("/Courses/{id}")]
    public IActionResult Delete(int? id)
    {
        CoursesRepository.DeleteCourse(id);

        return NoContent();
    }
}

