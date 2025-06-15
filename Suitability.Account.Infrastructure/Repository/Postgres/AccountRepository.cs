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

        public async Task Delete(string idAccount)
        {
            try
            {
                var query = @"DELETE FROM public.tb_account AS ta
                              WHERE ta.id_account = @idAccount;";
                await DeleteAsync(query, idAccount);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error ao Deletar Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task<Domain.Entities.Account> GetSingleById(string account)
        {
            try
            {
                var query = $@"SELECT       id_account as IdAccount,
                                           client_name AS ClientName,
                                           cpf AS CPF,
                                           rg AS RG,
                                           date_birth AS DateOfBirth,
                                           address AS Address,
                                           phone AS Phone,
                                           email AS Email,
                                           accountnumber AS AccountNumber
                                    FROM tb_account
                                    WHERE accountnumber = '{account}'";

                return await GetAsync(query);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Buscar Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Domain.Entities.Account>> GetById(string idAccount)
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
                                           accountnumber AS AccountNumber
                                    FROM public.tb_account
                                    WHERE id_account = @IdAccount";

                return await GetListAsync(query, idAccount);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Buscar Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task Insert(Domain.Entities.Account account)
        {
            try
            {
                var query = @"INSERT INTO public.tb_account (client_name, cpf, rg, date_birth, address, phone, email, accountnumber)
                                     VALUES (@ClientName, @CPF, @RG, @DateOfBirth, @Address, @Phone, @Email, @AccountNumber)";

                await InsertAsync(query, account);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Buscar Flower: {0}", ex.Message);
                throw;
            }
        }

        /// <summary>
        //Arrumar bulk insert
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public async Task BulkInsert(IEnumerable<Domain.Entities.Account> account)
        {
            try
            {
                var query = @"INSERT INTO Account (client_name, cpf, rg, date_birth, address, phone, email, accountnumber)
                                     VALUES (@ClientName, @CPF, @RG, @DateOfBirth, @Address, @Phone, @Email, @AccountNumber)";

                await InsertAsync(query, account);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Buscar Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task Update(Domain.Entities.Account account)
        {
            try
            {
                string query = @"UPDATE Account
                                       SET client_name = @ClientName,
                                           CPF = @CPF,
                                           rg = @RG,
                                           date_birth = @DateOfBirth,
                                           address = @Address,
                                           phone = @Phone,
                                           email = @Email,
                                           accountnumber = @AccountNumber
                                       WHERE id_account = @IdAccount";

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
