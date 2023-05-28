using LernDeutsch_Backend.Dtos.Types;
using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Repositories.Core;

namespace LernDeutsch_Backend.Repositories
{
    public interface ILessonRepository : IBaseRepository<Lesson>
    {
        Lesson FindByCourseAndType(Course course, LessonType type);

    }
}
