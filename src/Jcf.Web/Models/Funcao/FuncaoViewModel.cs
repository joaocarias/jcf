using System.ComponentModel.DataAnnotations;
using Jcf.Dominio.Uteis;

namespace Jcf.Web.Models.Funcao
{
    public class FuncaoViewModel : EntidadeBaseViewModel
    {
        [Required(ErrorMessage = ConstantesStrings.MENSAGEM_CAMPO_OBRIGATORIO)]        
        public string Nome { get; set; }
    }
}
