using Flyers.Core.Interfaces.DataRepositories;
using Flyers.Core.Interfaces.DataServices;
using Flyers.Core.Services.ApiServices;
using Flyers.Core.Services.DataServices;
using Flyers.Core.Settings;
using Flyers.Data.Contexts;
using Flyers.Data.Repositories.DataRepositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Polly;
using Refit;
using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using WebMarkupMin.AspNetCore5;

namespace Flyers.Web
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
            //Configuracao default para uma aplicacao Asp.Net MVC
            services.AddControllersWithViews();

            //Configuracoes do Newtonsoft.Json
            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddRazorPages()
                .AddNewtonsoftJson();

            //Configuracao da serializacao json nas controllers para as views com Newtonsoft.Json
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                {
                    //options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            //Configuracao dos Default Error Messages
            services.AddRazorPages()
                .AddMvcOptions(options =>
                {
                    options.MaxModelValidationErrors = 50;
                    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(_ => "Formato inválido");
                    options.ModelBindingMessageProvider
                        .SetAttemptedValueIsInvalidAccessor((_, __) => "Formato inválido");
                });

            //Configuracao das rotas
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
                //options.AppendTrailingSlash = true;
            });

            //Configuracao de cultura pt-BR
            var cultureInfo = new CultureInfo("pt-BR");
            cultureInfo.NumberFormat.CurrencySymbol = "R$";
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            //Configuracao do banco de dados
            //MSSQLServer
            //var connection = Configuration["ConnectionStrings:SqlServerConnectionString"];
            //services.AddDbContext<DadosDbContext>(options =>
            //    options.UseSqlServer(connection)
            //);
            //SQLite
            //Dev
            var connection = Configuration["ConnectionStrings:SqliteConnectionString"];
            services.AddDbContext<DadosDbContext>(options =>
                options.UseSqlite(connection)
            );
            //Deploy
            //services.AddDbContext<DadosContext>(options =>
            //    options.UseSqlite(Configuration.GetConnectionString("SqliteConnectionString"))
            //);

            //Configuracao do serviço de autenticação por cookies
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })

            //Configuracao do cookie de autenticacao do usuario
            .AddCookie(options => 
            {
                options.LoginPath = "/conta";
                options.LogoutPath = "/conta/finaliza";
            });

            //Configuracao de Sessions distribuidas no cliente
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;  //nao permite acesso js no cliente
                options.Cookie.Name = $".{Guid.NewGuid()}"; //nome cookie
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // so habilita se https
                options.IdleTimeout = TimeSpan.FromMinutes(10); //tempo de duracao
            });

            //Configuracao dos servicos de banco de dados
            //AddScoped = unica instancia por cliente
            //AddSingleton = unica instancia no servidor
            //AddTransient = novas instancias a cada requisicao servidor/cliente
            //Configuracao das requisicoes HTTP para as classes que nao sao BaseController
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Configuracao dos servicos dos repositorios de banco de dados     
            services.AddScoped<IDataRepository, DataRepository>();
            services.AddScoped<IUsuarioDataService, UsuarioDataService>();
            services.AddScoped<IArquivoDataService, ArquivoDataService>();
            services.AddScoped<IDominioDataService, DominioDataService>();
            services.AddScoped<IEnderecoDataService, EnderecoDataService>();
            services.AddScoped<ICategoriaDataService, CategoriaDataService>();
            services.AddScoped<IProdutoDataService, ProdutoDataService>();
            services.AddScoped<IOfertaDataService, OfertaDataService>();
            services.AddScoped<IOfertaProdutoDataService, OfertaProdutoDataService>();
            services.AddScoped<IRedeSocialDataService, RedeSocialDataService>();

            //Configuracao dos servicos das Apis com Polly e Refit
            var regraTimeout = Policy.TimeoutAsync<HttpResponseMessage>(10);
            //Configuracao do servicos de api pelo Refit            
            //services.AddRefitClient<IBaseApiService>()
            //    .ConfigureHttpClient(client =>
            //    {
            //        client.BaseAddress = new Uri(AppSettings.BaseAPI);
            //        client.DefaultRequestHeaders.Add("Accept", "application/json");
            //        client.DefaultRequestHeaders.Add("X-API-KEY", AppSettings.ChaveAPI);
            //    });
            //Nova tentativa em caso de erro
            //.AddPolicyHandler((provider, request) =>
            //{
            //    return Policy.HandleResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.Unauthorized)
            //        .RetryAsync(1, (response, retryCount, context) =>
            //        {
            //            var client = provider.GetRequiredService<IAutenticacaoService>();
            //        });
            //});

            services.AddRefitClient<IViacepApiService>()
                .ConfigureHttpClient(client =>
                {
                    client.BaseAddress = new Uri(AppsSetting.UriViacepApi);
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                });

            //Configuracao dos minificacação das paginas
            services.AddWebMarkupMin(options =>
                {
                    options.AllowMinificationInDevelopmentEnvironment = false;
                    options.AllowCompressionInDevelopmentEnvironment = false;
                })
                .AddHtmlMinification(options => 
                {
                    options.MinificationSettings.RemoveRedundantAttributes = true;
                    options.MinificationSettings.RemoveHttpProtocolFromAttributes = true;
                    options.MinificationSettings.RemoveHttpsProtocolFromAttributes = true;
                
                })
                .AddHttpCompression();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Habilitando minificacao
            app.UseWebMarkupMin();
            // Habilitando a cultura padrão: pt-BR
            var supportedCultures = new[] { new CultureInfo("pt-BR") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            //Default
            app.UseHttpsRedirection();            
            app.UseRouting();
            
            //Habilitando autenticacao e autorizacao => obs. deve estar apos .UseRouting()
            app.UseAuthentication();
            app.UseAuthorization();
            
            //Habilitando Sessions
            app.UseSession();
            //app.Use(async (context, next) =>
            //{
            //    context.Session.SetObject("configuracao", new { Webapp = 1, Parametro1 = "Parametro1" });
            //    await next();
            //});
            
            //Habilitando uso de arquivos estaticos
            app.UseStaticFiles();
            //Definindo as pasta de arquivos
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(
                    Directory.GetCurrentDirectory(),
                    @"wwwroot\assets")),
                RequestPath = new PathString("/assets")
            });
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(
            //        Directory.GetCurrentDirectory(),
            //        @"wwwroot\files")),
            //    RequestPath = new PathString("/files")
            //});
            
            //Definindo as rotas
            app.UseEndpoints(endpoints =>
            {
                //rotas por Areas
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    //pattern: "{controller=Home}/{action=Index}/{id?}");
                    //suporte para SEO
                    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");
            });
        }
    }
}
