using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Repositories.Implementation;

namespace LernDeutsch_Backend.Services.Implementation
{
    public class QuestionService : IQuestionService
    {
        private readonly QuestionRepository _questionRepository;

        public QuestionService(QuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }


        public void AddQuestion(Question question)
        {
            _questionRepository.Create(question);
        }

        public void DeleteQuestion(Guid id)
        {
            _questionRepository.Delete(id);
        }

        public List<Question> GetAllQuestions()
        {
            return _questionRepository.GetAll();
        }

        public Question? GetQuestionById(Guid id)
        {
            return _questionRepository.GetById(id);
        }

        public void UpdateQuestion(Guid id, Question question)
        {
            var existingQuestion = _questionRepository.GetById(id);
            if (existingQuestion == null)
            {
                throw new ArgumentException("Question not found");
            }

            existingQuestion.Text = question.Text;
            existingQuestion.Quiz = question.Quiz;
            existingQuestion.Answers = question.Answers;

            _questionRepository.Update(existingQuestion);
        }
    }
}
