using LernDeutsch_Backend.Data;
using LernDeutsch_Backend.Models.Identity;

namespace LernDeutsch_Backend.Repositories.Identity.SubUsers.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDatabaseContext _context;

        public StudentRepository(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        public Student? Get(string Id)
        {
            var student = _context.Students.Find(Id);
            return student;
        }

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student? GetUserByUsername(string username)
        {
            var student = _context.Students.Where(x=>x.UserName == username).FirstOrDefault();
            return student;
        }
    }
}
