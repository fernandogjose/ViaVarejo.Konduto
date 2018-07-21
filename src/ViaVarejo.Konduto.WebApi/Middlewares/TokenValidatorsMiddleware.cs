using System;
using System.Threading.Tasks;
using ViaVarejo.Konduto.Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace ViaVarejo.Konduto.WebApi.Middlewares {

    public class TokenValidatorsMiddleware {
        private readonly RequestDelegate _next;

        public TokenValidatorsMiddleware (RequestDelegate next) {
            _next = next;
        }

        public async Task Invoke (HttpContext context) {

            StringValues tokenRequest;
            if (!context.Request.Headers.TryGetValue ("token", out tokenRequest)) {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync ("token não encontrado");
                return;
            }

            //--- Fernando - Criar uma validação do token, verificar se ele é válido

            await _next.Invoke (context);
        }
    }

    public static class UserKeyValidatorsExtension {
        public static IApplicationBuilder ApplyUserKeyValidation (this IApplicationBuilder app) {
            app.UseMiddleware<TokenValidatorsMiddleware> ();
            return app;
        }
    }
}