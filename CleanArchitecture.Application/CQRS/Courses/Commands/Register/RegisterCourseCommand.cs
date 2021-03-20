using CleanArchitecture.Domain.Entities;
using MediatR;
using Type = CleanArchitecture.Domain.Enums.Type;

namespace CleanArchitecture.Application.CQRS.Courses.Commands.Register
{
    public class RegisterCourseCommand : IRequest<Course>
    {
        public string Name { get; set; }
        public Type Type { get; set; }
    }
}
