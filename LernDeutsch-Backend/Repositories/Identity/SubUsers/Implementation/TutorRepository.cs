using LernDeutsch_Backend.Data;
using LernDeutsch_Backend.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace LernDeutsch_Backend.Repositories.Identity.SubUsers.Implementation
{
    public class TutorRepository : ITutorRepository
    {
        private readonly ApplicationDatabaseContext _context;
        private readonly IUserRepository _userRepository;

        public TutorRepository(ApplicationDatabaseContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public Tutor CreateSubUser(BaseUser baseUser)
        {
            Tutor tutor = new()
            {
                BaseUser = baseUser,
                BaseUserId = baseUser.Id,
            };
             var inserted = _context.Tutors.Add(tutor).Entity;
            _context.SaveChanges();
            return inserted;
        }

        public Tutor? Get(string Id)
        {
            var tutor = _context.Tutors.Where(x=>x.BaseUserId == Id).Include(x => x.BaseUser).FirstOrDefault();
            return tutor;
        }

        public List<Tutor> GetAll()
        {
            return _context.Tutors.Include(x=>x.BaseUser).ToList();    
        }

        public Tutor? GetUserByUsername(string username)
        {
            var tutor = _context.Tutors.Where(x=>x.BaseUser.UserName == username).Include(x=>x.BaseUser).FirstOrDefault();
            return tutor;
        }
    }
}
