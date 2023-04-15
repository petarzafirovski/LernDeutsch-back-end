namespace LernDeutsch_Backend.Models
{
    public class Tutor : BaseUser
    {
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
