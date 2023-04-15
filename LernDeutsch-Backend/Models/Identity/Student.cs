namespace LernDeutsch_Backend.Models.Identity
{
    public class Student : BaseUser
    {
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
