using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jcf.Infraestrutura.Contextos
{
    public class AppDBContexto : IdentityDbContext
    {
        public AppDBContexto(DbContextOptions<AppDBContexto> options) : base(options) { }
    }
}
