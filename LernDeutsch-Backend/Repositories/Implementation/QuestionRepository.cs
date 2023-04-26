using LernDeutsch_Backend.Data;
using LernDeutsch_Backend.Models;

namespace LernDeutsch_Backend.Repositories.Implementation
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDatabaseContext _context;

        public QuestionRepository(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        public List<Question> GetAll() =>
            _context.Questions.ToList();

        public Question? GetById(Guid id) =>
            _context.Questions.Find(id);

        public Question Create(Question entity)
        {
            var record = _context.Questions.Add(entity).Entity;
            _context.SaveChanges();
            return record;
        }

        public Question Update(Question entity)
        {
            var record = _context.Questions.Update(entity).Entity;
            _context.SaveChanges();
            return record;
        }

        public Question Delete(Guid id) =>
            _context.Questions.Remove(GetById(id)!).Entity;
    }

}
