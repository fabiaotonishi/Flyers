using FluentValidation;
using Flyers.Api.Application;
using Flyers.Api.Behaviors;
using Flyers.Api.Configurations;
using Flyers.Api.Ofertas.Application.Handlers.QueryHandlers;
using Flyers.Api.Ofertas.Application.Queries;
using Flyers.Api.Ofertas.Models;
using Flyers.Core.Interfaces.DataRepositories;
using Flyers.Core.Interfaces.DataServices;
using Flyers.Core.Services.DataServices;
using Flyers.Data.Contexts;
using Flyers.Data.Repositories.DataRepositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Flyers.Api.Ofertas
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

            //Configuracao Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Flyers.Api.Ofertas",
                    Version = "v1",
                    Description = "Flyers Api",
                    Contact = new OpenApiContact() { Name = "MoWBI T.I.C", Email = "suporte.tecnico@mowbi.com.br" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
                });
            });

            //Configuracao do banco de dados
            services.AddDbContext<DadosDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnectionString")));

            //Configuracao dos servicos dos AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Configuracao dos servicos dos repositorios de banco de dados     
            services.AddScoped<IDataRepository, DataRepository>();
            services.AddScoped<IArquivoDataService, ArquivoDataService>();
            services.AddScoped<IOfertaDataService, OfertaDataService>();
            services.AddScoped<IOfertaProdutoDataService, OfertaProdutoDataService>();

            //Configuracao dos servicos do Mediator
            services.AddMediatR(typeof(Startup));
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<ObtemOfertasPorPeriodoQuery, List<Oferta>>, ObtemOfertasPorPeriodoQuerytHandler>();
            services.AddScoped<IRequestHandler<ObtemOfertasQuery, List<Oferta>>, ObtemOfertasQuerytHandler>();

            //Configuracao dos servicos do FluentValidators            
            services.AddValidatorsFromAssembly(typeof(Startup).Assembly);

            //Configuracao integracao dos servicos do Mediator com o FluentValidators
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            /* Configuracao comuns e gerais */
            //Configuracao do servico de autenticacao por JWT 
            services.AddJwtConfiguration(Configuration);
            //Configuracao do servico de fila de mensagens pelo EventBus com RabbitMQ
            services.AddEventBusConfiguration(Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flyers.Api.Ofertas v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
