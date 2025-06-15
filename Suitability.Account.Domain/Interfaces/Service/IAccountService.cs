namespace Suitability.Account.Domain.Interfaces.Service
{
    public interface IAccountService
    {
        Task BulkInsert(IEnumerable<Entities.Account> account);
        Task Insert(Entities.Account user);
        Task Delete(string idUser);
        Task Update(Entities.Account user);
        Task<IEnumerable<Entities.Account>> GetById(string idAccount);
    }
}
