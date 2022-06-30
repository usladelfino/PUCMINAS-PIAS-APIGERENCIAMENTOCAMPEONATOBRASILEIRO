using AutoMapper;
using CampeonatoBrasileiroAPI.Data;
using CampeonatoBrasileiroAPI.Data.Dtos;
using CampeonatoBrasileiroAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoBrasileiroAPI.Services
{
    public class PartidaService
    {
        private CampeonatoBrasileiroContext _context;
        private IMapper _mapper;

        public PartidaService(CampeonatoBrasileiroContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadPartidaDto Add(int torneioId, CreatePartidaDto partidaDto)
        {
            Partida partida = _mapper.Map<Partida>(partidaDto);
            Torneio torneio = _context.Torneios.FirstOrDefault(torneio => torneio.Id == torneioId);

            if (torneio == null)
            {
                return null;
            }

            partida.TorneioId = torneioId;
            _context.Partidas.Add(partida);
            _context.SaveChanges();

            return _mapper.Map<ReadPartidaDto>(partida);
        }

        public ReadPartidaDto FindById(int id)
        {
            Partida partida = _context.Partidas.FirstOrDefault(partida => partida.Id == id);

            if (partida != null)
            {
                ReadPartidaDto partidaDto = _mapper.Map<ReadPartidaDto>(partida);

                return partidaDto;
            }

            return null;
        }
    }
}
