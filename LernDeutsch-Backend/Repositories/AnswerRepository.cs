using LernDeutsch_Backend.Data;
using LernDeutsch_Backend.Models;

namespace LernDeutsch_Backend.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly ApplicationDatabaseContext _context;

        public AnswerRepository(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        public void AddAnswer(Answer answer)
        {
            _context.Answers.Add(answer);
        }

        public void DeleteAnswer(Answer answer)
        {
            _context.Answers.Remove(answer);
        }

        public List<Answer> GetAllAnswers()
        {
            return _context.Answers.ToList();
        }

        public Answer GetAnswerById(int id)
        {
            return _context.Answers.Where(a => a.AnswerId == id).FirstOrDefault();
        }

        public List<Answer> GetAnswersByQuestionId(int questionId)
        {
            return _context.Answers.Where(a => a.Question.QuestionId == questionId).ToList();
        }

        public void UpdateAnswer(Answer answer)
        {
            _context.Answers.Update(answer);
        }
    }

    public interface IAnswerRepository
    {
        List<Answer> GetAllAnswers();
        Answer GetAnswerById(int id);
        List<Answer> GetAnswersByQuestionId(int questionId);
        void AddAnswer(Answer answer);
        void UpdateAnswer(Answer answer);
        void DeleteAnswer(Answer answer);
    }
}
