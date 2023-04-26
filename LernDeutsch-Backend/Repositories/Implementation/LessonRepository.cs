using LernDeutsch_Backend.Data;
using LernDeutsch_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace LernDeutsch_Backend.Repositories.Implementation
{
    public class LessonRepository : ILessonRepository
    {
        private readonly ApplicationDatabaseContext _context;

        public LessonRepository(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        public List<Lesson> GetAll() =>
            _context.Lessons.ToList();

        public Lesson? GetById(Guid id) =>
            _context.Lessons.Find(id);

        public Lesson Create(Lesson entity)
        {
            var record = _context.Lessons.Add(entity).Entity;
            _context.SaveChanges();
            return record;
        }

        public Lesson Update(Lesson entity)
        {
            var record = _context.Lessons.Update(entity).Entity;
            _context.SaveChanges();
            return record;
        }

        public Lesson Delete(Guid id) =>
            _context.Lessons.Remove(GetById(id)!).Entity;
    }
}
