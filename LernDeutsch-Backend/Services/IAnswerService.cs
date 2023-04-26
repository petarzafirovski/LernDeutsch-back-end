using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Services.Core;

namespace LernDeutsch_Backend.Services;

public interface IAnswerService : IBaseService<Answer>
{
    List<Answer> GetAnswersByQuestionId(int questionId);
}