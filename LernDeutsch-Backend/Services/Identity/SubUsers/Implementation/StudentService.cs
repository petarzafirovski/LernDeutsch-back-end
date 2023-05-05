using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Models.Identity;
using LernDeutsch_Backend.Repositories.Identity.SubUsers;

namespace LernDeutsch_Backend.Services.Identity.SubUsers.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public Student GetUser(string Id)
        {
            return _studentRepository.Get(Id);
        }
    }
}
