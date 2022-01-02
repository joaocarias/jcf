using System.ComponentModel.DataAnnotations;

namespace Jcf.Web.Models
{
    public class EntidadeBaseViewModel
    {
        public Guid Id { get; set; }
        public Guid? UsuarioCriacaoId { get; set; }
        public DateTime? DataCriacao { get; set; } 
        public Guid? UsuarioAlteracaoId { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }

        public bool Ativo { get; set; } = true;

        public void SetNovo(Guid? usuarioCriacaoId)
        {
            UsuarioCriacaoId = usuarioCriacaoId;
            Ativo = true;
            DataCriacao = DateTime.Now;
        }

        public void SetAlteracao(Guid? usuarioAlteracaoId)
        {
            UsuarioAlteracaoId = usuarioAlteracaoId;
            DataAlteracao = DateTime.Now;
        }
    }
}
