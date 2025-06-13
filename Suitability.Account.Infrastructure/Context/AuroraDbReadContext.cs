using Npgsql;
using Suitability.Account.Application.Static;
using System.Data;

namespace Suitability.Account.Infrastructure.Context
{
    public class AuroraDbReadContext : IDisposable
    {
        public AuroraDbReadContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public IDbConnection CreateConnection()
            => new NpgsqlConnection(RunTimeConfig.Auroraconnection);

        public void Dispose()
        {
            GC.SuppressFinalize(this); // Evita que o GC chame o finalizador
        }
    }
}
