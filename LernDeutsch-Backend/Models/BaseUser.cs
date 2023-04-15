using Microsoft.AspNetCore.Identity;

namespace LernDeutsch_Backend.Models
{
    public class BaseUser : IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
