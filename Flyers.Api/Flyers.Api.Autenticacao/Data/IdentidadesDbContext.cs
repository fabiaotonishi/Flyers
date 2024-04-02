using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flyers.Api.Autenticacao.Data
{
    public class IdentidadesDbContext : IdentityDbContext
    {
        public IdentidadesDbContext(DbContextOptions<IdentidadesDbContext> options)
            : base(options)
        {
        }
    }
}
