using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace LernDeutsch_Backend.Models
{
    public class Quiz
    {
        [Key]
        public int QuizId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public Lesson Lesson { get; set; }

        [Required]
        public virtual List<Question> Questions { get; set; }

    }
}
