using System.ComponentModel.DataAnnotations;

namespace LernDeutsch_Backend.Dtos
{
    namespace LernDeutsch_Backend.Models.Dtos
    {
        public class AnswerCreateDto
        {
            [Required]
            public string Text { get; set; }
            [Required]
            public bool IsCorrect { get; set; }
            [Required]
            public Guid QuestionId { get; set; }
        }
    }
}
