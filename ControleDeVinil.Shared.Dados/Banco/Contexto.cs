using ControleDeVinil.Shared.Modelos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ControleDeVinil.Shared.Dados.Banco
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions options) : base(options) { }
        public DbSet<Produtor> Produtores { get; private set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
	}
}
