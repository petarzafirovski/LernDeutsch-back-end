using System.ComponentModel.DataAnnotations;

namespace LernDeutsch_Backend.Models
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Content { get; set; }
        public List<Quiz> Quizzes { get; set; } = new List<Quiz>();

        [Required]
        public Course Course { get; set; }

        
    }
}
