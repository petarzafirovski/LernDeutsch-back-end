using LernDeutsch_Backend.Dtos.LernDeutsch_Backend.Models.Dtos;
using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LernDeutsch_Backend.Controllers
{
    [Route("api/answers")]
    [ApiController]
    [Authorize]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_answerService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id) => Ok(_answerService.GetById(id));

        [HttpPost]
        [Authorize(Roles = "Tutor")]
        public IActionResult Create([FromBody] AnswerCreateDto answerDto) => Ok(_answerService.CreateAnswer(answerDto));

        [HttpPut]
        [Authorize(Roles = "Tutor")]
        public IActionResult Update([FromBody] Answer answer) => Ok(_answerService.Update(answer.AnswerId, answer));

        [HttpDelete("{id}")]
        [Authorize(Roles = "Tutor")]
        public IActionResult Delete(Guid id) => Ok(_answerService.Delete(id));
    }
}
