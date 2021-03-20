using CleanArchitecture.Application.CQRS.Courses.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Register([FromBody] RegisterCourseCommand command)
        {
            var course = mediator.Send(command).Result;
            return Ok();
        }

    }
}
