using CleanArchitecture.Application.Interfaces.Generics;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Pipelines
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : class
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;
        private readonly IResponse response;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, IResponse response)
        {
            this.validators = validators;
            this.response = response;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = validators
                                .Select(e => e.Validate(request))
                                .SelectMany(e => e.Errors)
                                .Where(e => e != null)
                                .ToList();

            return failures.Any() ? await GenerateErrorMessages(failures) as TResponse : await next();
        }

        public async Task<IResponse> GenerateErrorMessages(List<ValidationFailure> errors)
        {
            var listErrors = errors.Select(e => e.ErrorMessage).ToList();
            return await response.Generate(errorMessages: listErrors);
        }

    }
}
