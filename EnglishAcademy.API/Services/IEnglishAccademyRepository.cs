using System;
using System.Collections.Generic;
using EnglishAcademy.API.Entities;

namespace EnglishAcademy.API.Services
{
    public interface IEnglishAccademyRepository
    {
        public IEnumerable<Teacher> GetTeachers();
        public Teacher GetTeacher(int teacherId);
        public void AddTeacher(Teacher teacher);
        public void DeleteTeacher(Teacher teacher);
        public bool TeacherExists(int teacherId);

        //Student
        public IEnumerable<Student> GetStudents();
        public Student GetStudent(int studentId);
        public void AddStudent(Student student);
        public void DeleteStudent(Student student);
        public bool StudentExists(int studentId);

        //Course
        public IEnumerable<Course> GetCourses();
        public IEnumerable<Course> GetCoursesByTeacherId(int teacherId);
        public bool CourseHasStudents(int courseId);
        public void AddCourse(Course course);
        public Course GetCurse(int courseId);
        public void DeleteCourse(Course course);

        public bool Save();

        public void Dispose();
        public IEnumerable<Student> GetStudentsByCourseId(int courseId);
        void UpdateTeacher(Teacher teacher);
        void UpdateStudent(Student student);
        void UpdateCourse(Course course);
    }
}
