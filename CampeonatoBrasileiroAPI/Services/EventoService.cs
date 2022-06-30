using AutoMapper;
using CampeonatoBrasileiroAPI.Data;
using CampeonatoBrasileiroAPI.Data.Dtos;
using CampeonatoBrasileiroAPI.Messenger;
using CampeonatoBrasileiroAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoBrasileiroAPI.Services
{
    public class EventoService
    {
        private CampeonatoBrasileiroContext _context;
        private IMapper _mapper;
        private readonly IMessageProducer _messagePublisher;

        public EventoService(CampeonatoBrasileiroContext context, IMapper mapper, IMessageProducer messagePublisher)
        {
            _context = context;
            _mapper = mapper;
            _messagePublisher = messagePublisher;
        }

        public ReadEventoDto Add(int torneioId, int partidaId, eEvento tipo, CreateEventoDto eventoDto)
        {
            Partida partida = _context.Partidas.FirstOrDefault(partida => partida.Id == partidaId && partida.TorneioId == torneioId);

            if (partida == null)
            {
                return null;
            }

            Evento evento = _mapper.Map<Evento>(eventoDto);
            evento.Tipo = tipo;
            evento.PartidaId = partidaId;

            _context.Eventos.Add(evento);
            _context.SaveChanges();

            ReadEventoDto readEventoDto = _mapper.Map<ReadEventoDto>(evento);

            _messagePublisher.SendMessage(readEventoDto);

            return readEventoDto;
        }

        public ReadEventoDto FindById(int id)
        {
            Evento evento = _context.Eventos.FirstOrDefault(evento => evento.Id == id);

            if (evento != null)
            {
                ReadEventoDto eventoDto = _mapper.Map<ReadEventoDto>(evento);

                return eventoDto;
            }

            return null;
        }
    }
}
