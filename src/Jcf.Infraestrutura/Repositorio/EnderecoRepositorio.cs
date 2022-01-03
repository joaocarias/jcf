using Jcf.Dominio.Entidades;
using Jcf.Dominio.IRepositorio;
using Jcf.Infraestrutura.Contextos;

namespace Jcf.Infraestrutura.Repositorio
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        private readonly AppDBContexto _contexto;

        public EnderecoRepositorio(AppDBContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Endereco> AdicionarAsync(Endereco entity)
        {
            try
            {
                await _contexto.Enderecos.AddAsync(entity);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }

            return entity;
        }

        public async Task<Endereco> ApagarAsync(Endereco entity)
        {
            try
            {
                _contexto.Enderecos.Update(entity);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex) { }

            return entity;
        }

        public async Task<Endereco> AtualizarAsync(Endereco entity)
        {
            try
            {
                _contexto.Enderecos.Update(entity);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex) { }

            return entity;
        }

        public Endereco? Obter(Guid id)
        {
            try
            {
                var entidade = _contexto.Enderecos.Where(x => x.Id.Equals(id) && x.Ativo.Equals(true)).FirstOrDefault();
                return entidade;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Endereco>? ObteTodos()
        {
            try
            {
                var lista = _contexto.Enderecos.Where(x => x.Ativo.Equals(true)).ToList();
                return lista;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
