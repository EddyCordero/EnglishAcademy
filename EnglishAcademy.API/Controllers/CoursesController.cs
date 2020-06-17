using System;
using System.Collections.Generic;
using EnglishAcademy.API.Entities;
using EnglishAcademy.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnglishAcademy.API.Controllers
{
    [ApiController]
    [Route("api/Teachers/{teacherId}/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly IEnglishAccademyRepository _englishAccademyRepository;

        public CoursesController(IEnglishAccademyRepository englishAccademyRepository)
        {
            _englishAccademyRepository = englishAccademyRepository ??
                throw new ArgumentNullException(nameof(englishAccademyRepository));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetCoursesByTeacherId(int teacherId)
        {
            var coursesFromRepo = _englishAccademyRepository.GetCoursesByTeacherId(teacherId);

            return Ok(coursesFromRepo);
        }

        [HttpGet("{id}", Name = "GetCourse")]
        public IActionResult GeCourse(int courseId)
        {
            var courseFromRepo = _englishAccademyRepository.GetCurse(courseId);

            if (courseFromRepo == null) return NotFound();

            return Ok(courseFromRepo);
        }

        [HttpPost(Name = "CreateCourse")]
        public ActionResult<Teacher> CreateCourse(Course course)
        {
            if (course == null) return BadRequest();

            _englishAccademyRepository.AddCourse(course);
            _englishAccademyRepository.Save();

            return CreatedAtRoute("GetCourse",
                new { authorId = course.Id },
                course);
        }

        [HttpDelete("{courseId}", Name = "DeleteCourse")]
        public ActionResult DeleteCourse(int courseId)
        {
            if (!_englishAccademyRepository.CourseHasStudents(courseId))
                return NotFound();

            var courseFromRepo = _englishAccademyRepository.GetCurse(courseId);

            if (courseFromRepo == null)
                return NotFound();

            _englishAccademyRepository.DeleteCourse(courseFromRepo);
            _englishAccademyRepository.Save();

            return NoContent();
        }
    }
}
