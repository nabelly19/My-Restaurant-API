using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Backend.Services;

using Backend.Model;
using DTO;
using Model;

public class CupomService : ICupomService
{
    BrasilenhaContext ctx;
    public CupomService(BrasilenhaContext ctx)
    {
        this.ctx = ctx;
    }
    public async Task Criar(CupomData data)
    {
        Cupom cupom = new()
        {
            Codigo = data.Codigo,
            Valor = data.Desconto
        };

        this.ctx.Add(cupom);
        await this.ctx.SaveChangesAsync();
    }

    public Task<List<Cupom>> Pegar()
    {
        throw new NotImplementedException();
    }

    public Task<Cupom> PegarPeloCodigo(CupomData cupom)
    {
        throw new NotImplementedException();
    }
}
