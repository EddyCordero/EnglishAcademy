using System;
using System.Collections.Generic;
using System.Linq;
using EnglishAcademy.API.DbContexts;
using EnglishAcademy.API.Entities;

namespace EnglishAcademy.API.Services
{
    public class EnglishAccademyRepository : IEnglishAccademyRepository, IDisposable
    {
        private readonly EnglishAccademyContext _context;

        public EnglishAccademyRepository(EnglishAccademyContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Teacher> GetTeachers()
        {
            return _context.Teachers.ToList();
        }

        public Teacher GetTeacher(int teacherId)
        {
            return _context.Teachers.FirstOrDefault(a => a.Id == teacherId);
        }

        public void AddAuthor(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }

            _context.Teachers.Add(teacher);
        }

        public void DeleteTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }

            _context.Teachers.Remove(teacher);
        }

        public bool TeacherExists(int teacherId)
        {
            return _context.Teachers.Any(a => a.Id == teacherId);
        }

        public void AddTeacher(Teacher teacher)
        {
            if(teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }

            _context.Teachers.Add(teacher);
        }

        public bool CourseHasStudents(int courseId)
        {
            return _context.Students.Any(a => a.CourseId == courseId);
        }

        public void AddCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            _context.Courses.Add(course);
        }

        //Student

        public IEnumerable<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudent(int studentId)
        {
            return _context.Students.FirstOrDefault(a => a.Id == studentId);
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            _context.Students.Add(student);
        }

        public void DeleteStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            _context.Students.Remove(student);
        }

        public bool StudentExists(int studentId)
        {
            return _context.Students.Any(a => a.Id == studentId);
        }

        //Course
        public IEnumerable<Course> GetCourses()
        {
            return _context.Courses.ToList();
        }

        public IEnumerable<Course> GetCoursesByTeacherId(int teacherId)
        {
            return _context.Courses.Where(x => x.TeacherId == teacherId).ToList();
        }

        public Course GetCurse(int id) => _context.Courses.FirstOrDefault(x => x.Id == id);

        public void DeleteCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            _context.Courses.Remove(course);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
