using AutoMapper;
using Aplicacoes.Application.Dtos;
using Aplicacoes.Domain;

namespace Aplicacoes.Application.Helpers
{
    public class AplicacoesProfile : Profile
    {
        public AplicacoesProfile(){
            CreateMap<Papel, PapelDto>().ReverseMap();
            CreateMap<MovimentoDia, MovimentoDiaDto>().ReverseMap();
            CreateMap<CompraVendaAcao, CompraVendaAcaoDto>().ReverseMap()
            .ForMember(c => c.IdPapel, opt => opt.MapFrom(d => d.IdPapel));
        }        
    }
}

