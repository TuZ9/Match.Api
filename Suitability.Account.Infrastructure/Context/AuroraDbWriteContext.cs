using Npgsql;
using Suitability.Application.Static;
using System.Data;

namespace Suitability.Infrastructure.Context
{
    public class AuroraDbWriteContext : IDisposable
    {
        public AuroraDbWriteContext()
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
