using System.ComponentModel.DataAnnotations.Schema;

namespace EnglishAcademy.API.Entities
{
    public class Student : PersonEntity
    {

        public int? CourseId { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }
    }
}
