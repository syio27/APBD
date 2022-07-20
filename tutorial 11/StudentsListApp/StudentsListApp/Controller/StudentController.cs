using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsListApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsListApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private List<Student> students;

        public StudentController()
        {
            students = new List<Student>
        {
            new Student()
            {
                ID = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                BirthDate = DateTime.Now,
                Studies = "IT"
            },
            new Student()
            {
                ID = 2,
                FirstName = "Anna",
                LastName = "Malewska",
                BirthDate = DateTime.Now,
                Studies = "IT"
            },
            new Student()
            {
                ID = 3,
                FirstName = "Ala",
                LastName = "Makota",
                BirthDate = DateTime.Now,
                Studies = "IT"
            },
        };
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(students);
        }

        [HttpDelete("{index}")]
        public IActionResult DeleteStudent(string index)
        {
            int studentID = int.Parse(index);

            var student = students.SingleOrDefault(x => x.ID == studentID);
            if (student != null)
                students.Remove(student);

            return NoContent();
        }
    }
}
