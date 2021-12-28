using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Jcf.Dominio.Entidades
{
    public class EntidadeBase
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? UsuarioCriacaoId { get; set; }
        public DateTime? DataCriacao { get; set; } = DateTime.Now;
        public Guid? UsuarioAlteracaoId { get; set; }        
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }

        public bool Ativo { get; set; } = true;

    }
}
