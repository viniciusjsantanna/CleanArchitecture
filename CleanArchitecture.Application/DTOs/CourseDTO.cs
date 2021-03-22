using System;
using Type = CleanArchitecture.Domain.Enums.Type;

namespace CleanArchitecture.Application.DTOs
{
    public class CourseDTO
    {
        public Guid Key { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
    }
}
