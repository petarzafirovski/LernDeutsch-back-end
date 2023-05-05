using LernDeutsch_Backend.Dtos;
using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Repositories;
using LernDeutsch_Backend.Services.Identity.SubUsers;

namespace LernDeutsch_Backend.Services.Implementation
{
    public class CourseStudentService : ICourseStudentService
    {
        private readonly ICourseStudentRepository _courseStudentRepository;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;

        public CourseStudentService(ICourseStudentRepository courseStudentRepository, ICourseService courseService, IStudentService studentService)
        {
            _courseStudentRepository = courseStudentRepository;
            _courseService = courseService;
            _studentService = studentService;
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

        public CourseStudent EnrollStudent(CourseStudentCreateDto dto)
        {
            var course = _courseService.GetById(dto.CourseId);
            var student = _studentService.GetUser(dto.StudentId.ToString());

            if (course == null || student == null)
                throw new Exception("Cannot enroll student to course");

            CourseStudent studentCourse = new()
            {
                Course = course,
                Student = student
            };
            return _courseStudentRepository.Create(studentCourse);
        }
    }
}
