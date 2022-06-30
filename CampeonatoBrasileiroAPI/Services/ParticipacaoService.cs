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
    public class ParticipacaoService
    {
        private CampeonatoBrasileiroContext _context;
        private IMapper _mapper;

        public ParticipacaoService(CampeonatoBrasileiroContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadParticipacaoDto Add(int torneioId, int partidaId, CreateParticipacaoDto participacaoDto)
        {
            Participacao participacao = _mapper.Map<Participacao>(participacaoDto);
            Partida partida = _context.Partidas.FirstOrDefault(partida => partida.Id == partidaId && partida.TorneioId == torneioId);

            if (partida == null)
            {
                return null;
            }

            participacao.PartidaId = partidaId;

            _context.Participacoes.Add(participacao);
            _context.SaveChanges();

            return _mapper.Map<ReadParticipacaoDto>(participacao);
        }

        public ReadParticipacaoDto FindById(int id)
        {
            Participacao participacao = _context.Participacoes.FirstOrDefault(participacao => participacao.Id == id);

            if (participacao == null)
            {
                return null;
            }

            return _mapper.Map<ReadParticipacaoDto>(participacao);
        }

        public Result Update(int torneioId, int partidaId, int participacaoId, UpdateParticipacaoDto participacaoDto)
        {
            Partida partida = _context.Partidas.FirstOrDefault(partida => partida.Id == partidaId && partida.TorneioId == torneioId);

            if (partida == null)
            {
                return Result.Fail("Partida não encontrada");
            }

            Participacao participacao = _context.Participacoes.FirstOrDefault(participacao => participacao.Id == participacaoId && participacao.PartidaId == partidaId);

            if (participacao == null)
            {
                return Result.Fail("Participação não encontrada");
            }

            _mapper.Map(participacaoDto, participacao);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
