using System.Collections.Generic;

namespace EnglishAcademy.API.Entities
{
    public class Teacher : PersonEntity
    {
        public ICollection<Course> Courses { get; set; }
        = new List<Course>();
    }
}
