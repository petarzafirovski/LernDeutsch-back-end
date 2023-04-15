using System.ComponentModel.DataAnnotations;

namespace LernDeutsch_Backend.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        [Required]
        public string? Text { get; set; }
        [Required]
        public List<Answer>? Answers { get; set; }
        [Required]
        public Quiz Quiz { get; set; }
    }
}
