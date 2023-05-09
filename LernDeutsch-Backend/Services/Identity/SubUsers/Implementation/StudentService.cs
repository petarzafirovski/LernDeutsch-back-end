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

        public Student CreateSubUser(BaseUser baseUser)
        {
            return _studentRepository.CreateSubUser(baseUser);
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public Student? GetUser(string Id)
        {
            var user = _studentRepository.Get(Id);
            if (user == null)
                throw new Exception("User does not exist");
            return _studentRepository.Get(Id);
        }

        public Student? GetUserByUserName(string username)
        {
            return _studentRepository.GetUserByUsername(username);
        }
    }
}
