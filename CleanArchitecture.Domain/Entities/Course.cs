using CleanArchitecture.Domain.ValueObjects;
using System;
using Type = CleanArchitecture.Domain.Enums.Type;

namespace CleanArchitecture.Domain.Entities
{
    public class Course : BaseEntity<Guid>
    {
        public Name Name { get; set; }
        public Type Type { get; set; }
    }
}
