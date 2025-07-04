﻿namespace Suitability.Domain.Interfaces.Service
{
    public interface IAccountService
    {
        Task<Entities.Account> GetSingleById(string idAccount);
        Task BulkInsert(IEnumerable<Entities.Account> account);
        Task Insert(Entities.Account user);
        Task Delete(string idUser);
        Task Update(Entities.Account user);
        Task<IEnumerable<Entities.Account>> GetById(string idAccount);
    }
}
