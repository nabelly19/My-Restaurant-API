using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

using Backend.Model;

public class PedidoService : IPedidoService
{

    private readonly BrasilenhaContext ctx;
    public PedidoService(BrasilenhaContext ctx)
        => this.ctx = ctx;
    public Task AdProduto(int pedidoId, int produtoId)
    {
        throw new NotImplementedException();
    }

    public async Task CancelarPedido(int pedidoId)
    {
        
    }

    public Task<List<Produto>> Cardapio(int pedidoId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> CriarPedido(int usuarioId)
    {
        var usuarioSelecionado= 
            from usuario in ctx.Usuarios
            where usuario.Id == usuarioId
            select usuario;
        if(!usuarioSelecionado.Any())
            throw new Exception("Usuário não existe");

        var pedido = new Pedido();
        pedido.UsuarioId = usuarioId;
        pedido.CodigoPedido = "teste";

        ctx.Add(pedido);
        await ctx.SaveChangesAsync();

        return pedido.Id;
    }

    public Task FinalizadoPedido(int pedidoId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Produto>> PedidoProduto(int pedidoId)
    {
        throw new NotImplementedException();
    }

    public Task RemoverProduto(int pedidoId)
    {
        throw new NotImplementedException();
    }

    // FUNCOES USADAS

    private async Task<Pedido> getPedido(int pedidoId)
    {
        var pedidos =
            from pedido in ctx.Pedidos
            where pedido.Id == pedidoId
            select pedido;

        return await pedidos.FirstOrDefaultAsync();
    }
}

