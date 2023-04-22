using LernDeutsch_Backend.Data;
using LernDeutsch_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace LernDeutsch_Backend.Repositories
{
    public class QuizRepository : IQuiz
    {
        private  ApplicationDatabaseContext _context;

        public QuizRepository(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        public void AddQuiz(Quiz quiz)
        {
            _context.Quizzes.Add(quiz);
        }

        public void DeleteQuiz(Quiz quiz)
        {
            _context.Quizzes.Remove(quiz);
        }

        public List<Quiz> GetAllQuizzes()
        {
            return _context.Quizzes.ToList();
        }

        public Quiz GetQuizById(int id)
        {
            return _context.Quizzes.Where(q => q.QuizId == id).FirstOrDefault();
        }

        public void UpdateQuiz(Quiz quiz)
        {
             _context.Quizzes.Update(quiz);
        }
    }

    public interface IQuiz 
    {
        List<Quiz> GetAllQuizzes();
        Quiz GetQuizById(int id);
        void AddQuiz(Quiz quiz);
        void UpdateQuiz(Quiz quiz);
        void DeleteQuiz(Quiz quizzes);
    }

}
