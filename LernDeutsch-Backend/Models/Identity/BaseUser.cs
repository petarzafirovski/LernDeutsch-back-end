using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LernDeutsch_Backend.Models.Identity
{
    public class BaseUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        [InverseProperty("BaseUser")]
        public virtual Tutor Tutor { get; set; } = null!;
        [InverseProperty("BaseUser")]
        public virtual Student Student { get; set; } = null!;
    }
}
