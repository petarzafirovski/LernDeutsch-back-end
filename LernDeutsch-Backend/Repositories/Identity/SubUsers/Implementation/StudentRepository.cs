using LernDeutsch_Backend.Data;
using LernDeutsch_Backend.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace LernDeutsch_Backend.Repositories.Identity.SubUsers.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDatabaseContext _context;

        public StudentRepository(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        public Student CreateSubUser(BaseUser baseUser)
        {
            Student student = new()
            {
                BaseUser = baseUser,
                BaseUserId = baseUser.Id,
            };

            var inserted = _context.Students.Add(student).Entity;
            _context.SaveChanges();
            return inserted;
        }

        public Student? Get(string Id)
        {
            var student = _context.Students.Where(x=>x.BaseUserId == Id).Include(x => x.BaseUser).FirstOrDefault();
            return student;
        }

        public List<Student> GetAll()
        {
            return _context.Students.Include(x => x.BaseUser).ToList();
        }

        public Student? GetUserByUsername(string username)
        {
            var student = _context.Students.Where(x=>x.BaseUser.UserName == username).Include(x => x.BaseUser).FirstOrDefault();
            return student;
        }
    }
}
