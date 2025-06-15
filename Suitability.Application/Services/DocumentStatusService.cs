using Microsoft.Extensions.Logging;
using Suitability.Domain.Interfaces.Repository;
using Suitability.Domain.Interfaces.Service;

namespace Suitability.Application.Services
{
    public class DocumentStatusService : IDocumentStatusService
    {
        private readonly ILogger<DocumentService> _logger;
        private readonly IDocumentRepository _DocumentRepository;

        public DocumentStatusService(ILogger<DocumentService> logger, IDocumentRepository DocumentRepository)
        {
            _logger = logger;
            _DocumentRepository = DocumentRepository;
        }

        public async Task Delete(string idDocument)
        {
            try
            {
                await _DocumentRepository.Delete(idDocument);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Message {0}", ex.Message);
                throw;
            }
        }

        public async Task<Domain.Entities.Document> GetSingleById(string idDocument)
        {
            try
            {
                return await _DocumentRepository.GetSingleById(idDocument);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Message {0}", ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Domain.Entities.Document>> GetById(string idDocument)
        {
            try
            {
                return await _DocumentRepository.GetById(idDocument);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Message {0}", ex.Message);
                throw;
            }
        }

        public async Task BulkInsert(IEnumerable<Domain.Entities.Document> Document)
        {
            try
            {
                await _DocumentRepository.BulkInsert(Document);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Message {0}", ex.Message);
                throw;
            }
        }

        public async Task Update(Domain.Entities.Document Document)
        {
            try
            {
                await _DocumentRepository.Update(Document);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Message {0}", ex.Message);
                throw;
            }
        }

        public async Task Insert(Domain.Entities.Document Document)
        {
            try
            {
                await _DocumentRepository.Insert(Document);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Message {0}", ex.Message);
                throw;
            }
        }
    }
}
