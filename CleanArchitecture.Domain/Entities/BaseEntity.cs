using System;

namespace CleanArchitecture.Domain.Entities
{
    public class BaseEntity<T>
    {
        public T Key { get; set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
    }
}
