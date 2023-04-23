using LernDeutsch_Backend.Models;

namespace LernDeutsch_Backend.Services;

public interface IQuestionService
{
    List<Question> GetAllQuestions();
    Question? GetQuestionById(Guid id);
    void AddQuestion(Question question);
    void UpdateQuestion(Guid id, Question question);
    void DeleteQuestion(Guid id);
}