using System.Threading.Tasks;
using System.Collections.Generic;

namespace Backend.Services;

using Backend.Model;

public interface IPedidoService {
    Task<int> CriarPedido(int usuarioId);
    Task CancelarPedido(int pedidoId);
    Task<List<Produto>> Cardapio(int pedidoId);
    Task<List<Produto>> PedidoProduto(int pedidoId);
    Task AdProduto(int pedidoId, int produtoId);
    Task RemoverProduto(int pedidoId);
    Task FinalizadoPedido(int pedidoId);
    
}