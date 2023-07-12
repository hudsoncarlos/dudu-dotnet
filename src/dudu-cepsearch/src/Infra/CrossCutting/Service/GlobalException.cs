using CrossCutting.Interface;
using CrossCutting.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace CrossCutting.Service
{
    public class GlobalException : IExceptionMiddleware
    {
        readonly GenericError _genericError;

        public GlobalException(IOptions<GenericError> middleware) 
            => _genericError = middleware.Value;

        public Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(new GenericError()
            {
                StatusCode = _genericError.StatusCode,
                Message = _genericError.Message
            }.ToString());
        }
    }
}
