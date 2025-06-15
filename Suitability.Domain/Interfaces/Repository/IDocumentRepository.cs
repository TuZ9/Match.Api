namespace Suitability.Domain.Interfaces.Repository
{
    public interface IDocumentRepository
    {
        Task<Entities.Document> GetSingleById(string idDocument);
        Task<IEnumerable<Entities.Document>> GetById(string idDocument);
        Task Insert(Entities.Document Document);
        Task BulkInsert(IEnumerable<Entities.Document> Document);
        Task Update(Entities.Document Document);
        Task Delete(string idDocument);
    }
}
