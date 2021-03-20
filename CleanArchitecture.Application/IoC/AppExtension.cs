using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application.IoC
{
    public static class AppExtension
    {
        public static void AppRegister(this IServiceCollection services)
        {
            services.AddMediatR(typeof(AppExtension).Assembly);
        }
    }
}
