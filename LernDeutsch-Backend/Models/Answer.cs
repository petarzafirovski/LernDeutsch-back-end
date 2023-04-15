using System.ComponentModel.DataAnnotations;

namespace LernDeutsch_Backend.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public Question Question { get; set; }

      
      
    }

}
