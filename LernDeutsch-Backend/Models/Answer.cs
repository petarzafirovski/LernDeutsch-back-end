using System.ComponentModel.DataAnnotations;

namespace LernDeutsch_Backend.Models
{
    public class Answer
    {
        [Key]
        public int answerId { get; set; }
        public string text { get; set; }
        public bool isCorrect { get; set; }
        public Question question { get; set; }

      
      
    }

}
