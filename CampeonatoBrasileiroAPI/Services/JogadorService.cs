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
    public class JogadorService
    {
        private CampeonatoBrasileiroContext _context;
        private IMapper _mapper;

        public JogadorService(CampeonatoBrasileiroContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadJogadorDto Add(CreateJogadorDto jogadorDto)
        {
            Jogador jogador = _mapper.Map<Jogador>(jogadorDto);

            _context.Jogadores.Add(jogador);
            _context.SaveChanges();

            return _mapper.Map<ReadJogadorDto>(jogador);
        }

        public List<ReadJogadorDto> Find()
        {
            List<Jogador> jogadores = _context.Jogadores.ToList();

            if (jogadores != null)
            {
                List<ReadJogadorDto> jogadoresDto = _mapper.Map<List<Jogador>, List<ReadJogadorDto>>(jogadores);
                return jogadoresDto;
            }

            return null;
        }

        public ReadJogadorDto FindById(int id)
        {
            Jogador jogador = _context.Jogadores.FirstOrDefault(jogador => jogador.Id == id);

            if (jogador != null)
            {
                return _mapper.Map<ReadJogadorDto>(jogador);
            }
            
            return null;
        }

        public Result Update(int id, UpdateJogadorDto jogadorDto)
        {
            Jogador jogador = _context.Jogadores.FirstOrDefault(jogador => jogador.Id == id);

            if (jogador == null)
            {
                return Result.Fail("Not Found");
            }

            _mapper.Map(jogadorDto, jogador);
            _context.SaveChanges();

            return Result.Ok();
        }

        internal Result Delete(int id)
        {
            Jogador jogador = _context.Jogadores.FirstOrDefault(jogador => jogador.Id == id);

            if (jogador == null)
            {
                return Result.Fail("Not Found");
            }

            _context.Remove(jogador);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
