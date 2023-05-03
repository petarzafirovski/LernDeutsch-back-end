﻿using LernDeutsch_Backend.Dtos;
using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LernDeutsch_Backend.Controllers
{
    [Route("api/quiz")]
    [ApiController]
    [Authorize]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_quizService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id) => Ok(_quizService.GetById(id));

        [HttpPost]
        [Authorize(Roles = "Tutor")]
        public IActionResult Create([FromBody] QuizCreateDto quizDto) => Ok(_quizService.CreateQuiz(quizDto));

        [HttpPut]
        [Authorize(Roles = "Tutor")]
        public IActionResult Update([FromBody] Quiz quiz) => Ok(_quizService.Update(quiz.QuizId, quiz));

        [HttpDelete("{id}")]
        [Authorize(Roles = "Tutor")]
        public IActionResult Delete(Guid id) => Ok(_quizService.Delete(id));

    }
}