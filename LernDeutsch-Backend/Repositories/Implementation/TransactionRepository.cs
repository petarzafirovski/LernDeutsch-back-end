using LernDeutsch_Backend.Data;
using LernDeutsch_Backend.Models;

namespace LernDeutsch_Backend.Repositories.Implementation
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDatabaseContext _context;

        public TransactionRepository(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        public List<Transaction> GetAll() =>
            _context.Transactions.ToList();

        public Transaction? GetById(Guid id) =>
            _context.Transactions.Find(id);

        public Transaction Create(Transaction entity)
        {
            var record = _context.Transactions.Add(entity).Entity;
            _context.SaveChanges();
            return record;
        }

        public Transaction Update(Transaction entity)
        {
            var record = _context.Transactions.Update(entity).Entity;
            _context.SaveChanges();
            return record;
        }

        public Transaction Delete(Guid id) =>
            _context.Transactions.Remove(GetById(id)!).Entity;
    }
}
