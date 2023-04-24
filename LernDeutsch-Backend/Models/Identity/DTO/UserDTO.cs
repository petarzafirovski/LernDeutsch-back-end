using System.ComponentModel.DataAnnotations;

namespace LernDeutsch_Backend.Models.Identity.DTO
{
    public class UserDTO
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Required]
        public string UserName { get; set; } = null!;
        public Transaction? Transaction { get; set; }
    }
}
