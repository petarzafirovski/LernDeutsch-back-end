using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Repositories;

namespace LernDeutsch_Backend.Services.Implementation
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public Course Create(Course entity) =>
            _courseRepository.Create(entity);

        public Course Update(Guid id, Course entity)
        {
            // TODO: Finish implementing after mappers
            throw new NotImplementedException();
        }

        public Course Delete(Guid id) =>
            _courseRepository.Delete(id);

        public Course? GetById(Guid id) =>
            _courseRepository.GetById(id);

        public List<Course> GetAll() =>
            _courseRepository.GetAll();
    }
}
