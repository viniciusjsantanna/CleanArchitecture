using CleanArchitecture.Application.Interfaces.Generics;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<Course> Add(Course Course)
        {
            await context.Courses.AddAsync(Course);
            var retorno = context.SaveChangesAsync().Result;
            if(retorno <= 0)
            {
                throw new Exception("Não foi possível adicionar o curso!");
            }

            return Course;
        }
    }
}
