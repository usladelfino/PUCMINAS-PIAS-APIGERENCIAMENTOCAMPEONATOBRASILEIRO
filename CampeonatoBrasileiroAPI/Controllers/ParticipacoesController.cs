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
    [Route("Torneios/{torneioId}/Partidas/{partidaId}/[Controller]")]
    public class ParticipacoesController : ControllerBase
    {
        private ParticipacaoService _participacaoService;

        public ParticipacoesController(ParticipacaoService particicaoService)
        {
            _participacaoService = particicaoService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Post([FromRoute] int torneioId, [FromRoute] int partidaId, [FromBody] CreateParticipacaoDto participacaoDto)
        {
            ReadParticipacaoDto readParticipacaoDto = _participacaoService.Add(torneioId, partidaId, participacaoDto);

            return CreatedAtAction(nameof(GetById), new { readParticipacaoDto.Id }, readParticipacaoDto);
        }

        [HttpPut("{participacaoId}")]
        [Authorize(Roles = "admin")]
        public IActionResult Put([FromRoute] int torneioId, [FromRoute] int partidaId, int participacaoId, [FromBody] UpdateParticipacaoDto participacaoDto)
        {
            Result result = _participacaoService.Update(torneioId, partidaId, participacaoId, participacaoDto);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("{participacaoId}")]
        [Authorize(Roles = "admin")]
        public IActionResult GetById(int participacaoId)
        {
            ReadParticipacaoDto readParticipacaoDto = _participacaoService.FindById(participacaoId);

            if (readParticipacaoDto != null)
            {
                return Ok(readParticipacaoDto);
            }

            return NotFound();
        }
    }
}
