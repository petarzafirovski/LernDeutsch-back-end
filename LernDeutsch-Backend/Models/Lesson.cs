using System.ComponentModel.DataAnnotations;

namespace LernDeutsch_Backend.Models
{
    public class Lesson
    {
        [Key]
        public int lessonId { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public List<Quiz> quizzes { get; set; }
        public Course course { get; set; }

        
    }
}
