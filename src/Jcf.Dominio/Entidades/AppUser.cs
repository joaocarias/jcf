using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jcf.Dominio.Entidades
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cpf { get; set; }
                
        public Guid? EnderecoId { get; set; }

        [ForeignKey(nameof(EnderecoId))]
        public Endereco? Endereco { get; set; }
    }
}
