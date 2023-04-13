using System.ComponentModel.DataAnnotations;

namespace LernDeutsch_Backend.Models
{
    public class Question
    {
        [Key]
        public int questionId { get; set; }
        public string text { get; set; }
        public List<Answer> answers { get; set; }
        public Quiz quiz { get; set; }

        
        
       

    }
}
