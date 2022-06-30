using AutoMapper;
using CampeonatoBrasileiroAPI.Data.Dtos;
using CampeonatoBrasileiroAPI.Models;
using System.Linq;

namespace CampeonatoBrasileiroAPI.Profiles
{
    public class EventosProfile : Profile
    {
        public EventosProfile()
        {
            CreateMap<CreateEventoDto, Evento>();
            CreateMap<Evento, CreateEventoDto>();
            CreateMap<ReadEventoDto, Evento>();
            CreateMap<Evento, ReadEventoDto>();
        }
    }
}
