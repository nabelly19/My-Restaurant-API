using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Backend.Services;

public class SegurancaService : ISegurancaService
{
    public Task<string> GenerSalt()
    {
        throw new NotImplementedException();
    }

    public Task<string> GerarJwt<T>(T obj)
    {
        throw new NotImplementedException();
    }

    public Task<string> HashPassword(string senha, string salt)
    {
        throw new NotImplementedException();
    }

    public Task<T> ValidarJwt<T>(string jwt)
    {
        throw new NotImplementedException();
    }

    private async Task<string> PegarSenha()
    {
        var brasilenhaEnvPath = Path.Combine(
            Environment.CurrentDirectory,
            ".env"
        );

        var linhas = await File.ReadAllLinesAsync(brasilenhaEnvPath);
        foreach (var linha in linhas)
        {
            var data = linha.Split('=');
            if (data[0] != "PASSWORD")
                continue;
            return data[1];
        }
        throw new Exception
        (
            "É necessário um .env com uma PASSWORD para que esta operação seja executada"
        );
    }

}
