using System.Threading.Tasks;

namespace Backend.Services;

public interface ISegurancaService
{  
    Task<string> GenerSalt();
    Task<string> HashPassword(string senha, string salt);
    Task<string> GerarJwt<T>(T obj);
    Task<T> ValidarJwt<T>(string jwt);
    
}

