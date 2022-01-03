using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Jcf.Dominio.Entidades
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cpf { get; set; }
    }
}
