using LernDeutsch_Backend.Dtos;
using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Repositories;

namespace LernDeutsch_Backend.Services.Implementation
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;
        private readonly ILessonRepository _lessonRepository;

        public QuizService(IQuizRepository quizRepository, ILessonRepository lessonRepository)
        {
            _quizRepository = quizRepository;
            _lessonRepository = lessonRepository;
        }

        public Quiz Create(Quiz entity) =>
            _quizRepository.Create(entity);

        public Quiz Update(Guid id, Quiz entity)
        {
            // TODO: Finish implementing after mappers
            throw new NotImplementedException();
        }

        public Quiz Delete(Guid id) =>
            _quizRepository.Delete(id);

        public Quiz? GetById(Guid id) =>
            _quizRepository.GetById(id);

        public List<Quiz> GetAll() =>
            _quizRepository.GetAll();

        public Quiz CreateQuiz(QuizCreateDto quizCreateDto)
        {
            var lesson = _lessonRepository.GetById(new Guid(quizCreateDto.LessonId));
            if (lesson == null)
                throw new Exception("Lesson could not be null.");

            return _quizRepository.Create(new Quiz
            {
                Title = quizCreateDto.Title,
                Lesson = lesson
            });
        }
    }
}
