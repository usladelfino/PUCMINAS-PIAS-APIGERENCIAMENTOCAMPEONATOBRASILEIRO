using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] LoginRequest request)
        {
            Result resultado = _loginService.Login(request);

            if (resultado.IsFailed)
            {
                return Unauthorized(resultado.Errors.FirstOrDefault());
            }

            return Ok(resultado.Successes.FirstOrDefault());
        }
    }
}
