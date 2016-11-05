using System.Collections.Generic;
using EXP.Models;
namespace EXP.Domain.Repositories
{
    public interface IUsuarioRepositorie
    {
        void Adicionar(Usuario usuario);
        Usuario ObterPorId(System.Guid id);

        IList<Usuario> Listar();
    }
}

