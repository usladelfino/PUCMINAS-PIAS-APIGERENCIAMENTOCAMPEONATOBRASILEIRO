using AutoMapper;
using CampeonatoBrasileiroAPI.Data;
using CampeonatoBrasileiroAPI.Data.Dtos;
using CampeonatoBrasileiroAPI.Models;
using CampeonatoBrasileiroAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CampeonatoBrasileiroAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TorneiosController : ControllerBase
    {
        private TorneioService _torneioService;

        public TorneiosController(TorneioService torneioService)
        {
            _torneioService = torneioService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Post([FromBody] CreateTorneioDto torneioDto)
        {
            ReadTorneioDto readTorneioDto = _torneioService.Add(torneioDto);

            return CreatedAtAction(nameof(GetById), new { readTorneioDto.Id }, readTorneioDto);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IEnumerable<ReadTorneioDto> Get()
        {
            return _torneioService.Find();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult GetById(int id)
        {
            ReadTorneioDto readTorneioDto = _torneioService.FindById(id);

            if (readTorneioDto != null)
            {
                return Ok(readTorneioDto);
            }

            return NotFound();

        }

        [HttpPut("{torneioId}")]
        [Authorize(Roles = "admin")]
        public IActionResult Put(int id, [FromBody] UpdateTorneioDto torneioDto)
        {
            Result result = _torneioService.Update(id, torneioDto);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("{torneioId}/Times/{timeId}")]
        [Authorize(Roles = "admin")]
        public IActionResult Put([FromRoute] int torneioId, [FromRoute] int timeId)
        {
            Result result = _torneioService.AddTime(torneioId, timeId);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            Result result = _torneioService.Delete(id);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
