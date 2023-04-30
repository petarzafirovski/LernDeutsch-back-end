using System.ComponentModel.DataAnnotations;

namespace LernDeutsch_Backend.Dtos
{
    public class CourseStudentCreateDto
    {
        [Required]
        public Guid CourseId { get; set; }
        [Required]
        public Guid StudentId { get; set; }
    }

}
