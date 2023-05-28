using LernDeutsch_Backend.Dtos.Types;

namespace LernDeutsch_Backend.Dtos
{
    public class BulkQuizCreateDto
    {
        public String Title { get; set; }
        public String? LessonId { get; set; }
        public QuizType QuizType { get; set; }
        public List<QuestionCreateDto> Questions { get; set; }
    }
}
