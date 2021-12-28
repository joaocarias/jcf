using Jcf.Dominio.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jcf.Infraestrutura.Contextos
{
    public class AppDBContexto : IdentityDbContext<AppUser>
    {
        public AppDBContexto(DbContextOptions<AppDBContexto> options) : base(options) { }

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcao> Funcaos { get; set; }
        public DbSet<Profissional> Profissionals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //  modelBuilder.Ignore<Notification>();
        }
    }
}
