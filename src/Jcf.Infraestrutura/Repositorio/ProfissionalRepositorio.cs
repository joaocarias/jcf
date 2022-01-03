using Jcf.Dominio.Entidades;
using Jcf.Dominio.IRepositorio;
using Jcf.Infraestrutura.Contextos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jcf.Infraestrutura.Repositorio
{
    public class ProfissionalRepositorio : IProfissionalRepositorio
    {
        private readonly AppDBContexto _contexto;

        public ProfissionalRepositorio(AppDBContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Profissional> AdicionarAsync(Profissional entity)
        {
            try
            {
                await _contexto.Profissionals.AddAsync(entity);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }

            return entity;
        }

        public async Task<Profissional> ApagarAsync(Profissional entity)
        {
            try
            {
                _contexto.Profissionals.Update(entity);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex) { }

            return entity;
        }

        public async Task<Profissional> AtualizarAsync(Profissional entity)
        {
            try
            {
                _contexto.Profissionals.Update(entity);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex) { }

            return entity;
        }

        public Profissional? Obter(Guid id)
        {
            try
            {
                var entidade = _contexto.Profissionals.Include(x => x.Funcao).Include(x => x.Endereco).Where(x => x.Id.Equals(id) && x.Ativo.Equals(true)).FirstOrDefault();
                return entidade;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Profissional>? ObteTodos()
        {
            try
            {
                var lista = _contexto.Profissionals.Include(x => x.Funcao).Include(x => x.Endereco).Where(x => x.Ativo.Equals(true)).ToList();
                return lista;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
