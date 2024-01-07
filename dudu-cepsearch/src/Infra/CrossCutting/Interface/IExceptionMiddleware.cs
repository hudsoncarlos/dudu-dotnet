using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace CrossCutting.Interface
{
    public interface IExceptionMiddleware
    {
        Task HandleExceptionAsync(HttpContext context, Exception exception);
    }
}
