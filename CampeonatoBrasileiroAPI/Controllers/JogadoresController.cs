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
    public class JogadoresController : ControllerBase
    {
        private JogadorService _jogadorService;

        public JogadoresController(JogadorService jogadorService)
        {
            _jogadorService = jogadorService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Post([FromBody] CreateJogadorDto jogadorDto)
        {
            ReadJogadorDto readJogadorDto = _jogadorService.Add(jogadorDto);

            return CreatedAtAction(nameof(GetById), new { readJogadorDto.Id }, readJogadorDto);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IEnumerable<ReadJogadorDto> Get()
        {
            return _jogadorService.Find();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult GetById(int id)
        {
            ReadJogadorDto readJogadorDto = _jogadorService.FindById(id);

            if (readJogadorDto != null)
            {
                return Ok(readJogadorDto);
            }

            return NotFound();

        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Put(int id, [FromBody] UpdateJogadorDto jogadorDto)
        {
            Result result = _jogadorService.Update(id, jogadorDto);

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
            Result result = _jogadorService.Delete(id);

            if (result.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
