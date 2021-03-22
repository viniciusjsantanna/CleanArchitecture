using AutoMapper;
using CleanArchitecture.Application.Interfaces.Generics;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.CQRS.Courses.Commands.Register
{
    public class RegisterCourseHandler : IRequestHandler<RegisterCourseCommand, IResponse>
    {
        private readonly IMapper mapper;
        private readonly ICourseRepository repository;
        private readonly IResponse response;

        public RegisterCourseHandler(IMapper mapper, ICourseRepository repository, IResponse response)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.response = response;
        }
        public Task<IResponse> Handle(RegisterCourseCommand request, CancellationToken cancellationToken)
        {
            var exist = repository.Any(e => e.Name.name.Equals(request.Name)).Result;

            if (exist)
            {
                return response.Generate(message: $"O curso já existe!", hasError: true);
            }

            var course = repository.Add(mapper.Map<Course>(request)).Result;
            if(course <= 0)
            {
                return response.Generate(message: $"Não foi possível registrar o curso!", hasError: true);
            }

            return response.Generate(message: $"O Curso foi salvo com sucesso!");
        }
    }
}
