using CleanArchitecture.Application.CQRS.Courses.Commands.Register;
using CleanArchitecture.Application.CQRS.Courses.Queries.GetAll;
using CleanArchitecture.Application.CQRS.Courses.Queries.GetById;
using CleanArchitecture.Application.Interfaces.Generics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CleanArchitecture.Presentation.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator mediator;

        public CourseController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        
        [HttpPost]
        public Task<IResponse> Register([FromBody] RegisterCourseCommand command)
        {
            return mediator.Send(command);
        }

        [HttpGet]
        public Task<IResponse> GetAll()
        {
            return mediator.Send(new GetAllCourseQuery());
        }

        [HttpGet]
        [Route("GetById")]
        public Task<IResponse> GetById([FromQuery] Guid courseId)
        {
            return mediator.Send(new GetByIdCourseQuery(courseId));
        }

    }
}
