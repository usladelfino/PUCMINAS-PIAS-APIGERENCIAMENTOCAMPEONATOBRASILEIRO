using AutoMapper;
using CampeonatoBrasileiroAPI.Data.Dtos;
using CampeonatoBrasileiroAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoBrasileiroAPI.Profiles
{
    public class JogadoresProfile : Profile
    {
        public JogadoresProfile()
        {
            CreateMap<CreateJogadorDto, Jogador>();
            CreateMap<Jogador, CreateJogadorDto>();
            CreateMap<UpdateJogadorDto, Jogador>();
            CreateMap<Jogador, UpdateJogadorDto>();
            CreateMap<ReadJogadorDto, Jogador>();
            CreateMap<Jogador, ReadJogadorDto>()
                .ForMember(jogador => jogador.Time, opts => opts
                    .MapFrom(jogador => new { jogador.Time.Id, jogador.Time.Nome, jogador.Time.Localidade }))
                .ForMember(jogador => jogador.Transferencias, opts => opts
                    .MapFrom(jogador => jogador.Transferencias.Select
                    (transferencia => new { transferencia.Id, timeOrigem = new { transferencia.TimeOrigem.Id, transferencia.TimeOrigem.Nome, transferencia.TimeOrigem.Localidade }, timeDestino = new { transferencia.TimeDestino.Id, transferencia.TimeDestino.Nome, transferencia.TimeDestino.Localidade }, transferencia.Data, transferencia.Valor })));
        }
    }
}
