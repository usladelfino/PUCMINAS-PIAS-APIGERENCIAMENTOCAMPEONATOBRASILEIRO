using CampeonatoBrasileiroAPI.Data.Dtos;
using CampeonatoBrasileiroAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CampeonatoBrasileiroAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TimesController : ControllerBase
    {

        private TimeService _timeService;

        public TimesController(TimeService timeService)
        {
            _timeService = timeService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Post([FromBody] CreateTimeDto timeDto)
        {
            ReadTimeDto readTimeDto = _timeService.Add(timeDto);
            
            return CreatedAtAction(nameof(GetById), new { readTimeDto.Id }, readTimeDto);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IEnumerable<ReadTimeDto> Get()
        {
            return _timeService.Find();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult GetById(int id)
        {
            ReadTimeDto readTimeDto = _timeService.FindById(id);
            
            if (readTimeDto != null)
            {
                return Ok(readTimeDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Put(int id, [FromBody] UpdateTimeDto timeDto)
        {
            Result result = _timeService.Update(id, timeDto);
            
            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
