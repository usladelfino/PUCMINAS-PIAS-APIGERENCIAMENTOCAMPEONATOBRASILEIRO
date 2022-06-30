using AutoMapper;
using CampeonatoBrasileiroAPI.Data;
using CampeonatoBrasileiroAPI.Data.Dtos;
using CampeonatoBrasileiroAPI.Models;
using CampeonatoBrasileiroAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CampeonatoBrasileiroAPI.Controllers
{
    [ApiController]
    [Route("Torneios/{torneioId}/[Controller]")]
    public class PartidasController : ControllerBase
    {
        private PartidaService _partidaService;

        public PartidasController(PartidaService partidaService)
        {
            _partidaService = partidaService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Post([FromRoute] int torneioId, [FromBody] CreatePartidaDto partidaDto)
        {
            ReadPartidaDto readPartidaDto = _partidaService.Add(torneioId, partidaDto);

            return CreatedAtAction(nameof(GetById), new { readPartidaDto.Id }, readPartidaDto);
        }

        [HttpGet("{partidaId}")]
        [Authorize(Roles = "admin")]
        public IActionResult GetById(int partidaId)
        {
            ReadPartidaDto readPartidaDto = _partidaService.FindById(partidaId);

            if (readPartidaDto != null)
            {
                return Ok(readPartidaDto);
            }

            return NotFound();
        }
    }
}
