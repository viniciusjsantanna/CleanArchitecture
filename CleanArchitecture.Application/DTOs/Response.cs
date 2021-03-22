using CleanArchitecture.Application.Interfaces.Generics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTOs
{
    public class Response : IResponse
    {
        public object collections { get; set; }
        public string message { get; set; }
        public bool hasError { get; set; }

        public async Task<IResponse> Generate(object collections = default, string message = default, bool hasError = default)
        {
            this.collections = collections;
            this.message = message;
            this.hasError = hasError;

            return await Task.FromResult(this);
        }
    }
}
