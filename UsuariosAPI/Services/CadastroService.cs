using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private EmailService _emailService;
        private RoleManager<IdentityRole<int>> _roleManager;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager, EmailService emailService, RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
            _roleManager = roleManager;
        }

        public Result AddUsuario(CreateUsuarioDto usuarioDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            var resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, usuarioDto.Password).Result;

            var createRoleResult = _roleManager.CreateAsync(new IdentityRole<int>("admin")).Result;
            var usuarioRoleResult = _userManager.AddToRoleAsync(usuarioIdentity, "admin");

            if (resultadoIdentity.Succeeded)
            {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                var encodedCode = HttpUtility.UrlEncode(code);
                _emailService.EnviarEmail(new Dictionary<string, string>() { { usuarioIdentity.UserName, usuarioIdentity.Email} }, "Ative sua Conta", usuarioIdentity.Id, encodedCode);
                
                return Result.Ok().WithSuccess(encodedCode);
            }

            return Result.Fail("Falha ao cadastrar usuário");
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            var usuarioIdentity = _userManager.Users.FirstOrDefault(u => u.Id == request.UsuarioId);
            var resultadoIdentity = _userManager.ConfirmEmailAsync(usuarioIdentity, request.CodigoAtivacao).Result;

            if (resultadoIdentity.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Falha ao ativar conta do usuário.");
        }
    }
}