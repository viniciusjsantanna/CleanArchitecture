using CleanArchitecture.Application.Interfaces.Generics;
using CleanArchitecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.IoC
{
    public static class InfraExtension
    {
        public static void InfraRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EFContext>(config =>
            {
                config.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
            });

            services.AddTransient<IEFContext, EFContext>();
        }
    }
}
