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
    public Task Criar(ProdutoData produto)
    {
        throw new NotImplementedException();
    }

    public Task<List<Produto>> Pegar()
    {
        throw new NotImplementedException();
    }

    public Task<Produto> PegarpeloNome(string Nome)
    {
        throw new NotImplementedException();
    }
}
