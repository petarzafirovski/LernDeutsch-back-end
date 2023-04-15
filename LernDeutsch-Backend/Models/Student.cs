namespace LernDeutsch_Backend.Models
{
    public class Student : BaseUser
    {
        public List<Course> courses { get; set; } = new List<Course>();
    }
}
