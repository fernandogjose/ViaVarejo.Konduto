using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ViaVarejo.Konduto.DI;
using ViaVarejo.Konduto.WebApi.Middlewares;

namespace ViaVarejo.Konduto.WebApi
{
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //--- método chamado em tempo de execução. Usar para adicionar servicos ao container
        public void ConfigureServices (IServiceCollection services) {
            Bootstrap.Configure (services);
            services.AddCors ();
            services.AddMvc ();
        }

        //--- método chamado em tempo de execução. Usar para configurar HttpRequest pipeline
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseCors (
                options => options.WithOrigins ("//carrinho.casasbahia.com.br")
                .WithOrigins ("//www.casasbahia.com.br")
                .AllowAnyHeader ()
                .AllowAnyMethod ()
                .AllowAnyOrigin ()
            );

            app.UseMiddleware (typeof (ErrorMiddleware));
            app.TokenKeyValidation ();
            app.UseMvc ();
        }
    }
}