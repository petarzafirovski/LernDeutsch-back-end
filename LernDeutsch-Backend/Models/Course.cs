using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using LernDeutsch_Backend.Models.Identity;

namespace LernDeutsch_Backend.Models
{
    public class Course
    {
        [Key]
        public Guid CourseId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string Level { get; set; } = null!;
        public int Length { get; set; }
        public double Price { get; set; }
        [Required]
        public Tutor Tutor { get; set; }

        public virtual List<CourseStudent> Students { get; set; } = new();
        public virtual List<Lesson> Lessons { get; set; } = new();

       

    }

}
