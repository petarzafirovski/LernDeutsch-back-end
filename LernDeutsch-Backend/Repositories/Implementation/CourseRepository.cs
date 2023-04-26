using LernDeutsch_Backend.Data;
using LernDeutsch_Backend.Models;

namespace LernDeutsch_Backend.Repositories.Implementation
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDatabaseContext _context;

        public CourseRepository(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        public List<Course> GetAll() =>
            _context.Courses.ToList();

        public Course? GetById(Guid id) =>
            _context.Courses.Find(id);

        public Course Create(Course entity) =>
            _context.Courses.Add(entity).Entity;

        public Course Update(Course entity) =>
            _context.Courses.Update(entity).Entity;

        public Course Delete(Guid id) =>
            _context.Courses.Remove(GetById(id)!).Entity;
    }
}
