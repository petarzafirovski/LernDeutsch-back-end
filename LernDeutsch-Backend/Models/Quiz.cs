using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace LernDeutsch_Backend.Models
{
    public class Quiz
    {
        [Key]
        public int quizId { get; set; }
        public string title { get; set; }
        List<Question> questions { get; set; }
        Lesson lesson { get; set; }

       
       


    }
}
