using Jcf.Dominio.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jcf.Infraestrutura.Contextos
{
    public class AppDBContexto : IdentityDbContext
    {
        public AppDBContexto(DbContextOptions<AppDBContexto> options) : base(options) { }

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          //  modelBuilder.Ignore<Notification>();
        }
    }
}
