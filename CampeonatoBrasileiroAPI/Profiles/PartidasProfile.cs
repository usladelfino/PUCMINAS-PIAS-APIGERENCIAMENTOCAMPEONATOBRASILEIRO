using AutoMapper;
using CampeonatoBrasileiroAPI.Data.Dtos;
using CampeonatoBrasileiroAPI.Models;
using System;
using System.Linq;

namespace CampeonatoBrasileiroAPI.Profiles
{
    public class PartidasProfile : Profile
    {
        public PartidasProfile()
        {
            CreateMap<CreatePartidaDto, Partida>();
            CreateMap<Partida, CreatePartidaDto>();
            CreateMap<UpdatePartidaDto, Partida>();
            CreateMap<Partida, CreatePartidaDto>();
            CreateMap<ReadPartidaDto, Partida>();
            CreateMap<Partida, ReadPartidaDto>()
                .ForMember(partida => partida.Torneio, opts => opts
                    .MapFrom(partida => new { partida.Torneio.Id, partida.Torneio.Serie, partida.Torneio.Ano }))
                .ForMember(partida => partida.TimesParticipantes, opts => opts
                    .MapFrom(partida => partida.TimesParticipantes.Select
                        (timeParticipante => new { time = new { timeParticipante.Time.Id, timeParticipante.Time.Nome, timeParticipante.Time.Localidade }, timeParticipante.Gols, Resultado = Enum.GetName(typeof(Participacao.eResultado), timeParticipante.Resultado) })))
                .ForMember(partida => partida.Eventos, opts => opts
                    .MapFrom(partida => partida.Eventos.Select
                        (evento => new { evento.Id, evento.Tipo, evento.Descricao, evento.DataHora })));

        }
    }
}
