using System.ComponentModel.DataAnnotations;

namespace LernDeutsch_Backend.Dtos
{
    public class QuizCreateDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int LessonId { get; set; }
        public List<QuestionCreateDto> Questions { get; set; }
    }
}
