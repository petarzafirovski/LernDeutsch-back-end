using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Repositories;

namespace LernDeutsch_Backend.Services
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
            _questionRepository.AddQuestion(question);
        }

        public void DeleteQuestion(int id)
        {
            var existingQuestion = _questionRepository.GetQuestionById(id);
            if (existingQuestion == null)
            {
                throw new ArgumentException("Question not found");
            }

            _questionRepository.DeleteQuestion(existingQuestion);
        }

        public List<Question> GetAllQuestions()
        {
            return _questionRepository.GetAllQuestions();
        }

        public Question GetQuestionById(int id)
        {
            return _questionRepository.GetQuestionById(id);
        }

        public void UpdateQuestion(int id, Question question)
        {
            var existingQuestion = _questionRepository.GetQuestionById(id);
            if (existingQuestion == null)
            {
                throw new ArgumentException("Question not found");
            }

            existingQuestion.Text = question.Text;
            existingQuestion.Quiz = question.Quiz;
            existingQuestion.Answers = question.Answers;

            _questionRepository.UpdateQuestion(existingQuestion);
        }
    }

    public interface IQuestionService 
    {
        List<Question> GetAllQuestions();
        Question GetQuestionById(int id);
        void AddQuestion(Question question);
        void UpdateQuestion(int id, Question question);
        void DeleteQuestion(int id);
    }

}
