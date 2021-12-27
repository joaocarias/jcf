namespace Jcf.Dominio.Entidades
{
    public class Cliente : EntidadeBase
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Guid? EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

        private Cliente()
        {

        }

        public Cliente(string nome, DateTime dataNascimento, string email, string telefone, Guid? enderecoId, Endereco endereco)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Email = email;
            Telefone = telefone;
            EnderecoId = enderecoId;
            Endereco = endereco;
        }

        public Cliente(string nome, DateTime dataNascimento, string email, string telefone, Guid? enderecoId)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Email = email;
            Telefone = telefone;
            EnderecoId = enderecoId;
        }
    }
}
