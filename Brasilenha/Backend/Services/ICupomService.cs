using System.Threading.Tasks;

namespace Backend.Services;

using System.Collections.Generic;
using DTO;
using Model;

public interface ICupomService
{
    Task Criar(CupomData data);
    Task<Cupom> PegarPeloCodigo(CupomData data);
    Task<List<Cupom>> Pegar();
}