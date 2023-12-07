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

using DTO;
using Model;
using System.Security.Cryptography;
using Trevisharp.Security.Jwt;
using System.ComponentModel;
using Backend.Services;

[ApiController]
[Route("cupom")]
public class CupomController : ControllerBase
{
    [HttpPost("register")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult>  Criar(
        [FromBody]CupomData cupom,
        [FromServices]CupomService servico
    )
    {
        var erros = new List<string>();
        if(cupom is null)
            erros.Add("O formulário deve ser preenchido");
      
        if(erros.Count > 0)
            return BadRequest(erros);

        await servico.Criar(cupom);
        return Ok();
     
    }

    [HttpGet()]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> Pegar(
        [FromServices]ICupomService servico
    )
    {
        var v = await servico.Pegar();
        var erros = new List<string>();
        if (erros.Count > 0)
            return BadRequest(erros);
        return Ok(new{v});
    }

    [HttpPost("pegarCupom")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> PegarPeloCodigo(
        [FromServices]ICupomService servico,
        [FromBody]CupomData cupom
    )
    {
        var v = await servico.PegarPeloCodigo(cupom);
        if(v == null)
            return Ok(0);

        var valor = v.Valor;
        var erros = new List<string>();

        if(erros.Count > 0)
            return BadRequest(erros);

        return Ok(valor);
    }
}
