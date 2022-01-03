using AutoMapper;
using Jcf.Dominio.Entidades;
using Jcf.Web.Models.Endereco;
using Jcf.Web.Models.Funcao;
using Jcf.Web.Models.Profissional;

namespace Jcf.Web.AutoMapper
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Funcao, FuncaoViewModel>().ReverseMap();
            CreateMap<Profissional, ProfissionalViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
        }
    }
}
