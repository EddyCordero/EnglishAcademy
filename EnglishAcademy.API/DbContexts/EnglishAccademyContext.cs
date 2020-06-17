using System;
using EnglishAcademy.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnglishAcademy.API.DbContexts
{
    public class EnglishAccademyContext : DbContext
    {
        public EnglishAccademyContext(DbContextOptions<EnglishAccademyContext> options)
            : base(options)
        { }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasData(new Teacher
            {
                Id = 1,
                FirstName = "Juan",
                LastName = "Perez",
                DateOfBirth = new DateTime(1995, 7, 23),
            });

            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 1,
                FirstName = "Maria",
                LastName = "Lorenzo",
                DateOfBirth = new DateTime(1995, 7, 23),
            });

            modelBuilder.Entity<Course>().HasData(new Course
            {
                Id = 1,
                Title = "Engish 1",
                Description = "En este curso el estudiante aprendera a mantener conversaciones sencillas"
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
