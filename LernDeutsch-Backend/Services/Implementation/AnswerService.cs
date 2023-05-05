using LernDeutsch_Backend.Dtos.LernDeutsch_Backend.Models.Dtos;
using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Repositories;

namespace LernDeutsch_Backend.Services.Implementation
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IQuestionRepository _quiestionRepository;

        public AnswerService(IAnswerRepository answerRepository, IQuestionRepository questionRepository)
        {
            _answerRepository = answerRepository;
            _quiestionRepository = questionRepository;
        }

        public Answer Create(Answer answer) =>
            _answerRepository.Create(answer);

        public Answer Delete(Guid id) =>
            _answerRepository.Delete(id);

        public List<Answer> GetAll() =>
            _answerRepository.GetAll();

        public Answer? GetById(Guid id) => 
            _answerRepository.GetById(id);

        public List<Answer> GetAnswersByQuestionId(Guid questionId) => 
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

        public Answer CreateAnswer(AnswerCreateDto answerCreateDto)
        {
            var question = _quiestionRepository.GetById(answerCreateDto.QuestionId);
            if (question == null)
                throw new Exception("Question cannot be null while creating an answer.");

            return _answerRepository.Create(new Answer
            {
                IsCorrect = answerCreateDto.IsCorrect,
                Text = answerCreateDto.Text,
                Question = question
            }); 
        }
    }
}
