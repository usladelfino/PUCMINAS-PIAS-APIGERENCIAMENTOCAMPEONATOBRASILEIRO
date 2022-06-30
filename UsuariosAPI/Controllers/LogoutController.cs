using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        private LogoutService _logoutService;

        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult Post()
        {
            Result resultado = _logoutService.Logout();

            if (resultado.IsFailed)
            {
                return Unauthorized(resultado.Errors.FirstOrDefault());
            }

            return Ok();
        }
    }
}
