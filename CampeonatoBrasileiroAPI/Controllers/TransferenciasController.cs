using CampeonatoBrasileiroAPI.Data.Dtos;
using CampeonatoBrasileiroAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CampeonatoBrasileiroAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TransferenciasController : ControllerBase
    {
        private TransferenciaService _transferenciaService;

        public TransferenciasController(TransferenciaService transferenciaService)
        {
            _transferenciaService = transferenciaService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Post([FromBody] CreateTransferenciaDto transferenciaDto)
        {
            ReadTransferenciaDto readTransferenciaDto = _transferenciaService.Add(transferenciaDto);

            return CreatedAtAction(nameof(GetById), new { readTransferenciaDto.Id }, readTransferenciaDto);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IEnumerable<ReadTransferenciaDto> Get()
        {
            return _transferenciaService.Find();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult GetById(int id)
        {

            ReadTransferenciaDto readTransferenciaDto = _transferenciaService.FindById(id);

            if (readTransferenciaDto != null)
            {
                return Ok(readTransferenciaDto);
            }

            return NotFound();  
        }
    }
}
