using Microsoft.Extensions.Logging;
using Suitability.Domain.Interfaces.Repository;
using Suitability.Infrastructure.Context;

namespace Suitability.Infrastructure.Repository.Postgres
{
    public class DocumentRepository : AuroraRepository<Domain.Entities.Document>, IDocumentRepository
    {
        private readonly ILogger<DocumentRepository> _logger;
        public DocumentRepository(AuroraDbWriteContext contextWrite, AuroraDbReadContext contextRead, ILogger<DocumentRepository> logger) : base(contextWrite, contextRead)
        {
            _logger = logger;
        }

        public async Task Delete(string idDocument)
        {
            try
            {
                var query = @"DELETE FROM public.tb_Document AS ta
                              WHERE ta.id_Document = @IdDocument;";
                await DeleteAsync(query, idDocument);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error ao Deletar Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task<Domain.Entities.Document> GetSingleById(string idDocument)
        {
            try
            {
                var query = @"SELECT client_name AS ClientName,
                                           cpf AS CPF,
                                           rg AS RG,
                                           date_birth AS DateOfBirth,
                                           address AS Address,
                                           phone AS Phone,
                                           email AS Email,
                                           Documentnumber AS DocumentNumber
                                    FROM Document
                                    WHERE id_Document = @IdDocument";

                return await GetAsync(query, idDocument);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Buscar Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Domain.Entities.Document>> GetById(string idDocument)
        {
            try
            {
                var query = @"SELECT client_name AS ClientName,
                                           cpf AS CPF,
                                           rg AS RG,
                                           date_birth AS DateOfBirth,
                                           address AS Address,
                                           phone AS Phone,
                                           email AS Email,
                                           Documentnumber AS DocumentNumber
                                    FROM Document
                                    WHERE id_Document = @IdDocument";

                return await GetListAsync(query, idDocument);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Buscar Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task Insert(Domain.Entities.Document Document)
        {
            try
            {
                var query = @"INSERT INTO Document (client_name, cpf, rg, date_birth, address, phone, email, Documentnumber)
                                     VALUES (@ClientName, @CPF, @RG, @DateOfBirth, @Address, @Phone, @Email, @DocumentNumber)";

                await InsertAsync(query, Document);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Buscar Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task BulkInsert(IEnumerable<Domain.Entities.Document> Document)
        {
            try
            {
                var query = @"INSERT INTO Document (client_name, cpf, rg, date_birth, address, phone, email, Documentnumber)
                                     VALUES (@ClientName, @CPF, @RG, @DateOfBirth, @Address, @Phone, @Email, @DocumentNumber)";

                await InsertAsync(query, Document);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Buscar Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task Update(Domain.Entities.Document Document)
        {
            try
            {
                string query = @"UPDATE Document
                                       SET client_name = @ClientName,
                                           CPF = @CPF,
                                           rg = @RG,
                                           date_birth = @DateOfBirth,
                                           address = @Address,
                                           phone = @Phone,
                                           email = @Email,
                                           Documentnumber = @DocumentNumber
                                       WHERE id_Document = @IdDocument";

                await UpdateAsync(query, Document);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Update Flower: {0}", ex.Message);
                throw;
            }
        }
    }
}
