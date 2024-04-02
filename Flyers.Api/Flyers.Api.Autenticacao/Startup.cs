using Flyers.Api.Autenticacao.Data;
using Flyers.Api.Autenticacao.Settings;
using Flyers.Api.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyers.Api.Autenticacao
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /* Configuracao especificas */
            //Default da Api
            services.AddControllers();

            //Configuracao do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Flyers.Api.Autenticacao",
                    Version = "v1",
                    Description = "Autenticação de usuário crendenciados para o uso do Flyers Api",
                    Contact = new OpenApiContact() { Name = "MoWBI T.I.C", Email = "suporte.tecnico@mowbi.com.br" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
                });
            });

            //Configuracao do banco de dados para o Identity
            services.AddDbContext<IdentidadesDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnectionString")));

            //Configuracao do Identity
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()//entity framework
                .AddErrorDescriber<ErroMensagensIdentitySettings>()//mensagens de erros em portugues
                .AddEntityFrameworkStores<IdentidadesDbContext>()
                .AddDefaultTokenProviders(); //chaves de seguranca

            /* Configuracao comuns e gerais */
            //Configuracao do servico de autenticacao por JWT 
            services.AddJwtConfiguration(Configuration);
            //Configuracao do servico de fila de mensagens pelo EventBus com RabbitMQ
            //services.AddEventBusConfiguration(Configuration);
            services.AddEventBusConfiguration(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flyers.Api.Autenticacao v1"));
            }
            //Default
            app.UseHttpsRedirection();
            app.UseRouting();
            //Habilitando autenticacao e autorizacao => obs. deve estar apos .UseRouting()
            app.UseAuthentication();
            app.UseAuthorization();
            //Default
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
