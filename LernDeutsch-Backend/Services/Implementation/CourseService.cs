using LernDeutsch_Backend.Dtos;
using LernDeutsch_Backend.Dtos.Types;
using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Repositories;
using LernDeutsch_Backend.Services.Identity.SubUsers;
using LernDeutsch_Backend.Services.Identity.SubUsers.Implementation;

namespace LernDeutsch_Backend.Services.Implementation
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ITutorService _tutorService;
        private readonly Lazy<ILessonService> _lessonService;
        private readonly IQuizService _quizService;

        public CourseService(ICourseRepository courseRepository, ITutorService tutorService, IQuizService quizService, Lazy<ILessonService> lessonService)
        {
            _courseRepository = courseRepository;
            _tutorService = tutorService;
            _quizService = quizService;
            _lessonService = lessonService;
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
            var tutor = _tutorService.GetUser(dto.TutorId.ToString());
            if (tutor == null)
                throw new Exception("Tutor cannot be null while creating a course");

            Course course = _courseRepository.Create(new Course
            {
                Length = dto.Length,
                Name = dto.Name,
                Level = dto.Level,
                Price = dto.Price,
                Tutor = tutor
            });

            Lesson lesson = _lessonService.Value.Create(new Lesson()
            {
                Content = "Final Lesson",
                Course = course,
                LessonType = LessonType.FinalLesson,
                Title = "Final Quiz"
            });

            dto.FinalQuiz.LessonId = lesson.LessonId.ToString();
            _quizService.BulkCreateQuiz(dto.FinalQuiz);

            return course;
        }

        public Dictionary<string, List<Course>> GetCoursesByLevels()
        {
            return _courseRepository.GetAll().GroupBy(x => x.Level).ToDictionary(x => x.Key, x => x.ToList());
        }
    }
}
