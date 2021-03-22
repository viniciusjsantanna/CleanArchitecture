using CleanArchitecture.Application.Interfaces.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.CQRS.Courses.Queries.GetById
{
    public class GetByIdCourseQuery : IRequest<IResponse>
    {
        public GetByIdCourseQuery(Guid courseId)
        {
            CourseId = courseId;
        }

        public Guid CourseId { get; set; }
    }
}
