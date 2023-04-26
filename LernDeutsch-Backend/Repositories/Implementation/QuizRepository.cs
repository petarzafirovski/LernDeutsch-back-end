using LernDeutsch_Backend.Data;
using LernDeutsch_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace LernDeutsch_Backend.Repositories.Implementation
{
    public class QuizRepository : IQuizRepository
    {
        private readonly ApplicationDatabaseContext _context;

        public QuizRepository(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        public List<Quiz> GetAll() =>
            _context.Quizzes.ToList();

        public Quiz? GetById(Guid id) =>
            _context.Quizzes.Find(id);

        public Quiz Create(Quiz entity) =>
            _context.Quizzes.Add(entity).Entity;

        public Quiz Update(Quiz entity) =>
            _context.Quizzes.Update(entity).Entity;

        public Quiz Delete(Guid id) =>
            _context.Quizzes.Remove(GetById(id)!).Entity;
    }
}
