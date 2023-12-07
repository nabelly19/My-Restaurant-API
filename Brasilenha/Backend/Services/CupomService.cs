using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Backend.Services;

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

    public async Task<List<Cupom>> Pegar()
        => await this.ctx.Cupoms.ToListAsync();
    

    public async Task<Cupom> PegarPeloCodigo(CupomData cupom)
    {
        var query = 
        from v in ctx.Cupoms
        where v.Codigo == cupom.Codigo
        select v;

        return await query.FirstOrDefaultAsync();
    }
}
