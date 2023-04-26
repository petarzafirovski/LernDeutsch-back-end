using LernDeutsch_Backend.Dtos;
using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace LernDeutsch_Backend.Controllers
{

    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;


        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_courseService.GetAll());

        [HttpGet("courses-by-levels")]
        public IActionResult GetCoursesByLevels() =>  Ok(_courseService.GetCoursesByLevels());

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id) => Ok(_courseService.GetById(id));

        [HttpPost]
        public IActionResult Create([FromBody] CourseCreateDto course) => Ok(_courseService.Create(course));

        [HttpPut]
        public IActionResult Update([FromBody] Course course) => Ok(_courseService.Update(course.CourseId, course));

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) => Ok(_courseService.Delete(id));
    }
}
