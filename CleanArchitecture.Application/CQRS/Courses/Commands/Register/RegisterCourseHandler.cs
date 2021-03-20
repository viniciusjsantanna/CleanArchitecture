using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.CQRS.Courses.Commands.Register
{
    public class RegisterCourseHandler : IRequestHandler<RegisterCourseCommand, Course>
    {
        public RegisterCourseHandler()
        {

        }
        public Task<Course> Handle(RegisterCourseCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
