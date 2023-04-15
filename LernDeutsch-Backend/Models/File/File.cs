using System.ComponentModel.DataAnnotations;

namespace LernDeutsch_Backend.Models.File
{
    public class File
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        // The Guid of the Course or Lesson that the File relates to
        [Required]
        public Guid ReferenceId { get; set; }
        [Required]
        public string LocationUrl { get; set; }
        [Required]
        public int Width { get; set; }
        [Required]
        public int Height { get; set; }


    }
}
