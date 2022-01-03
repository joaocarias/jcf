

namespace Jcf.Dominio.Entidades
{
    public class Endereco : EntidadeBase
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Obs { get; set; }

        public void Atualziar(string cep, string logradouro, string numero, string complemento, string bairro, string cidade, string uf, string obs, Guid usuarioId)
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
            Obs = obs;

            UsuarioAlteracaoId = usuarioId;
            DataAlteracao = DateTime.Now;
        }
    }
}
