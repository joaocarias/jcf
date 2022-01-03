using Jcf.Dominio.Entidades;
using Jcf.Dominio.IRepositorio;
using Jcf.Infraestrutura.Contextos;

namespace Jcf.Infraestrutura.Repositorio
{
    public class FuncaoRepositorio : IFuncaoRepositorio
    {
        private readonly AppDBContexto _contexto;

        public FuncaoRepositorio(AppDBContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Funcao> AdicionarAsync(Funcao entity)
        {
            try
            {
                await _contexto.Funcaos.AddAsync(entity);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }

            return entity;
        }

        public async Task<Funcao> ApagarAsync(Funcao entity)
        {
            try
            {
                _contexto.Funcaos.Update(entity);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex) { }

            return entity;
        }

        public async Task<Funcao> AtualizarAsync(Funcao entity)
        {
            try
            {
                _contexto.Funcaos.Update(entity);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex) { }
            
            return entity;
        }

        public Funcao? Obter(Guid id)
        {
            try
            {
                var funcao = _contexto.Funcaos.Where(x => x.Id.Equals(id) && x.Ativo.Equals(true)).FirstOrDefault();
                return funcao;
            }
            catch (Exception e)
            {
                return null;
            }            
        }

        public List<Funcao>? ObteTodos()
        {
            try
            {
                var funcoes = _contexto.Funcaos.Where(x => x.Ativo.Equals(true)).ToList();
                return funcoes;
            }catch (Exception e)
            {
                return null;
            }            
        }
    }
}
