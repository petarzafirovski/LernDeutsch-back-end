using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Repositories.Implementation;
using LernDeutsch_Backend.Services.Implementation;
using System.Collections.Generic;

namespace LernDeutsch_Backend.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly AnswerRepository _answerRepository;

        public AnswerService(AnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public void AddAnswer(Answer answer)
        {
            _answerRepository.Create(answer);
        }

        public void DeleteAnswer(Guid id)
        {
            _answerRepository.Delete(id);
        }

        public List<Answer> GetAllAnswers()
        {
            return _answerRepository.GetAll();
        }

        public Answer? GetAnswerById(Guid id)
        {
            return _answerRepository.GetById(id);
        }

        public List<Answer> GetAnswersByQuestionId(int questionId)
        {
            return _answerRepository.GetAnswersByQuestionId(questionId);
        }

        public void UpdateAnswer(Answer answer)
        {
            _answerRepository.Update(answer);
        }
    }
}
