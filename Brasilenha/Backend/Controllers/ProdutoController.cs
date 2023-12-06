using System.ComponentModel.Design;
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
using Services;
using Trevisharp.Security.Jwt;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("produto")]
public class ProdutoController : ControllerBase
{
    [HttpPost("registrar")]
    [EnableCors("DefaultPolicy")]

    public async Task<IActionResult> CriarProduto(
        [FromBody]ProdutoData produto,
        [FromServices]IProdutoService servico
    )
    {
        var erros = new List<string>();

        if(produto.NomeProduto.Length < 5)
            erros.Add("O produto precisa conter ao menos 5 caracteres");
        if(produto.Valor < 8)
            erros.Add("O valor mínimo dos produtos são R$8,00");
        if(produto.Descricao == null)
            erros.Add("Este campo não pode ser nulo");
        if(produto is null)
            erros.Add("O formulário deve ser preenchido");

        if(erros.Count > 0) 
            return BadRequest(erros);

        await servico.Criar(produto);
        return Ok();
    }

    [HttpGet("produto")]
    [EnableCors("Defaultpolicy")]
    public async Task<IActionResult> VerProduto(
        [FromBody]ProdutoData produto,
        [FromServices]IProdutoService servico
    )
    {
        var p = await servico.Pegar();

        var erros = new List<string>();
        if (erros.Count > 0)
            return BadRequest(erros);

        return Ok(new {p});
    }

    [HttpGet("produtoporvez")]
    [EnableCors("Defaultpolicy")]
    public async Task<ActionResult> VerUmProduto(
        [FromBody]ProdutoData produto,
        [FromServices]IProdutoService servico
    )
    {
        var p = await servico.PegarpeloNome(produto.NomeProduto);

        return Ok(new{p});
    }

    [HttpGet("image/{imagemId}")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> GetImage(
        int imagemId,
        [FromServices]ISegurancaService seguranca,
        [FromServices]BrasilenhaContext ctx
    )
    {
        var query = 
            from image in ctx.Imagems
            where image.Id == imagemId
            select image;

        var photo = await query.FirstOrDefaultAsync();

        if(photo is null)
            return NotFound();

        return File(photo.Foto, "image/jpeg");
    }

    [DisableRequestSizeLimit]
    [HttpPost("imagem")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> AddImagem(
        [FromServices]CryptoService seguranca
    )
    {
        // var jwtData = Request.Form["jwt"];
        // var jwtObj = JsonSerializer
        //     .Deserialize<JwtToken>(jwtData);

        // var jwt = jwtObj.jwt;

        // var userObj = seguranca
        //     .Validate<JwsPayload>(jwt);

        // if (userObj is null)
        //     return Unauthorized();
        // var userId = userObj.id;

        var files = Request.Form.Files;
        if (files is null || files.Count == 0)
            return BadRequest();

        var file = Request.Form.Files[0];
        if (file.Length < 1)
            return BadRequest();
        
        using MemoryStream ms = new MemoryStream();
        await file.CopyToAsync(ms);
        var data = ms.GetBuffer();

        Imagem img = new Imagem();
        img.Foto = data;

        BrasilenhaContext ctx = new BrasilenhaContext();
        ctx.Add(img);
        await ctx.SaveChangesAsync();

        return Ok(new {
            imgId = img.Id
        });
    }

}
