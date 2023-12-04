using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Backend.Services;

using DTO;
using Model;

public class UsuarioService : IUsuarioService
{
    BrasilenhaContext ctx;
    ISegurancaService seguranca;

    public UsuarioService (BrasilenhaContext ctx, ISegurancaService seguranca)
    {
        this.ctx = ctx;
        this.seguranca = seguranca;
    }

    public async Task Criar(UsuarioData data)
    {
        Usuario usuario = new Usuario();
        var salt = await seguranca.GerarSalt();

        usuario.Nome = data.Login;
        usuario.Email = data.Email;
        usuario.Senha = await seguranca.HashSenha(
            data.Senha, salt
        );
        usuario.Salt = salt;
        usuario.IsAdm = false;

        this.ctx.Add(usuario);
        await this.ctx.SaveChangesAsync();
    }

    public async Task<Usuario> PegarPeloLogin(string login)
    {
        var query = 
            from usuario in this.ctx.Usuarios
            where usuario.Nome == login
            select usuario;

        return await query.FirstOrDefaultAsync(); 
    }
}
