using CourseRegistration.Data;
using CourseRegistration.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegistration.Controllers;

public class InstructorsController : Controller
{
    public IActionResult Index()
    {
        var instructors = InstructorsRepository.ListInstructors();
        var courses = CoursesRepository.ListCourses();
        return View((instructors, courses));
    }


    [HttpPost]
    public IActionResult Index([FromForm] int? id, [FromForm] string? firstName, [FromForm] string? lastName, [FromForm] string? email, [FromForm] int? courseId)
    {
        try
        {
            InstructorsRepository.AddOrUpdateInstructor(id, firstName, lastName, email, courseId);
        }
        catch (Exception e)
        {
            ModelState.AddModelError("Error", e.Message);
        }

        var instructors = InstructorsRepository.ListInstructors();
        var courses = CoursesRepository.ListCourses();
        return View((instructors, courses));
    }


    [HttpDelete("/Instructors/{id}")]
    public IActionResult Delete(int? id)
    {
        InstructorsRepository.DeleteInstructor(id);

        return NoContent();
    }
}

