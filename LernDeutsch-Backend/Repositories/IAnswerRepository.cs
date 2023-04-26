using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Repositories.Core;

namespace LernDeutsch_Backend.Repositories;

public interface IAnswerRepository : IBaseRepository<Answer>
{
    List<Answer> GetAnswersByQuestionId(int questionId);
}