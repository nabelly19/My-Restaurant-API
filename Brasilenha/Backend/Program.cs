using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Trevisharp.Security.Jwt;

using Backend.Model;
using Backend.Services;

// var builder = WebApplication.CreateBuilder(args);

//   //ADD SERVICES TO THE CONTAINER
// builder.Services.AddScoped<BrasilenhaContext>();
// builder.Services.AddTransient<IUsuarioService, UsuarioService>();
// builder.Services.AddSingleton<CryptoService>(p => new() {
//     TamanhoChaveInterna = 24,
//     PeriodoAtualizacao = TimeSpan.FromDays(1)
// });

// builder.Services.AddSingleton<ISegurancaService, SegurancaService>();

