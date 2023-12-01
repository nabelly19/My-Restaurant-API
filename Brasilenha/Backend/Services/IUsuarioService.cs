using System.Threading.Tasks;

namespace Backend.Services;

using DTO;
using Model;

public interface IUsuarioService
{
    Task Criar(UsuarioData data);
    Task<Usuario> PegarPeloLogin(string login);
}