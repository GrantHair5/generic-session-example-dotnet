using Microsoft.AspNetCore.Http;
using System;
using System.Globalization;
using System.Threading.Tasks;
using SessionInteractor.Exceptions;

namespace SessionInteractor.Middleware
{
    public class SessionRetrievalMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionRetrievalMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (SessionValueExpiredException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}