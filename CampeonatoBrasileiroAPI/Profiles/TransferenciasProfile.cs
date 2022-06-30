using AutoMapper;
using CampeonatoBrasileiroAPI.Data.Dtos;
using CampeonatoBrasileiroAPI.Models;
using System.Linq;

namespace CampeonatoBrasileiroAPI.Profiles
{
    public class TransferenciasProfile : Profile
    {
        public TransferenciasProfile()
        {
            CreateMap<CreateTransferenciaDto, Transferencia>();
            CreateMap<Transferencia, CreateTransferenciaDto>();
            CreateMap<ReadTransferenciaDto, Transferencia>();
            CreateMap<Transferencia, ReadTransferenciaDto>()
                .ForMember(transferencia => transferencia.Jogador, opts => opts
                    .MapFrom(transferencia => new { transferencia.Jogador.Id, transferencia.Jogador.Nome, transferencia.Jogador.DataNascimento, transferencia.Jogador.Pais }))
                .ForMember(transferencia => transferencia.TimeOrigem, opts => opts
                        .MapFrom(transferencia => new { transferencia.TimeOrigem.Id, transferencia.TimeOrigem.Nome, transferencia.TimeOrigem.Localidade }))
                .ForMember(transferencia => transferencia.TimeDestino, opts => opts
                        .MapFrom(transferencia => new { transferencia.TimeDestino.Id, transferencia.TimeDestino.Nome, transferencia.TimeDestino.Localidade }));
        }
    }
}
