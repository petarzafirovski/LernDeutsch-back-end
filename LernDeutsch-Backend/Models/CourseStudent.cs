using System.ComponentModel.DataAnnotations;
using LernDeutsch_Backend.Models.Identity;

namespace LernDeutsch_Backend.Models
{
    public class CourseStudent
    {
        [Key]
        public Guid Id { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }

    }
}
