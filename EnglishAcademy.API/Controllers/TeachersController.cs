using System;
using System.Collections.Generic;
using EnglishAcademy.API.Entities;
using EnglishAcademy.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnglishAcademy.API.Controllers
{
    [Route("api/teachers")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IEnglishAccademyRepository _englishAccademyRepository;

        public TeachersController(IEnglishAccademyRepository englishAccademyRepository)
        {
            _englishAccademyRepository = englishAccademyRepository ??
                throw new ArgumentNullException(nameof(englishAccademyRepository));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Teacher>> GetTeachers()
        {
            var teachersFromRepo = _englishAccademyRepository.GetTeachers();

            return Ok(teachersFromRepo);
        }

        [HttpGet("{teacherId}", Name = "GetTeacher")]
        public IActionResult GetAuthor(int teacherId)
        {
            var teacherFromRepo = _englishAccademyRepository.GetTeacher(teacherId);

            if (teacherFromRepo == null) return NotFound();

            return Ok(teacherFromRepo);
        }

        [HttpPost(Name = "CreateTeacher")]
        public ActionResult<Teacher> CreateAuthor(Teacher teacher)
        {
            if (teacher == null) return BadRequest();

            _englishAccademyRepository.AddTeacher(teacher);
            _englishAccademyRepository.Save();

            return CreatedAtRoute("GetTeacher",
                new { teacherId = teacher.Id },
                teacher);
        }

        [HttpDelete("{teacherId}", Name = "DeleteTeacher")]
        public ActionResult DeteleCourseForAuthor(int teacherId)
        {
            if (!_englishAccademyRepository.TeacherExists(teacherId))
                return NotFound();

            var teacherFromRepo = _englishAccademyRepository.GetTeacher(teacherId);

            if (teacherFromRepo == null)
                return NotFound();

            _englishAccademyRepository.DeleteTeacher(teacherFromRepo);
            _englishAccademyRepository.Save();

            return NoContent();
        }

    }
}
