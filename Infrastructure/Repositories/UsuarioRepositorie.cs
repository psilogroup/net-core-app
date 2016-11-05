using System;
using EXP.Domain.Repositories;
using EXP.Models;
using System.Linq;
using System.Collections.Generic;

namespace EXP.Infrastructure
{
    public class UsuarioRepositorie : IUsuarioRepositorie
    {
         private readonly ExpenseDB _dbContext;
        public UsuarioRepositorie(ExpenseDB dbContext)
        {
            _dbContext = dbContext;
        }
        public void Adicionar(Usuario usuario)
        {
            
            _dbContext.Usuarios.Add(usuario);
            _dbContext.SaveChanges();
        }

        public IList<Usuario> Listar()
        {
            return _dbContext.Usuarios.ToList();
        }

        public Usuario ObterPorId(Guid id)
        {
            var usuario = (from q in _dbContext.Usuarios where q.Id == id select q).FirstOrDefault();
            return usuario;
            
        }
    }
}