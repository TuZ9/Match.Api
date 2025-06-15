namespace Suitability.Domain.Interfaces.Repository
{
    public interface IAccountRepository
    {
        Task<Entities.Account> GetSingleById(string idAccount);
        Task<IEnumerable<Entities.Account>> GetById(string idAccount);
        Task Insert(Entities.Account account);
        Task BulkInsert(IEnumerable<Entities.Account> account);
        Task Update(Entities.Account account);
        Task Delete(string idAccount);
    }
}
