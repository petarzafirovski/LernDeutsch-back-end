namespace LernDeutsch_Backend.Models.Identity
{
    public class Tutor : BaseUser
    {
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
