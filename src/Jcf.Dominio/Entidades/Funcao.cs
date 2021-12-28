using System.ComponentModel.DataAnnotations;

namespace Jcf.Dominio.Entidades
{
    public class Funcao : EntidadeBase
    {
        [Required]
        public string Nome { get; set; } 
    }
}
