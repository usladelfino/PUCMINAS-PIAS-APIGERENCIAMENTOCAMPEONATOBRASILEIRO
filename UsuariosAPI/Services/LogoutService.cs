using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class LogoutService
    {
        private SignInManager<IdentityUser<int>> _signinManager;

        public LogoutService(SignInManager<IdentityUser<int>> signinManager)
        {
            _signinManager = signinManager;
        }

        public Result Logout()
        {
            var resultadoIdentity = _signinManager.SignOutAsync();

            if (resultadoIdentity.IsCompletedSuccessfully)
            {
                return Result.Ok();
            }

            return Result.Fail("Falha no Logout");
        }
    }
}