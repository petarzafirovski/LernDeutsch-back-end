using LernDeutsch_Backend.Data;
using LernDeutsch_Backend.Models;

namespace LernDeutsch_Backend.Repositories.Implementation
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly ApplicationDatabaseContext _context;

        public AnswerRepository(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        public List<Answer> GetAnswersByQuestionId(int questionId) =>
            _context.Answers.Where(a => a.Question.QuestionId == questionId).ToList();

        public List<Answer> GetAll() =>
            _context.Answers.ToList();

        public Answer? GetById(Guid id) =>
            _context.Answers.Find(id);

        public Answer Create(Answer entity)
        {
            var record = _context.Answers.Add(entity).Entity;
            _context.SaveChanges();
            return record;
        }

        public Answer Update(Answer entity)
        {
            var record = _context.Answers.Update(entity).Entity;
            _context.SaveChanges();
            return record;
        }

        public Answer Delete(Guid id) =>
            _context.Answers.Remove(GetById(id)!).Entity;
    }

}
