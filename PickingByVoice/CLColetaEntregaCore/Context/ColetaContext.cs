using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLColetaEntregaCore.Context
{
    public class ColetaContext : DbContext
    {
        public ColetaContext(DbContextOptions<ColetaContext> options)
            : base(options)
        {
        }

        public DbSet<ColetaContext> TodoItems { get; set; }
    }
}