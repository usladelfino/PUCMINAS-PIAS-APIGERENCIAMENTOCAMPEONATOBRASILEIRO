using AutoMapper;
using CampeonatoBrasileiroAPI.Data.Dtos;
using CampeonatoBrasileiroAPI.Models;
using System.Linq;

namespace CampeonatoBrasileiroAPI.Profiles
{
    public class ParticipacoesProfile : Profile
    {
        public ParticipacoesProfile()
        {
            CreateMap<CreateParticipacaoDto, Participacao>();
            CreateMap<Participacao, CreateParticipacaoDto>();
            CreateMap<UpdateParticipacaoDto, Participacao>();
            CreateMap<Participacao, UpdateParticipacaoDto>();
            CreateMap<ReadParticipacaoDto, Participacao>();
            CreateMap<Participacao, ReadParticipacaoDto>()
                 .ForMember(participacao => participacao.Partida, opts => opts
                    .MapFrom(participacao => new { participacao.Partida.Id, participacao.Partida.Data, participacao.Partida.Local }))
                 .ForMember(participacao => participacao.Time, opts => opts
                    .MapFrom(participacao => new { participacao.Time.Id, participacao.Time.Nome, participacao.Time.Localidade }));
        }
    }
}
