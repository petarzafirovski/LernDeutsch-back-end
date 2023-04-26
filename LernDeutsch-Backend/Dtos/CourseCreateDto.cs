namespace LernDeutsch_Backend.Dtos
{
    public class CourseCreateDto
    {
        public string Name { get; set; }
        public string Level { get; set; }
        public int Length { get; set; }
        public double Price { get; set; }
        public Guid TutorId { get; set; }
    }
}
