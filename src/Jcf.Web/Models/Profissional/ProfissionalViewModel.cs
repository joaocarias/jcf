using Jcf.Web.Models.Endereco;
using Jcf.Web.Models.Funcao;
using System.ComponentModel.DataAnnotations;
using Jcf.Dominio.Uteis;

namespace Jcf.Web.Models.Profissional
{
    public class ProfissionalViewModel : EntidadeBaseViewModel
    {
        [Required(ErrorMessage = ConstantesStrings.MENSAGEM_CAMPO_OBRIGATORIO)]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "E-Mail")]
    	[DataType(DataType.EmailAddress, ErrorMessage = ConstantesStrings.MENSAGEM_EMAIL_INVALIDO)]
        public string Email { get; set; }

        public string Telefone { get; set; }

        [Required(ErrorMessage = ConstantesStrings.MENSAGEM_CAMPO_OBRIGATORIO)]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        public Guid? EnderecoId { get; set; }

        public EnderecoViewModel? Endereco { get; set; }

        [Required(ErrorMessage = ConstantesStrings.MENSAGEM_CAMPO_OBRIGATORIO)]
        [Display(Name = "Função")]
        public Guid FuncaoId { get; set; }

        public FuncaoViewModel? Funcao { get; set; }      

    }
}
