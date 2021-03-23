using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces.Repositories
{
    public interface ICourseRepository
    {
        Task<int> Add(Course Course);
        Task<bool> Any(Expression<Func<Course, bool>> expression);

        Task<IList<Course>> GetAll();

        Task<Course> Get(Expression<Func<Course, bool>> expression);
    }
}
