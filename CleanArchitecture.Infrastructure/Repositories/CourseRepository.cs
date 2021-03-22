using CleanArchitecture.Application.Interfaces.Generics;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IEFContext context;

        public CourseRepository(IEFContext context)
        {
            this.context = context;
        }

        public async Task<int> Add(Course Course)
        {
            await context.Courses.AddAsync(Course);
            return await context.SaveChangesAsync();
        }
        public Task<bool> Any(Expression<Func<Course, bool>> expression)
        {
            return context.Courses.AnyAsync(expression);
        }

        public Task<Course> Get(Expression<Func<Course, bool>> expression)
        {
            return context.Courses.FirstOrDefaultAsync(expression);
        }

        public async Task<IList<Course>> GetAll()
        {
            return await context.Courses.ToListAsync();
        }
    }
}
