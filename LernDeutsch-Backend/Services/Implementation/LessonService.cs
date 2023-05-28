using LernDeutsch_Backend.Dtos;
using LernDeutsch_Backend.Dtos.Types;
using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Repositories;

namespace LernDeutsch_Backend.Services.Implementation
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly ICourseService _courseService;
        private readonly IQuizService _quizService;

        public LessonService(ILessonRepository lessonRepository, ICourseService courseService, IQuizService quizService)
        {
            _lessonRepository = lessonRepository;
            _courseService = courseService;
            _quizService = quizService;
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
            var course = _courseService.GetById(dto.CourseId);
            if (course == null)
                throw new Exception("Course cannot be null while creating a lesson");
            return _lessonRepository.Create(new Lesson
            {
                Content = dto.Content,
                Course = course,
                Title = dto.Title
            });
        }

        public Quiz FindFinalQuizByCourse(Course course)
        {
            var finalLesson = _lessonRepository.FindByCourseAndType(course, LessonType.FinalLesson);
            Quiz quiz = finalLesson.Quizzes.First(q => q.QuizType == QuizType.FinalQuiz);
            return _quizService.GetById(quiz.QuizId);
        }
    }
}
