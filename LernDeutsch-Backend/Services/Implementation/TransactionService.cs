using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Repositories;

namespace LernDeutsch_Backend.Services.Implementation
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public Transaction Create(Transaction entity) =>
            _transactionRepository.Create(entity);

        public Transaction Update(Guid id, Transaction entity)
        {
            // TODO: Finish implementing after mappers
            throw new NotImplementedException();
        }

        public Transaction Delete(Guid id) =>
        _transactionRepository.Delete(id);

        public Transaction? GetById(Guid id) =>
        _transactionRepository.GetById(id);

        public List<Transaction> GetAll() => 
            _transactionRepository.GetAll();
    }
}
