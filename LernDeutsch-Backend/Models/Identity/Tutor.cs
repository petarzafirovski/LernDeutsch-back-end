using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LernDeutsch_Backend.Models.Identity
{
    public class Tutor
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string BaseUserId { get; set; }

        [ForeignKey("BaseUserId")]
        [InverseProperty("Tutor")]
        public virtual BaseUser BaseUser { get; set; } = null!;
        public virtual List<Course> Courses { get; set; } = new List<Course>();
    }
}
