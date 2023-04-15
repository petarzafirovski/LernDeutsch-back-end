namespace LernDeutsch_Backend.Models
{
    public class Tutor : BaseUser
    {
        public List<Course> courses { get; set; } = new List<Course>();
    }
}
