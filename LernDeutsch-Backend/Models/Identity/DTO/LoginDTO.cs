using System.ComponentModel.DataAnnotations;

namespace LernDeutsch_Backend.Models.Identity.DTO
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
