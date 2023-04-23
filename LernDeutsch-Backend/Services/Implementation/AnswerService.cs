using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Repositories;
using LernDeutsch_Backend.Repositories.Implementation;
using System.Collections.Generic;

namespace LernDeutsch_Backend.Services.Implementation
{
    public class AnswerService : IAnswerService
    {
        private readonly AnswerRepository _answerRepository;

        public AnswerService(AnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public Answer Create(Answer answer) =>
            _answerRepository.Create(answer);

        public Answer Delete(Guid id) =>
            _answerRepository.Delete(id);

        public List<Answer> GetAll() =>
            _answerRepository.GetAll();

        public Answer? GetById(Guid id) => 
            _answerRepository.GetById(id);

        public List<Answer> GetAnswersByQuestionId(int questionId) => 
            _answerRepository.GetAnswersByQuestionId(questionId);

        public Answer Update(Guid id, Answer answer)
        {
            var existingAnswer = _answerRepository.GetById(id);
            if (existingAnswer == null)
            {
                throw new ArgumentException("Answer not found");
            }

            existingAnswer.Text = answer.Text;
            existingAnswer.AnswerId = answer.AnswerId;
            existingAnswer.Question = answer.Question;
            existingAnswer.IsCorrect = answer.IsCorrect;

            _answerRepository.Update(existingAnswer);
            return _answerRepository.Update(answer);
        }
    }
}
