using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVCFilme.Models
{
    public class MVCFilmeContext : DbContext
    {
        public MVCFilmeContext (DbContextOptions<MVCFilmeContext> options)
            : base(options)
        {
        }

        public DbSet<MVCFilme.Models.Filme> Filme { get; set; }
    }
}
