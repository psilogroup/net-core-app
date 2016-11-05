using Microsoft.AspNetCore.Mvc;
using EXP.Domain.Repositories;
using EXP.Models;
using System.Collections.Generic;

namespace ExpenseCoreAPI.Controllers
{
    [Route("usuario")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorie usuarioRepositorie;
        public UsuarioController(IUsuarioRepositorie repositorie)
        {
            usuarioRepositorie = repositorie;
        }
        
        [Route("GetAll")]
        [HttpGet()]
        public IEnumerable<Usuario> Get()
        {
            return usuarioRepositorie.Listar();
        }

        
        [Route("GetById")]
        [HttpGet("{id}")]
        public Usuario Get(System.Guid id)
        {
            return usuarioRepositorie.ObterPorId(id);
        }

        [Route("New")]
        [HttpPost]
        public IActionResult Post([FromBody]Usuario usuario)
        {
            if (usuario == null || !ModelState.IsValid)
            {
                return BadRequest("Usuário inválido");
            }

            usuario.Id = System.Guid.NewGuid();
            var crypt = new EXP.Infrastructure.Crypto();
            
            usuario.Senha = crypt.ComputeHash(usuario.Senha);

            usuarioRepositorie.Adicionar(usuario);

            return Ok(usuario);
        }
    }
}
