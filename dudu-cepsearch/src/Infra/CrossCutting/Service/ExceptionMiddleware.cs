using CrossCutting.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace CrossCutting.Service
{
    public class ExceptionMiddleware
    {
        readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context, IExceptionMiddleware exceptionMiddleware)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await exceptionMiddleware.HandleExceptionAsync(context, ex);
            }
        }
    }
}
