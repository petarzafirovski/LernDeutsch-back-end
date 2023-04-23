using LernDeutsch_Backend.Models;

namespace LernDeutsch_Backend.Services;

public interface IAnswerService
{
    List<Answer> GetAllAnswers();
    Answer? GetAnswerById(Guid id);
    List<Answer> GetAnswersByQuestionId(int questionId);
    void AddAnswer(Answer answer);
    void UpdateAnswer(Answer answer);
    void DeleteAnswer(Guid id);
}