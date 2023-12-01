using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Backend.Services;

public class SegurancaService : ISegurancaService
{
    public async Task<string> GerarSalt()
    {
        var saltBytes = gerarArrayAleatorio();
        var base64salt = Convert.ToBase64String(saltBytes);
        return base64salt;
    }

    public async Task<string> GerarJwt<T>(T obj)
    {
        string senha = await pegarSenha();
        var base64senha = converterBase64(senha);
        var jwt = pegarJwt(obj, base64senha);
        
        return jwt;
    }

    public async Task<string> HashSenha(string senha, string salt)
    {
        var saltBytes = Convert.FromBase64String(salt);
        var senhaBytes = Encoding.UTF8.GetBytes(senha);

        var hashBytes = pegarHash(saltBytes, senhaBytes);
        var hash = Convert.ToBase64String(hashBytes);

        return hash;
    }

    public async Task<T> ValidarJwt<T>(string jwt)
    {
        var data = jwt.Split('.');

        var cabecalho = data[0];
        var payload = data[1];
        var assinatura = data[2];
        var senha = await pegarSenha();
        var base64Senha = converterBase64(senha);

        var gerarAssinatura = pegarAssinatura(cabecalho, payload, assinatura);

        if (gerarAssinatura != assinatura)
        {
            return default(T);
        }

        // Console.WriteLine(payload);

        var payloadBytes = Convert.FromBase64String(payload);
        var payloadJson = Encoding.UTF8.GetString(payloadBytes);

        // Console.WriteLine(payloadJson);
        var obj = JsonSerializer.Deserialize<T>(payloadJson);

        return obj;
    }

    private async Task<string> pegarSenha()
    {
        var pontoEnvCaminho = Path.Combine(
            Environment.CurrentDirectory,
            ".env"
        );

        var linhas = await File.ReadAllLinesAsync(pontoEnvCaminho);
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

    private byte[] gerarArrayAleatorio()
    {
        byte[] bytesAleatorios = new byte [24];
        Random.Shared.NextBytes(bytesAleatorios);
        return bytesAleatorios;
    }

    private string converterBase64(string texto)
    {
        var bytes = Encoding.UTF8.GetBytes(texto);
        var base64 = Convert.ToBase64String(bytes);
        var base64Limpa = base64.Replace("=", "");
        return base64Limpa;
    }

    private string pegarJwt<T>(T obj, string senha)
    {
        var cabecalho = pegarJsonCabecalho();
        var cabecalhoBase64 = converterBase64(cabecalho);

        var payload = pegarJsonPayload(obj);
        var payloadBase64 = converterBase64(payload);

        var assinatura = pegarAssinatura(cabecalhoBase64, payloadBase64, senha);

        return $"{cabecalhoBase64}.{payloadBase64}.{assinatura}";
    }

    private string pegarJsonCabecalho()
    {
        var objCabecalho = new {
            alg = "HS256",
            TYP = "JWT"
        };
        var json = JsonSerializer.Serialize(objCabecalho);

        return json;
    }

    private string pegarJsonPayload<T>(T obj)
    {
        string json = JsonSerializer.Serialize(obj);
        return json;
    }

    private string pegarAssinatura(string cabecalho, string payload, string senha)
    {
        var senhaBytes = Convert.FromBase64String(converterBase64(senha));
        var conteudo = $"{cabecalho}.{payload}";
        var conteudoBytes = Encoding.UTF8.GetBytes(conteudo);

        using var algoritmo = new HMACSHA256(senhaBytes);
        var assinaturaBytes = algoritmo.ComputeHash(conteudoBytes);
        var assinatura = Convert.ToBase64String(assinaturaBytes);
        assinatura = assinatura.Replace("=","");

        return assinatura;
    }

    private byte[] pegarHash(byte[] saltBytes, byte[] senhaBytes)
    {
        const int iteracoesCount = 1000;
        using var hashAlgoritmo = new Rfc2898DeriveBytes(
            senhaBytes, saltBytes, iteracoesCount
        );

        var hashBytes = hashAlgoritmo.GetBytes(32);
        return hashBytes;
    }

}
