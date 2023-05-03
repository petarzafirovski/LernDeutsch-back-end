using LernDeutsch_Backend.Dtos;
using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Services.Core;

namespace LernDeutsch_Backend.Services;

public interface IQuestionService : IBaseService<Question>
{
    Question CreateQuestion(QuestionCreateDto dto);
}