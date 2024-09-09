using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura.Aplication.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string apiKey = "XApiKey";

            if (!context.Request.Headers.TryGetValue(apiKey.ToLower(), out var key))
            {
                context.Response.StatusCode = StatusCodes.Status203NonAuthoritative;
                await context.Response.WriteAsync("El Api Key es requerido y no tienes permiso sobre los recursos");
                return;
            }

            var config = context.RequestServices.GetRequiredService<IConfiguration>();

            if (!key.Equals(config[apiKey.ToLower()]))
            {
                context.Response.StatusCode = StatusCodes.Status203NonAuthoritative;
                await context.Response.WriteAsync("No tienes un Api Key Valido contante al soporte");
                return;
            }

            await _next(context);
        }
    }
}
