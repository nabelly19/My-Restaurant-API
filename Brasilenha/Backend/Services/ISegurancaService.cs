using System.Threading.Tasks;

namespace Backend.Services;

public interface ISegurancaService
{  
    Task<string> GerarSalt();
    Task<string> HashSenha(string senha, string salt);
    Task<string> GerarJwt<T>(T obj);
    Task<T> ValidarJwt<T>(string jwt);
    
}

