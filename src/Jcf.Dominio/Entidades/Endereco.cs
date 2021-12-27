

namespace Jcf.Dominio.Entidades
{
    public class Endereco : EntidadeBase
    {
        private Endereco()
        {
           
        }

        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Obs { get; set; }


        public Endereco(string cep, string logradouro, string numero, string complemento, string bairro, string cidade, string uF, string obs)
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            UF = uF;
            Obs = obs;
        }
    }
}
