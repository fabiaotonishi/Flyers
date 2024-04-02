using Flyers.Api.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyers.Api.Configurations
{
    public static class JwtConfiguration
    {
        public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //Configuracao do servico de autenticacao por JWT
            var configuracaoAppSettings = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(configuracaoAppSettings);

            var appSettings = configuracaoAppSettings.Get<AppSettings>();
            var tokenKey = Encoding.UTF8.GetBytes(appSettings.Chave);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                bearerOptions.RequireHttpsMetadata = true; //forca https
                bearerOptions.SaveToken = true; //armazena o token
                bearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true, //autentica por chave (assinatura)
                    IssuerSigningKey = new SymmetricSecurityKey(tokenKey), //chave criptografada
                    ValidateIssuer = true, //verifica emissores
                    ValidateAudience = true, //verifica audiencias
                    ValidAudience = appSettings.ValidoEm, //audiencias validas
                    ValidIssuer = appSettings.Emissor //emissor valido
                };
            });
        }
    }
}
