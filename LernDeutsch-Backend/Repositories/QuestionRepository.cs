using LernDeutsch_Backend.Data;
using LernDeutsch_Backend.Models;

namespace LernDeutsch_Backend.Repositories
{
    public class QuestionRepository : IQuestion
    {
        private ApplicationDatabaseContext _context;

        public QuestionRepository(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        public void AddQuestion(Question question)
        {
            _context.Questions.Add(question);
        }

        public void DeleteQuestion(Question question)
        {
            _context.Questions.Remove(question);
        }

        public List<Question> GetAllQuestions()
        {
            return _context.Questions.ToList();
        }

        public Question GetQuestionById(int id)
        {
            return _context.Questions.Where(q => q.QuestionId == id).FirstOrDefault();
        }

        public void UpdateQuestion(Question question)
        {
            _context.Questions.Update(question);
        }
    }

    public interface IQuestion
    {
        List<Question> GetAllQuestions();
        Question GetQuestionById(int id);
        void AddQuestion(Question question);
        void UpdateQuestion(Question question);
        void DeleteQuestion(Question question);
        
        
    }
}
