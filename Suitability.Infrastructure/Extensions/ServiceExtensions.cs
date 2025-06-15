using Microsoft.Extensions.DependencyInjection;
using Suitability.Application.Services;
using Suitability.Domain.Interfaces.Repository;
using Suitability.Domain.Interfaces.Service;
using Suitability.Infrastructure.Context;
using Suitability.Infrastructure.Repository.Postgres;

namespace Suitability.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .RegisterServices()
                .RegisterRepositories();
        }

        private static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IAccountService, AccountService>()
                .AddScoped<IDocumentService, DocumentService>();
        }

        private static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            return services
                .AddSingleton(_ => new AuroraDbReadContext())
                .AddSingleton(_ => new AuroraDbWriteContext())
                .AddScoped<IAccountRepository, AccountRepository>()
                .AddScoped<IDocumentRepository, DocumentRepository>();
        }
    }
}
