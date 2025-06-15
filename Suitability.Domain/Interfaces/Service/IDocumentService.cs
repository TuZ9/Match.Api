namespace Suitability.Domain.Interfaces.Service
{
    public interface IDocumentService
    {
        Task BulkInsert(IEnumerable<Entities.Document> Document);
        Task Insert(Entities.Document user);
        Task Delete(string idUser);
        Task Update(Entities.Document user);
        Task<IEnumerable<Entities.Document>> GetById(string idDocument);
    }
}
