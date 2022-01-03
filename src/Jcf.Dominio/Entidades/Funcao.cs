using System.ComponentModel.DataAnnotations;

namespace Jcf.Dominio.Entidades
{
    public class Funcao : EntidadeBase
    {
        [Required]
        public string Nome { get; set; }

        public void Atualizar(string nome, Guid usuarioId)
        {
            Nome = nome;
            DataAlteracao = DateTime.Now;
            UsuarioAlteracaoId = usuarioId;
        }
    }
}
