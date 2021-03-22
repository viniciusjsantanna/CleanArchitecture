using CleanArchitecture.Application.Interfaces.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.CQRS.Courses.Queries.GetAll
{
    public class GetAllCourseQuery : IRequest<IResponse>
    {
    }
}
