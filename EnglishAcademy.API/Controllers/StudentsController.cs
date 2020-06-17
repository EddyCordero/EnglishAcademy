using System;
using System.Collections.Generic;
using EnglishAcademy.API.Entities;
using EnglishAcademy.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnglishAcademy.API.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IEnglishAccademyRepository _englishAccademyRepository;

        public StudentsController(IEnglishAccademyRepository englishAccademyRepository)
        {
            _englishAccademyRepository = englishAccademyRepository ??
                throw new ArgumentNullException(nameof(englishAccademyRepository));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            var teachersFromRepo = _englishAccademyRepository.GetStudents();

            return Ok(teachersFromRepo);
        }

        [HttpGet("{studentId}", Name = "GetStudent")]
        public IActionResult GetStudent(int studentId)
        {
            var studentFromRepo = _englishAccademyRepository.GetStudent(studentId);

            if (studentFromRepo == null) return NotFound();

            return Ok(studentFromRepo);
        }

        [HttpPost(Name = "CreateStudent")]
        public ActionResult<Teacher> CreateAuthor(Student student)
        {
            if (student == null) return BadRequest();

            _englishAccademyRepository.AddStudent(student);
            _englishAccademyRepository.Save();

            return CreatedAtRoute("GetStudent",
                new { authorId = student.Id },
                student);
        }

        [HttpDelete("{teacherId}", Name = "DeleteStudent")]
        public ActionResult DeteleCourseForAuthor(int studentId)
        {
            if (!_englishAccademyRepository.StudentExists(studentId))
                return NotFound();

            var studentFromRepo = _englishAccademyRepository.GetStudent(studentId);

            if (studentFromRepo == null)
                return NotFound();

            _englishAccademyRepository.DeleteStudent(studentFromRepo);
            _englishAccademyRepository.Save();

            return NoContent();
        }
    }
}
