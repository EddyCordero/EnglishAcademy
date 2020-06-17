using System;
using System.ComponentModel.DataAnnotations;

namespace EnglishAcademy.API.Entities
{
    public class PersonEntity : Entity
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTimeOffset DateOfBirth { get; set; }
    }
}
