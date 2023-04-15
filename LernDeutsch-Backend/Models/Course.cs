using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace LernDeutsch_Backend.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Level { get; set; }
        public int Length { get; set; }
        public double Price { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
        [Required]
        public Tutor Tutor { get; set; }

       

    }

}
