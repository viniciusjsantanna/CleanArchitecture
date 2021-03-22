using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces.Generics;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application.IoC
{
    public static class AppExtension
    {
        public static void AppRegister(this IServiceCollection services)
        {
            services.AddMediatR(typeof(AppExtension).Assembly);
            services.AddAutoMapper(typeof(AppExtension).Assembly);
            services.AddTransient<IResponse, Response>();
        }
    }
}
