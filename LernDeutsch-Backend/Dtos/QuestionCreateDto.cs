using LernDeutsch_Backend.Dtos.LernDeutsch_Backend.Models.Dtos;
using System.ComponentModel.DataAnnotations;

namespace LernDeutsch_Backend.Dtos
{
    public class QuestionCreateDto
    {
        [Required]
        public string Text { get; set; }
        public string? QuizId { get; set; }
        public List<AnswerCreateDto> Answers { get; set; }
    }
}