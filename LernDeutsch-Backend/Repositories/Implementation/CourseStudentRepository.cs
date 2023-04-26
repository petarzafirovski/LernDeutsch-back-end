using LernDeutsch_Backend.Data;
using LernDeutsch_Backend.Models;

namespace LernDeutsch_Backend.Repositories.Implementation
{
    public class CourseStudentRepository : ICourseStudentRepository
    {
        private readonly ApplicationDatabaseContext _context;

        public CourseStudentRepository(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        public List<CourseStudent> GetAll() =>
            _context.CourseStudents.ToList();

        public CourseStudent? GetById(Guid id) =>
            _context.CourseStudents.Find(id);

        public CourseStudent Create(CourseStudent entity)
        {
            var record = _context.CourseStudents.Add(entity).Entity;
            _context.SaveChanges();
            return record;
        }
        public CourseStudent Update(CourseStudent entity)
        {
            var record = _context.CourseStudents.Update(entity).Entity;
            _context.SaveChanges();
            return record;
        }
        public CourseStudent Delete(Guid id) =>
            _context.CourseStudents.Remove(GetById(id)!).Entity;
    }
}
