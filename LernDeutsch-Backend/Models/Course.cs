using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace LernDeutsch_Backend.Models
{
    public class Course
    {
        [Key]
        public int courseId { get; set; }
        public string name { get; set; }
        public string level { get; set; }
        public int lenght { get; set; }
        public double price { get; set; }
        public List<Student> students { get; set; }
        public List<Lesson> lessons { get; set; }
        public Tutor tutor { get; set; }

       

    }

}
