using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyers.Api.Authorizations
{
    public static class ClaimsAuthorization
    {
        //autorizacao customizadas por Claims 
        public static bool ValidaClaimUsuario(HttpContext context, string claimName, string claimValue)
        {
            return
                context.User.Identity.IsAuthenticated && 
                context.User.Claims.Any(c => c.Type == claimName && c.Value.Contains(claimValue));
        }
    }
}
