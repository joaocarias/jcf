using System.ComponentModel.DataAnnotations;

namespace Jcf.Web.Models.Funcao
{
    public class FuncaoViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório")]        
        public string Nome { get; set; }
    }
}
