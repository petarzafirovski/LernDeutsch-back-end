using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Repositories;

namespace LernDeutsch_Backend.Services.Implementation
{
    public class CourseStudentService : ICourseStudentService
    {
        private readonly ICourseStudentRepository _courseStudentRepository;

        public CourseStudentService(ICourseStudentRepository courseStudentRepository)
        {
            _courseStudentRepository = courseStudentRepository;
        }

        public CourseStudent Create(CourseStudent entity) =>
            _courseStudentRepository.Create(entity);

        public CourseStudent Update(Guid id, CourseStudent entity)
        {
            // TODO: Finish implementing after mappers
            throw new NotImplementedException();
        }

        public CourseStudent Delete(Guid id) =>
            _courseStudentRepository.Delete(id);

        public CourseStudent? GetById(Guid id) =>
            _courseStudentRepository.GetById(id);

        public List<CourseStudent> GetAll() =>
            _courseStudentRepository.GetAll();
    }
}
