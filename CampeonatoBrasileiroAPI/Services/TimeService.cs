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
    public class TimeService
    {
        private CampeonatoBrasileiroContext _context;
        private IMapper _mapper;

        public TimeService(CampeonatoBrasileiroContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadTimeDto Add(CreateTimeDto timeDto)
        {
            Time time = _mapper.Map<Time>(timeDto);

            _context.Times.Add(time);
            _context.SaveChanges();

            return _mapper.Map<ReadTimeDto>(time);
        }

        public List<ReadTimeDto> Find()
        {
            List<Time> times = _context.Times.ToList();

            if (times != null)
            {
                List<ReadTimeDto> timesDto = _mapper.Map<List<Time>, List<ReadTimeDto>>(times);
                return timesDto;
            }

            return null;
        }

        public ReadTimeDto FindById(int id)
        {
            Time time = _context.Times.FirstOrDefault(time => time.Id == id);

            if (time != null)
            {
                ReadTimeDto timeDto = _mapper.Map<ReadTimeDto>(time);

                return timeDto;
            }
            
            return null;
        }

        public Result Update(int id, UpdateTimeDto timeDto)
        {
            Time time = _context.Times.FirstOrDefault(time => time.Id == id);

            if (time == null)
            {
                return Result.Fail("Not Found");
            }

            _mapper.Map(timeDto, time);
            _context.SaveChanges();

            return Result.Ok();
        }


    }
}
