using System.ComponentModel.DataAnnotations;

namespace LernDeutsch_Backend.Dtos
{
    public class LessonCreateDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public Guid CourseId { get; set; }
    }
}
