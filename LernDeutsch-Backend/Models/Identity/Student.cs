using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LernDeutsch_Backend.Models.Identity
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string BaseUserId { get; set; }

        [ForeignKey("BaseUserId")]
        [InverseProperty("Student")]
        public virtual BaseUser BaseUser { get; set; } = null!;
        public virtual List<CourseStudent> Courses { get; set; } = new List<CourseStudent> ();
    }
}
