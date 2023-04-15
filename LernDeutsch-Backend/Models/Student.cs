namespace LernDeutsch_Backend.Models
{
    public class Student : BaseUser
    {
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
