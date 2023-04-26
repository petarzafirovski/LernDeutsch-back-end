using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Repositories;

namespace LernDeutsch_Backend.Services.Implementation
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;

        public QuizService(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
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
    }
}
