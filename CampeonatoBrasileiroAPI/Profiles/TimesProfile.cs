using AutoMapper;
using CampeonatoBrasileiroAPI.Data.Dtos;
using CampeonatoBrasileiroAPI.Models;
using System.Linq;

namespace CampeonatoBrasileiroAPI.Profiles
{
    public class TimesProfile : Profile
    {
        public TimesProfile()
        {
            CreateMap<CreateTimeDto, Time>();
            CreateMap<Time, CreateTimeDto>();
            CreateMap<UpdateTimeDto, Time>();
            CreateMap<Time, UpdateTimeDto>();
            CreateMap<ReadTimeDto, Time>();
            CreateMap<Time, ReadTimeDto>()
                .ForMember(time => time.Jogadores, opts => opts
                    .MapFrom(time => time.Jogadores.Select
                        (jogador => new { jogador.Id, jogador.Nome, jogador.DataNascimento, jogador.Pais })));
        }
    }
}
