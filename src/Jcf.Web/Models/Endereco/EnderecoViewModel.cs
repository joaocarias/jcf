using System.ComponentModel.DataAnnotations;

namespace Jcf.Web.Models.Endereco
{
    public class EnderecoViewModel : EntidadeBaseViewModel
    {
        [Display(Name = "CEP")]
        public string Cep { get; set; }
        
        public string Logradouro { get; set; }

        [Display(Name = "Nº")]
        public string Numero { get; set; }

        public string Complemento { get; set; }
        
        public string Bairro { get; set; }
        
        public string Cidade { get; set; }

        [Display(Name = "UF")]
        public string Uf { get; set; }

        [Display(Name = "Observação")]
        public string Obs { get; set; }
    }
}
