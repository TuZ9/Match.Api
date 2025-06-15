namespace Suitability.Domain.Interfaces.Repository
{
    public interface IDocumentStatusRepository
    {
        Task<Entities.DocumentStatus> GetSingleById(string idDocument);
        Task<IEnumerable<Entities.DocumentStatus>> GetById(string idDocument);
        Task Insert(Entities.DocumentStatus Document);
        Task BulkInsert(IEnumerable<Entities.DocumentStatus> Document);
        Task Update(Entities.DocumentStatus Document);
        Task Delete(string idDocument);
    }
}
