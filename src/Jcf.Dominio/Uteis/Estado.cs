namespace Jcf.Dominio.Uteis
{
    public class Estado
    {
        public string Sigla { get; private set; }
        public string Descricao { get; private set; }

        public Estado(string sigla, string descricao)
        {
            Sigla = sigla;
            Descricao = descricao;
        }
    }
}
