namespace LernDeutsch_Backend.Models.Identity
{
    public class Student : BaseUser
    {
        public virtual List<CourseStudent> Courses { get; set; } = new List<CourseStudent> ();
    }
}
