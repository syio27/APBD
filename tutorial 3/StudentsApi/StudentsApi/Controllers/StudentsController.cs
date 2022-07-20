using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsApi.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = new CSV().ReadFile(@".\Data\data.csv");
            return Ok(students);
        }


        [HttpGet("{index}")]
        public IActionResult GetStudents(string index)
        {
            var specifiedStud = new CSV().ReadFile(@".\Data\data.csv");
            foreach (Student s in specifiedStud)
            {
                if (s.IndexNumber.Equals(index))
                {
                    return Ok(s);
                }
            }
            return NotFound();
        }

        [HttpPut("{index}")]
        public IActionResult UpdateStudent(string index, Student student)
        {
            if (!new CSV().isIndexWellFormatted(index))
            {
                throw new IndexIsNotCorrectFormattedException("the index value is not correct formatted");
            }
            Student st = new CSV().UpdateFile(student, @".\Data\data.csv", index);
            return Ok(st);
        }

        [HttpPost]
        public IActionResult AddStudents(Student student)
        {
            new CSV().WriteFile(student, @".\Data\data.csv");
            return StatusCode(201);
        }

        [HttpDelete("{index}")]
        public IActionResult DeleteStudent(string index)
        {
            if (!new CSV().isIndexWellFormatted(index))
            {
                throw new IndexIsNotCorrectFormattedException("the index value is not correct formatted");
            }
            new CSV().DeleteFromFile(index);
            return Ok();
        }
    }
}
