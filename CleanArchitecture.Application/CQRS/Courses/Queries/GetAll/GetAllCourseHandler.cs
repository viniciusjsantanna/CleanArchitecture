using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces.Generics;
using CleanArchitecture.Application.Interfaces.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.CQRS.Courses.Queries.GetAll
{
    public class GetAllCourseHandler : IRequestHandler<GetAllCourseQuery, IResponse>
    {
        private readonly ICourseRepository repository;
        private readonly IMapper mapper;
        private readonly IResponse response;

        public GetAllCourseHandler(ICourseRepository repository, IMapper mapper, IResponse response)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.response = response;
        }

        public Task<IResponse> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
        {
            var listCourse = mapper.Map<IList<CourseDTO>>(repository.GetAll().Result);

            return response.Generate(collections: listCourse);
        }
    }
}
