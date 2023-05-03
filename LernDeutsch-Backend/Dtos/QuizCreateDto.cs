using System.ComponentModel.DataAnnotations;

namespace LernDeutsch_Backend.Dtos
{
    public class QuizCreateDto
    {
        [Required]
        public string Title { get; set; } = string.Empty!;
        [Required]
        public string LessonId { get; set; } = string.Empty!;
    }
}
