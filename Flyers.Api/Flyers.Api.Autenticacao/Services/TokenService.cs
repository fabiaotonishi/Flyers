using Flyers.Api.Autenticacao.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Flyers.Api.Autenticacao.Services
{
    public static class TokenService
    {
        public static string ObtemTokenAcesso(
                   string chave,
                   string emissor,
                   string validoEm,
                   ClaimsIdentity usuarioCredenciais,
                   int expiracaoHoras = 2)
        {
            //define o token de autenticacao do usuario
            var tokenKey = Encoding.UTF8.GetBytes(chave);
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = emissor,
                Audience = validoEm,
                Subject = usuarioCredenciais,
                Expires = DateTime.UtcNow.AddHours(expiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            });
            return tokenHandler.WriteToken(token);
        }

        public static ClaimsIdentity ObtemCredenciaisJwt(UsuarioConta usuarioConta)
        {
            //adiciona as credenciais do usuario (claims)
            var crendeciais = new List<Claim>();
            crendeciais.Add(new Claim(JwtRegisteredClaimNames.Sub, usuarioConta.Id));
            crendeciais.Add(new Claim(JwtRegisteredClaimNames.Email, usuarioConta.Email));
            crendeciais.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            crendeciais.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString())); //quando vai expirar
            crendeciais.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64)); //quando foi emitido
            //adiciona todas as permissoes
            if (usuarioConta.Permissoes.Count > 0)
            {
                foreach (var role in usuarioConta.Permissoes)
                {
                    crendeciais.Add(new Claim("role", role));
                }
            }

            //define as credenciais do usuario
            var usuarioCredenciaisJwt = new ClaimsIdentity();
            usuarioCredenciaisJwt.AddClaims(crendeciais);
            return usuarioCredenciaisJwt;
        }

        private static long ToUnixEpochDate(DateTime date)
        {
            return (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
        }

    }
}
