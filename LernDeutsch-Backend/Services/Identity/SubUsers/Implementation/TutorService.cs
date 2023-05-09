using LernDeutsch_Backend.Models.Identity;
using LernDeutsch_Backend.Repositories.Identity;
using LernDeutsch_Backend.Repositories.Identity.SubUsers;

namespace LernDeutsch_Backend.Services.Identity.SubUsers.Implementation
{
    public class TutorService : ITutorService
    {
        private readonly ITutorRepository _tutorRepository;

        public TutorService(ITutorRepository _tutorRepository)
        {
            this._tutorRepository = _tutorRepository;
        }

        public Tutor CreateSubUser(BaseUser baseUser)
        {
            return _tutorRepository.CreateSubUser(baseUser);
        }

        public List<Tutor> GetAll()
        {
            return _tutorRepository.GetAll();
        }

        public Tutor? GetUser(string Id)
        {           
            var user = _tutorRepository.Get(Id);
            if (user == null)
                throw new Exception("User does not exist");
            return user;
        }

        public Tutor? GetUserByUserName(string username)
        {
           return _tutorRepository.GetUserByUsername(username);
        }
    }
}
