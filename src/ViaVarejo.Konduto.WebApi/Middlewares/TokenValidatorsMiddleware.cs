using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using ViaVarejo.Konduto.Domain.Models;

namespace ViaVarejo.Konduto.WebApi.Middlewares {

    public class TokenValidatorsMiddleware {
        
        private readonly RequestDelegate _next;
        
        private readonly IConfiguration _configuration;

        public TokenValidatorsMiddleware (RequestDelegate next, IConfiguration configuration) {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke (HttpContext context) {

            StringValues tokenRequest;
            if (!context.Request.Headers.TryGetValue ("token", out tokenRequest)) {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync ("token não encontrado");
                return;
            }

            //--- Fernando - Criar uma validação do token mais forte
            string token = _configuration["Data:Token"];
            if(tokenRequest[0] != token){
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync ("token inválido");
                return;
            }

            await _next.Invoke (context);
        }
    }

    public static class TokenValidatorsExtension {
        public static IApplicationBuilder TokenKeyValidation (this IApplicationBuilder app) {
            app.UseMiddleware<TokenValidatorsMiddleware> ();
            return app;
        }
    }
}