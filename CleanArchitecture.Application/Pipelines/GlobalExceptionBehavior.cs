using CleanArchitecture.Application.Interfaces.Generics;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Pipelines
{
    public class GlobalExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : class
    {
        private readonly IResponse response;

        public GlobalExceptionBehavior(IResponse response)
        {
            this.response = response;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                return await response.Generate(message: ex.Message, hasError: true) as TResponse;
            }
        }
    }
}
