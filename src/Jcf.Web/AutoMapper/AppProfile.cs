using AutoMapper;
using Jcf.Dominio.Entidades;
using Jcf.Web.Models.Funcao;

namespace Jcf.Web.AutoMapper
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Funcao, FuncaoViewModel>().ReverseMap();
        }
    }
}
