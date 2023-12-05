using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

using System.Threading;
using DTO;
using Model;
using Services;
using Trevisharp.Security.Jwt;

[ApiController]
[Route("usuario")]
public class UsuarioController : ControllerBase
{
    [HttpPost("login")]
    [EnableCors("DefaultPolicy")]
    public async Task <IActionResult> Login(
        [FromBody]UsuarioData usuario,
        [FromServices]IUsuarioService service,
        [FromServices]ISegurancaService seguranca,
        [FromServices]CryptoService crypto)
        {
            var logarUsuario = await service.PegarPeloLogin(usuario.Login);

            if (logarUsuario == null)
                return Unauthorized("usuário não existe");
            
            var senha = await seguranca.HashSenha(
                usuario.Senha, logarUsuario.Salt
            );

            var realSenha = logarUsuario.Senha;
            if (senha != realSenha)
                return Unauthorized("Senha incorreta");

            var jwt = crypto.GetToken(new {
                id = logarUsuario.Id
            });

            return Ok(new {jwt});            

        }

        [HttpPost("registrar")]
        [EnableCors("DefaultPolicy")]
        public async Task<IActionResult> Criar(
            [FromBody] UsuarioData usuario,
            [FromServices] IUsuarioService service)
        {

            var erros = new List<string>();
            if(usuario is null || usuario.Login is null || usuario.Email is null || usuario.Senha is null)
                erros.Add("É obrigatório informar um login.");
            if(usuario.Login.Length < 5)
                erros.Add("O Login deve conter mais de 5 caracteres");

            if(erros.Count() > 0)
                return BadRequest(new { message = "Erro ao criar usuário", errors = erros });

            await service.Criar(usuario);
            return Ok();
        }

}
