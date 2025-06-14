namespace Suitability.Account.Domain.Interfaces.Repository
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Entities.Account>> Get();
        Task Insert(IEnumerable<Entities.Account> flower);
        Task Update(IEnumerable<Entities.Account> flower);
        Task Delete(Entities.Account flower);
    }
}
