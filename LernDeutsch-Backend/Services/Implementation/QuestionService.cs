using LernDeutsch_Backend.Dtos;
using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Repositories;
using LernDeutsch_Backend.Repositories.Implementation;

namespace LernDeutsch_Backend.Services.Implementation
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuizRepository _quizRepository;
        private readonly IAnswerService _answerService;

        public QuestionService(IQuestionRepository questionRepository, IQuizRepository quizRepository, IAnswerService answerService)
        {
            _questionRepository = questionRepository;
            _quizRepository = quizRepository;
            _answerService = answerService;
        }


        public Question Create(Question question) =>
            _questionRepository.Create(question);

        public Question CreateQuestion(QuestionCreateDto dto)
        {
            var quiz = _quizRepository.GetById(new Guid(dto.QuizId));
            if (quiz == null)
                throw new Exception("Quiz cannot be null.");
            Question question = _questionRepository.Create(new Question
            {
                Text = dto.Text,
                Quiz = quiz
            });

            dto.Answers.ForEach(answer =>
            {
                answer.QuestionId = question.QuestionId;
                _answerService.CreateAnswer(answer);
            });

            return question;
        }

        public Question Delete(Guid id) =>
            _questionRepository.Delete(id);

        public List<Question> GetAll() =>
            _questionRepository.GetAll();

        public Question? GetById(Guid id) =>
            _questionRepository.GetById(id);

        public Question Update(Guid id, Question question)
        {
            var existingQuestion = _questionRepository.GetById(id);
            if (existingQuestion == null)
            {
                throw new ArgumentException("Question not found");
            }

            existingQuestion.Text = question.Text;
            existingQuestion.Quiz = question.Quiz;
            existingQuestion.Answers = question.Answers;

            return _questionRepository.Update(existingQuestion);
        }
    }
}
