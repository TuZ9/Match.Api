namespace Suitability.Domain.Interfaces.Service
{
    public interface IDocumentStatusService
    {
        Task BulkInsert(IEnumerable<Entities.Document> document);
        Task Insert(Entities.Document document);
        Task Delete(string idDocumentr);
        Task Update(Entities.Document document);
        Task<IEnumerable<Entities.Document>> GetById(string idDocument);
    }
}
