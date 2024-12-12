using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly ApplicationDbContext _context = new ApplicationDbContext();

    [HttpGet]
    public IActionResult GetStudents()
    {
        try
        {
            var students = _context.Students.ToList();
            return Ok(students);
        }
        catch (Exception ex)
        {
            Eng.Instance.EngException($"Error in GetStudents: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    public IActionResult CreateStudent(Student student)
    {
        try
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return Ok(student);
        }
        catch (Exception ex)
        {
            Eng.Instance.EngException($"Error in CreateStudent: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }
}
