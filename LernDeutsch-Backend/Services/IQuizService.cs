using LernDeutsch_Backend.Dtos;
using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Services.Core;

namespace LernDeutsch_Backend.Services
{
    public interface IQuizService : IBaseService<Quiz>
    {
        Quiz CreateQuiz(QuizCreateDto quizCreateDto);
        Quiz BulkCreateQuiz(BulkQuizCreateDto dto);
        Quiz GetLevelDeterminationQuiz();
    }
}
