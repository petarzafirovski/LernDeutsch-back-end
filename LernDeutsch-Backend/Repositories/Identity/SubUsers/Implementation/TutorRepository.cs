using LernDeutsch_Backend.Data;
using LernDeutsch_Backend.Models.Identity;

namespace LernDeutsch_Backend.Repositories.Identity.SubUsers.Implementation
{
    public class TutorRepository : ITutorRepository
    {
        private readonly ApplicationDatabaseContext _context;

        public TutorRepository(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        public Tutor? Get(string Id)
        {
            var tutor = _context.Tutors.Find(Id);
            return tutor;
        }

        public List<Tutor> GetAll()
        {
            return _context.Tutors.ToList();    
        }

        public Tutor? GetUserByUsername(string username)
        {
            var tutor = _context.Tutors.Where(x=>x.UserName == username).FirstOrDefault();
            return tutor;
        }
    }
}
