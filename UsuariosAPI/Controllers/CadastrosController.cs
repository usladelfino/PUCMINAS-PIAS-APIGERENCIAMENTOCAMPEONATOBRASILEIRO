

using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastrosController : ControllerBase
    {
        private CadastroService _cadastroService;

        public CadastrosController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult Post(CreateUsuarioDto usuarioDto)
        {
            Result resultado = _cadastroService.AddUsuario(usuarioDto);

            if (resultado.IsFailed)
            {
                return StatusCode(500);
            }

            return Ok(resultado.Successes.FirstOrDefault());
        }

        [Route("ativa")]
        [HttpGet]
        public  IActionResult Get([FromQuery] AtivaContaRequest request)
        {
            Result resultado = _cadastroService.AtivaContaUsuario(request);
            
            if (resultado.IsFailed)
            {
                return StatusCode(500);
            }

            return Ok(resultado.Successes.FirstOrDefault());
        }
    }
}
