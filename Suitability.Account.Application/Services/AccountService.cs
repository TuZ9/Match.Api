using Microsoft.Extensions.Logging;
using Suitability.Account.Domain.Interfaces.Repository;
using Suitability.Account.Domain.Interfaces.Service;

namespace Suitability.Account.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly ILogger<AccountService> _logger;
        private readonly IAccountRepository _accountRepository;

        public AccountService(ILogger<AccountService> logger, IAccountRepository accountRepository) 
        {
            _logger = logger;
            _accountRepository = accountRepository;
        }

        public async Task Delete(string idUser)
        {
            try
            {
                await _accountRepository.Delete(idUser);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Message {0}", ex.Message);
                throw;
            }
        }

        public async Task<Domain.Entities.Account> GetSingleById(string account_number)
        {
            try
            {
                return await _accountRepository.GetSingleById(account_number);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Message {0}", ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Domain.Entities.Account>> GetById(string idAccount)
        {
            try
            {
                return await _accountRepository.GetById(idAccount);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Message {0}", ex.Message);
                throw;
            }
        }

        public async Task BulkInsert(IEnumerable<Domain.Entities.Account> account)
        {
            try
            {
                await _accountRepository.BulkInsert(account);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Message {0}", ex.Message);
                throw;
            }
        }

        public async Task Update(Domain.Entities.Account account)
        {
            try
            {
                await _accountRepository.Update(account);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Message {0}", ex.Message);
                throw;
            }
        }

        public async Task Insert(Domain.Entities.Account account)
        {
            try
            {
                await _accountRepository.Insert(account);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Message {0}", ex.Message);
                throw;
            }
        }
    }
}
