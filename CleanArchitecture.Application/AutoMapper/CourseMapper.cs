using AutoMapper;
using CleanArchitecture.Application.CQRS.Courses.Commands.Register;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.AutoMapper
{
    public class CourseMapper : Profile
    {
        public CourseMapper()
        {
            CreateMap<RegisterCourseCommand, Course>();

            CreateMap<Course, CourseDTO>()
                .ForMember(e => e.Key, opt => opt.MapFrom(e => e.Key))
                .ForMember(e => e.Name, opt => opt.MapFrom(e => e.Name))
                .ForMember(e => e.Type, opt => opt.MapFrom(e => e.Type))
                .ForAllOtherMembers(e => e.Ignore());
        }
    }
}
