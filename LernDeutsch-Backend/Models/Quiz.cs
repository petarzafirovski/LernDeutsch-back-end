using System.ComponentModel.DataAnnotations;
using System.Reflection;
using LernDeutsch_Backend.Dtos.Types;

namespace LernDeutsch_Backend.Models
{
    public class Quiz
    {
        [Key]
        public Guid QuizId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public Lesson Lesson { get; set; }

        public QuizType QuizType { get; set; }

        [Required]
        public virtual List<Question> Questions { get; set; }

    }
}
