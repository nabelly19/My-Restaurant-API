using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

using Backend.Model;
using Model;
using DTO;


public class ProdutoService : IProdutoService
{

    BrasilenhaContext ctx;
    ISegurancaService seguranca;
    public ProdutoService(BrasilenhaContext ctx, ISegurancaService seguranca)
    {
        this.ctx = ctx;
        this.seguranca = seguranca;
    }
    public async Task Criar(ProdutoData data)
    {
        Produto produto = new()
        {
            NomeProduto = data.NomeProduto,
            Descrição = data.Descricao,
            Valor = data.Valor,
            ImagemId = data.IdImg
        };

        this.ctx.Add(produto);
        await this.ctx.SaveChangesAsync();
    }

    public async Task<List<Produto>> Pegar()
        => await this.ctx.Produtos.ToListAsync();

    public async Task<Produto> PegarpeloNome(string Nome)
    {
        var query = 
            from product in this.ctx.Produtos
            where product.NomeProduto == Nome
            select product;

        return await query.FirstOrDefaultAsync();
    }
}
