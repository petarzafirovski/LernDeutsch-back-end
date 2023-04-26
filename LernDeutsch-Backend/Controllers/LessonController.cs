﻿using LernDeutsch_Backend.Dtos;
using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Services;
using LernDeutsch_Backend.Services.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LernDeutsch_Backend.Controllers
{

    [Route("api/lesson")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;


        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_lessonService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id) => Ok(_lessonService.GetById(id));

        [HttpPost]
        public IActionResult Create([FromBody] LessonCreateDto lesson) => Ok(_lessonService.Create(lesson));

        [HttpPut]
        public IActionResult Update([FromBody] Lesson lesson) => Ok(_lessonService.Update(lesson.LessonId, lesson));

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) => Ok(_lessonService.Delete(id));
    }
}
