using System.ComponentModel.DataAnnotations;

namespace LernDeutsch_Backend.Models.Identity.DTO
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
