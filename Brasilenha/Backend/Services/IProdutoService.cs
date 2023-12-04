using System.Threading.Tasks;

namespace Backend.Services;

using System.Collections.Generic;
using DTO;
using Model;

public interface IProdutoService
{
    Task Criar(ProdutoData produto);
    Task<Produto> PegarpeloNome(string Nome);
    Task<List<Produto>> Pegar();
}