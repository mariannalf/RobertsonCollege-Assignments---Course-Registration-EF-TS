using CourseRegistration.Data;
using CourseRegistration.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegistration.Controllers;

public class StudentsController : Controller
{
    public IActionResult Index()
    {
        var students = StudentsRepository.ListStudents();

        return View(students);
    }



    [HttpPost]
    public IActionResult Index([FromForm] int? id, [FromForm] string? firstName, [FromForm] string? lastName, [FromForm] string? email, [FromForm] string? phoneNumber)
    {
        try
        {
            StudentsRepository.AddOrUpdateStudent(id, firstName, lastName, email, phoneNumber);
        }
        catch (Exception e)
        {
            ModelState.AddModelError("Error", e.Message);
        }

        var students = StudentsRepository.ListStudents();
        return View(students);
    }


    [HttpDelete("/Students/{id}")]
    public IActionResult Delete(int? id)
    {
        StudentsRepository.DeleteStudent(id);

        return NoContent();
    }
}

