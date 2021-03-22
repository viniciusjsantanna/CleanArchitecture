using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces.Generics;
using CleanArchitecture.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.CQRS.Courses.Queries.GetById
{
    public class GetByIdCourseHandler : IRequestHandler<GetByIdCourseQuery, IResponse>
    {
        private readonly ICourseRepository repository;
        private readonly IMapper mapper;
        private readonly IResponse response;

        public GetByIdCourseHandler(ICourseRepository repository, IMapper mapper, IResponse response)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.response = response;
        }

        public Task<IResponse> Handle(GetByIdCourseQuery request, CancellationToken cancellationToken)
        {
            var course = mapper.Map<CourseDTO>(repository.Get(e => e.Key.Equals(request.CourseId)).Result);
            return response.Generate(collections: course);
        }
    }
}
