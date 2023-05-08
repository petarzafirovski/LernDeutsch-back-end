using LernDeutsch_Backend.Dtos;
using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Models.Identity;
using LernDeutsch_Backend.Services.Core;

namespace LernDeutsch_Backend.Services
{
    public interface ICourseStudentService : IBaseService<CourseStudent>
    {
        CourseStudent EnrollStudent(Course course, Student student);
    }
}
