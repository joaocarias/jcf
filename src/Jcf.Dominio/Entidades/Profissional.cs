using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jcf.Dominio.Entidades
{
    public class Profissional : EntidadeBase
    {
        [Required]
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Guid? EnderecoId { get; set; }

        [ForeignKey(nameof(EnderecoId))]
        public Endereco? Endereco { get; set; }

        public Guid FuncaoId { get; set; }

        [ForeignKey(nameof(FuncaoId))]
        public Funcao Funcao { get; set; }
    }
}
