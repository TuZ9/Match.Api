using Dapper;
using Suitability.Account.Domain.Interfaces.Repository;
using Suitability.Account.Infrastructure.Context;

namespace Suitability.Account.Infrastructure.Repository.Postgres
{
    public class AuroraRepository<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly AuroraDbWriteContext _contextWrite;
        private readonly AuroraDbReadContext _contextRead;

        public AuroraRepository(AuroraDbWriteContext contextWrite, AuroraDbReadContext contextRead)
        {
            _contextWrite = contextWrite;
            _contextRead = contextRead;
        }

        public async Task DeleteAsync(string query, object? param = null)
        {
            using (var con = _contextWrite.CreateConnection())
            {
                await con.ExecuteAsync(query, param);
            }
        }

        public void Dispose()
        {

        }

        public async Task<TEntity> GetAsync(string query, object? param = null)
        {
            using (var con = _contextRead.CreateConnection())
            {
                var result = await con.QueryAsync<TEntity>(query, param);
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(string query, object? param = null)
        {
            using (var con = _contextRead.CreateConnection())
            {
                var result = await con.QueryAsync<TEntity>(query, param);
                return result;
            }
        }

        public async Task InsertAsync(string query, object? param = null)
        {
            using (var con = _contextWrite.CreateConnection())
            {
                await con.ExecuteAsync(query, param);
            }
        }

        public async Task UpdateAsync(string query, object? param = null)
        {
            using (var con = _contextWrite.CreateConnection())
            {
                await con.ExecuteAsync(query, param);
            }
        }
    }
}
