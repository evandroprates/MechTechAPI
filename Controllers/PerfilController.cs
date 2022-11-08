using MechTechAPI.Context;
using MechTechAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MechTechAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly CadastroContext _context;

        public PerfilController(CadastroContext context)
        {
            _context = context;
        }

        [HttpPost("PegarDadosUsuario")]
        public async Task<Cadastro> PegarDadosUsuario(TipoCadastro perfil)
        {

            var consulta = _context.Cadastro.Where(p => p.CadastroId == perfil.Id);

            var resultado = consulta.FirstOrDefault();

            if (resultado != null)
            {
                var dados = await _context.Cadastro.FindAsync(resultado.CadastroId);
                return dados;
            }
            else
            {
                return null;
            }

        }

        [HttpPost("AtualizarDadosUsuario")]
        public async Task<Cadastro> AtualizarDadosUsuario(Cadastro cadastro)
        {
            var consulta = _context.Cadastro.Where(p => p.CadastroId == cadastro.CadastroId);

            var existe = consulta.FirstOrDefault();

            existe.Email = cadastro.Email;
            existe.Idade = cadastro.Idade;
            existe.Nome = cadastro.Nome;
            existe.Senha = cadastro.Senha;
            existe.Sexo = cadastro.Sexo;
            existe.Telefone = cadastro.Telefone;

            if (existe != null)
            {
                _context.Entry(existe).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return existe;
            }
            else
            {
                return existe;
            }


            //return Ok();
        }

    }
}
