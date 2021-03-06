using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces.Generics
{
    public interface IResponse
    {
        string message { get; set; }
        bool hasError { get; set; }
        Task<IResponse> Generate(object collections = default, string message = default, bool hasError = default, List<string> errorMessages = default);
    }
}
