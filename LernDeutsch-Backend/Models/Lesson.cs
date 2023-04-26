using System.ComponentModel.DataAnnotations;

namespace LernDeutsch_Backend.Models
{
    public class Lesson
    {
        [Key]
        public Guid LessonId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Content { get; set; }

        [Required]
        public Course Course { get; set; }

        public virtual List<Quiz> Quizzes { get; set; } = new List<Quiz>();

        
    }
}
