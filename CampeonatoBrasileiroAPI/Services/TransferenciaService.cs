using AutoMapper;
using CampeonatoBrasileiroAPI.Data;
using CampeonatoBrasileiroAPI.Data.Dtos;
using CampeonatoBrasileiroAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoBrasileiroAPI.Services
{
    public class TransferenciaService
    {
        private CampeonatoBrasileiroContext _context;
        private IMapper _mapper;

        public TransferenciaService(CampeonatoBrasileiroContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadTransferenciaDto Add(CreateTransferenciaDto transferenciaDto)
        {
            Transferencia transferencia = _mapper.Map<Transferencia>(transferenciaDto);
            Jogador jogador = _context.Jogadores.FirstOrDefault(jogador => jogador.Id == transferencia.JogadorId);
            Time timeDestino = _context.Times.FirstOrDefault(time => time.Id == transferencia.TimeDestinoId);

            jogador.Time = timeDestino;

            _context.Transferencias.Add(transferencia);
            _context.SaveChanges();

            return _mapper.Map<ReadTransferenciaDto>(transferencia);
        }

        public IEnumerable<ReadTransferenciaDto> Find()
        {
            List<Transferencia> transferencias = _context.Transferencias.ToList();
            List<ReadTransferenciaDto> transferenciasDto = _mapper.Map<List<Transferencia>, List<ReadTransferenciaDto>>(transferencias);

            return transferenciasDto;
        }

        public ReadTransferenciaDto FindById(int id)
        {
            Transferencia transferencia = _context.Transferencias.FirstOrDefault(transferencia => transferencia.Id == id);

            if (transferencia != null)
            {
                ReadTransferenciaDto transferenciaDto = _mapper.Map<ReadTransferenciaDto>(transferencia);

                return transferenciaDto;
            }

            return null;
        }
    }
}
