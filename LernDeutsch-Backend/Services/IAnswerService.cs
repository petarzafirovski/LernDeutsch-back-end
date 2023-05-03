using LernDeutsch_Backend.Dtos.LernDeutsch_Backend.Models.Dtos;
using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Services.Core;

namespace LernDeutsch_Backend.Services;

public interface IAnswerService : IBaseService<Answer>
{
    Answer CreateAnswer(AnswerCreateDto answerCreateDto);
    List<Answer> GetAnswersByQuestionId(Guid questionId);
}