using LernDeutsch_Backend.Dtos;
using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Models.Identity;
using LernDeutsch_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LernDeutsch_Backend.Controllers
{

    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly ICourseStudentService _courseStudentService;

        public CourseController(ICourseService courseService, ICourseStudentService courseStudentService)
        {
            _courseService = courseService;
            _courseStudentService = courseStudentService;
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
        [Authorize(Roles = UserRoles.Tutor)]
        public IActionResult Update([FromBody] Course course) => Ok(_courseService.Update(course.CourseId, course));

        [HttpPost("remove-student/{id}")]
        [Authorize(Roles = UserRoles.Tutor)]
        public IActionResult RemoveStudent(Guid Id) => Ok(_courseStudentService.Delete(Id));

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Tutor)]
        public IActionResult Delete(Guid id) => Ok(_courseService.Delete(id));
    }
}
