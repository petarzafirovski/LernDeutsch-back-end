using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Repositories.Implementation;
using LernDeutsch_Backend.Services.Implementation;

namespace LernDeutsch_Backend.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly QuestionRepositoryRepository _questionRepositoryRepository;

        public QuestionService(QuestionRepositoryRepository questionRepositoryRepository)
        {
            _questionRepositoryRepository = questionRepositoryRepository;
        }


        public void AddQuestion(Question question)
        {
            _questionRepositoryRepository.Create(question);
        }

        public void DeleteQuestion(Guid id)
        {
            _questionRepositoryRepository.Delete(id);
        }

        public List<Question> GetAllQuestions()
        {
            return _questionRepositoryRepository.GetAll();
        }

        public Question? GetQuestionById(Guid id)
        {
            return _questionRepositoryRepository.GetById(id);
        }

        public void UpdateQuestion(Guid id, Question question)
        {
            var existingQuestion = _questionRepositoryRepository.GetById(id);
            if (existingQuestion == null)
            {
                throw new ArgumentException("Question not found");
            }

            existingQuestion.Text = question.Text;
            existingQuestion.Quiz = question.Quiz;
            existingQuestion.Answers = question.Answers;

            _questionRepositoryRepository.Update(existingQuestion);
        }
    }
}
