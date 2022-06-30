using AutoMapper;
using CampeonatoBrasileiroAPI.Data.Dtos;
using CampeonatoBrasileiroAPI.Models;
using System;
using System.Linq;

namespace CampeonatoBrasileiroAPI.Profiles
{
    public class TorneiosProfile : Profile
    {
        public TorneiosProfile()
        {
            CreateMap<CreateTorneioDto, Torneio>();
            CreateMap<Torneio, CreateTorneioDto>();
            CreateMap<UpdateTorneioDto, Torneio>();
            CreateMap<Torneio, UpdateTorneioDto>();
            CreateMap<ReadTorneioDto, Torneio>();
            CreateMap<Torneio, ReadTorneioDto>()
                .ForMember(torneio => torneio.Times, opts => opts
                    .MapFrom(torneio => torneio.Times.Select
                        (time => new { time.Id, time.Nome, time.Localidade })))
                .ForMember(torneio => torneio.Partidas, opts => opts
                    .MapFrom(torneio => torneio.Partidas.Select
                        (partida => new {partida.Id, partida.Data, partida.Local, timesParticipantes = partida.TimesParticipantes.Select(t => new { t.Time, t.Gols, Resultado = Enum.GetName(typeof(Participacao.eResultado), t.Resultado) }).ToList()})));
        }
    }
}
