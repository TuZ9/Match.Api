using Microsoft.Extensions.DependencyInjection;
using Suitability.Account.Application.Services;
using Suitability.Account.Domain.Interfaces.Repository;
using Suitability.Account.Domain.Interfaces.Service;
using Suitability.Account.Infrastructure.Context;
using Suitability.Account.Infrastructure.Repository.Postgres;

namespace Suitability.Account.Infrastructure.Extensions
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
                .AddScoped<IAccountService, AccountService>();
        }

        private static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            return services
                .AddSingleton(_ => new AuroraDbReadContext())
                .AddSingleton(_ => new AuroraDbWriteContext())
                .AddScoped<IAccountRepository, AccountRepository>();
        }
    }
}
