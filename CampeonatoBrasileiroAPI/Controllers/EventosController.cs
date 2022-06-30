using AutoMapper;
using CampeonatoBrasileiroAPI.Data;
using CampeonatoBrasileiroAPI.Data.Dtos;
using CampeonatoBrasileiroAPI.Messenger;
using CampeonatoBrasileiroAPI.Models;
using CampeonatoBrasileiroAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CampeonatoBrasileiroAPI.Controllers
{
    [ApiController]
    [Route("Torneios/{torneioId}/Partidas/{partidaId}/[Controller]")]
    public class EventosController : ControllerBase
    {
        private EventoService _eventoService;

        public EventosController(EventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpPost("{tipo}")]
        [Authorize(Roles = "admin")]
        public IActionResult Post([FromRoute] int torneioId, [FromRoute] int partidaId, eEvento tipo, [FromBody] CreateEventoDto eventoDto)
        {
            ReadEventoDto readEventoDto = _eventoService.Add(torneioId, partidaId, tipo, eventoDto);

            return CreatedAtAction(nameof(GetById), new { readEventoDto.Id }, readEventoDto);
        }

        [HttpGet("{eventoId}")]
        [Authorize(Roles = "admin")]
        public IActionResult GetById(int eventoId)
        {
            ReadEventoDto readEventoDto = _eventoService.FindById(eventoId);

            if (readEventoDto != null)
            {
                return Ok(readEventoDto);
            }

            return NotFound();
        }
    }
}
