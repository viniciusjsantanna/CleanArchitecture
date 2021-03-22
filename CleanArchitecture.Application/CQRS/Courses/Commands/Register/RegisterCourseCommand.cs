using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces.Generics;
using MediatR;
using Type = CleanArchitecture.Domain.Enums.Type;

namespace CleanArchitecture.Application.CQRS.Courses.Commands.Register
{
    public class RegisterCourseCommand : IRequest<IResponse>
    {
        public string Name { get; set; }
        public Type Type { get; set; }
    }
}
