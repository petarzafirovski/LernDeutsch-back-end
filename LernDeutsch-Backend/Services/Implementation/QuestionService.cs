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


        public Question Create(Question question) => 
            _questionRepository.Create(question);

        public Question Delete(Guid id) => 
            _questionRepository.Delete(id);

        public List<Question> GetAll() => 
            _questionRepository.GetAll();

        public Question? GetById(Guid id) => 
            _questionRepository.GetById(id);

        public Question Update(Guid id, Question question)
        {
            var existingQuestion = _questionRepository.GetById(id);
            if (existingQuestion == null)
            {
                throw new ArgumentException("Question not found");
            }

            existingQuestion.Text = question.Text;
            existingQuestion.Quiz = question.Quiz;
            existingQuestion.Answers = question.Answers;

            return _questionRepository.Update(existingQuestion);
        }
    }
}
