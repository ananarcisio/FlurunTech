using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InVents.Models;

namespace InVents.Data
{
    public class InVentsContext : DbContext
    {
        public InVentsContext (DbContextOptions<InVentsContext> options)
            : base(options)
        {
        }

        public DbSet<InVents.Models.Empresa> Empresa { get; set; } = default!;
        public DbSet<InVents.Models.Evento> Evento { get; set; } = default!;
        public DbSet<InVents.Models.Fornecedor> Fornecedor { get; set; } = default!;
        public DbSet<InVents.Models.Nota> Nota { get; set; } = default!;
        public DbSet<InVents.Models.Produtor> Produtor { get; set; } = default!;

    }
}
