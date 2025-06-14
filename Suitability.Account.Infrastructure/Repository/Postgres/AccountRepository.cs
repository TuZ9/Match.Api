using Microsoft.Extensions.Logging;
using Suitability.Account.Domain.Interfaces.Repository;
using Suitability.Account.Infrastructure.Context;

namespace Suitability.Account.Infrastructure.Repository.Postgres
{
    public class AccountRepository : AuroraRepository<Domain.Entities.Account>, IAccountRepository
    {
        private readonly ILogger<AccountRepository> _logger;
        public AccountRepository(AuroraDbWriteContext contextWrite, AuroraDbReadContext contextRead, ILogger<AccountRepository> logger) : base(contextWrite, contextRead)
        {
            _logger = logger;
        }

        public async Task Delete(Domain.Entities.Account account)
        {
            try
            {
                var query = @"DELETE FROM public.Flower AS tgt
                              USING SOURCE_TABLE AS src
                              WHERE tgt.id_flower=src.id_flower;";
                await DeleteAsync(query);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error ao Deletar Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Domain.Entities.Account>> Get()
        {
            try
            {
                var query = @"INSERT INTO public.Flower
                              (name, type, description, qr, url, image, labtest, thc, cbd, createdat, updatedat, id_brand, id_strain, id_flower)
                              VALUES('', '', '', '', '', '', false, false, false, '', '', ?, ?, ?);";

                return await GetListAsync(query);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Buscar Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task Insert(IEnumerable<Domain.Entities.Account> account)
        {
            try
            {
                var query = @"INSERT INTO public.Flower
                              (name, type, description, qr, url, image, labtest, thc, cbd, createdat, updatedat, id_brand, id_strain, id_flower)
                              VALUES('', '', '', '', '', '', false, false, false, '', '', ?, ?, ?);";

                await InsertAsync(query, account);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Buscar Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task Update(IEnumerable<Domain.Entities.Account> account)
        {
            try
            {
                var query = @"UPDATE public.Flower
                              SET 
                              name='', type='', description='', qr='', url='', image='', labtest=false, 
                              thc=false, cbd=false, createdat='', updatedat='', id_brand=?, id_strain=?
                              WHERE id_flower=?;";

                await UpdateAsync(query, account);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Update Flower: {0}", ex.Message);
                throw;
            }
        }
    }
}
