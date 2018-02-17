using Microsoft.EntityFrameworkCore;
using TestePostgres.Entities;

namespace TestePostgres.Data
{
    public class MyDbContext : DbContext
    {
        // Criação muito simples do contexto, poderia ser feito o mapeamento através
        // do método OnModelCreating
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        // poderia mapear aqui, inclusive GUID
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
