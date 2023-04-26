using LernDeutsch_Backend.Dtos;
using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Repositories;
using LernDeutsch_Backend.Services.Identity;

namespace LernDeutsch_Backend.Services.Implementation
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUserService _userService;

        public CourseService(ICourseRepository courseRepository, IUserService userService)
        {
            _courseRepository = courseRepository;
            _userService = userService;
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

        public Course Create(CourseCreateDto dto)
        {
            return _courseRepository.Create(new Course
            {
                Length = dto.Length,
                Name = dto.Name,
                Level = dto.Level,
                Price = dto.Price
            });
        }
    }
}
