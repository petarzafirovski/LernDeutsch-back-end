using LernDeutsch_Backend.Dtos;
using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LernDeutsch_Backend.Controllers
{
    [Route("api/question")]
    [ApiController]
    [Authorize]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_questionService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id) => Ok(_questionService.GetById(id));

        [HttpPost]
        [Authorize(Roles = "Tutor")]
        public IActionResult Create([FromBody] QuestionCreateDto questionDto) => Ok(_questionService.CreateQuestion(questionDto));

        [HttpPut]
        [Authorize(Roles = "Tutor")]
        public IActionResult Update([FromBody] Question question) => Ok(_questionService.Update(question.QuestionId, question));

        [HttpDelete("{id}")]
        [Authorize(Roles = "Tutor")]
        public IActionResult Delete(Guid id) => Ok(_questionService.Delete(id));
    }
}
