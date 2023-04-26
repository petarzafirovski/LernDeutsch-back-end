using System.ComponentModel.DataAnnotations;

namespace LernDeutsch_Backend.Dtos
{
    public class CourseCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Level { get; set; }
        public int Length { get; set; }
        public double Price { get; set; }
        [Required]
        public Guid TutorId { get; set; }
    }
}
