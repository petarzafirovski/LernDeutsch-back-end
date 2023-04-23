using LernDeutsch_Backend.Data;
using LernDeutsch_Backend.Models;

namespace LernDeutsch_Backend.Repositories.Implementation
{
    public class QuestionRepositoryRepository : IQuestionRepository
    {
        private readonly ApplicationDatabaseContext _context;

        public QuestionRepositoryRepository(ApplicationDatabaseContext context)
        {
            _context = context;
        }
        
        public List<Question> GetAll() =>
            _context.Questions.ToList();

        public Question? GetById(Guid id) =>
            _context.Questions.Find(id);

        public Question Create(Question entity) =>
            _context.Questions.Add(entity).Entity;

        public Question Update(Question entity) =>
            _context.Questions.Update(entity).Entity;

        public Question Delete(Guid id) =>
            _context.Questions.Remove(GetById(id)!).Entity;
}

}
