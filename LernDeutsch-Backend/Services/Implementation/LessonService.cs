using LernDeutsch_Backend.Dtos;
using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Repositories;

namespace LernDeutsch_Backend.Services.Implementation
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly ICourseService _courseService;

        public LessonService(ILessonRepository lessonRepository, ICourseService courseService)
        {
            _lessonRepository = lessonRepository;
            _courseService = courseService;
        }

        public Lesson Create(Lesson entity) =>
            _lessonRepository.Create(entity);

        public Lesson Update(Guid id, Lesson entity)
        {
            // TODO: Finish implementing after mappers
            throw new NotImplementedException();
        }

        public Lesson Delete(Guid id) =>
            _lessonRepository.Delete(id);

        public Lesson? GetById(Guid id) =>
            _lessonRepository.GetById(id);

        public List<Lesson> GetAll() =>
            _lessonRepository.GetAll();

        public Lesson Create(LessonCreateDto dto)
        {
            return _lessonRepository.Create(new Lesson
            {
                Content = dto.Content,
                Course = _courseService.GetById(dto.CourseId),
                Title = dto.Title
            });
        }
    }
}
