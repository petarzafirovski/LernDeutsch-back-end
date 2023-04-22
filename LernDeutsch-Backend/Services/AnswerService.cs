using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Repositories;
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
            _answerRepository.AddAnswer(answer);
        }

        public void DeleteAnswer(int id)
        {
            var answer = _answerRepository.GetAnswerById(id);
            if (answer != null)
            {
                _answerRepository.DeleteAnswer(answer);
            }
        }

        public List<Answer> GetAllAnswers()
        {
            return _answerRepository.GetAllAnswers();
        }

        public Answer GetAnswerById(int id)
        {
            return _answerRepository.GetAnswerById(id);
        }

        public List<Answer> GetAnswersByQuestionId(int questionId)
        {
            return _answerRepository.GetAnswersByQuestionId(questionId);
        }

        public void UpdateAnswer(Answer answer)
        {
            _answerRepository.UpdateAnswer(answer);
        }
    }

    public interface IAnswerService
    {
        List<Answer> GetAllAnswers();
        Answer GetAnswerById(int id);
        List<Answer> GetAnswersByQuestionId(int questionId);
        void AddAnswer(Answer answer);
        void UpdateAnswer(Answer answer);
        void DeleteAnswer(int id);
    }
}
