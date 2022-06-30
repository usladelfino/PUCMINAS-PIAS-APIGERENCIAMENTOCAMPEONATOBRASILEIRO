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
    public class TorneioService
    {
        private CampeonatoBrasileiroContext _context;
        private IMapper _mapper;

        public TorneioService(CampeonatoBrasileiroContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadTorneioDto Add(CreateTorneioDto torneioDto)
        {
            Torneio torneio = _mapper.Map<Torneio>(torneioDto);

            _context.Torneios.Add(torneio);
            _context.SaveChanges();

            return _mapper.Map<ReadTorneioDto>(torneio);
        }

        public List<ReadTorneioDto> Find()
        {
            List<Torneio> torneios = _context.Torneios.ToList();

            if (torneios != null)
            {
                List<ReadTorneioDto> torneiosDto = _mapper.Map<List<Torneio>, List<ReadTorneioDto>>(torneios);
                return torneiosDto;
            }

            return null;
        }

        public ReadTorneioDto FindById(int id)
        {
            Torneio torneio = _context.Torneios.FirstOrDefault(torneio => torneio.Id == id);

            if (torneio != null)
            {
                ReadTorneioDto torneioDto = _mapper.Map<ReadTorneioDto>(torneio);

                return torneioDto;
            }
            
            return null;
        }

        public Result Update(int id, UpdateTorneioDto torneioDto)
        {
            Torneio Torneio = _context.Torneios.FirstOrDefault(Torneio => Torneio.Id == id);

            if (Torneio == null)
            {
                return Result.Fail("Not Found");
            }

            _mapper.Map(torneioDto, Torneio);
            _context.SaveChanges();

            return Result.Ok();
        }

        internal Result AddTime(int torneioId, int timeId)
        {
            Torneio torneio = _context.Torneios.FirstOrDefault(torneio => torneio.Id == torneioId);
            Time time = _context.Times.FirstOrDefault(time => time.Id == timeId);

            if (torneio == null || time == null)
            {
                return Result.Fail("Not Found");
            }

            torneio.Times.Add(time);
            _context.SaveChanges();

            return Result.Ok();
        }

        internal Result Delete(int id)
        {
            Torneio Torneio = _context.Torneios.FirstOrDefault(Torneio => Torneio.Id == id);

            if (Torneio == null)
            {
                return Result.Fail("Not Found");
            }

            _context.Remove(Torneio);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
