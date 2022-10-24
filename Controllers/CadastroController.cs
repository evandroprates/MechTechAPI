using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MechTechAPI.Context;
using MechTechAPI.Models;

namespace PagamentoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly CadastroContext _context;

        public CadastroController(CadastroContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cadastro>>> PegarCadastros()
        {
            return await _context.Cadastro.ToListAsync();
        }

        [HttpGet("PegarServicos")]
        public async Task<ActionResult<IEnumerable<Servicos>>> PegarCadastroServicos()
        {
            return await _context.Servico.ToListAsync();
        }

        [HttpPost("Cadastrar")]
        public async Task<Cadastro> Cadastrar(Cadastro cadastro)
        {
            var consulta = _context.Cadastro.Where(p => p.Email == cadastro.Email);

            var existe = consulta.FirstOrDefault();

            if (existe != null)
            {
                return existe;
            } else
            {
                _context.Cadastro.Add(cadastro);
                await _context.SaveChangesAsync();
                return existe;
            }



            //return Ok();
        }

        [HttpPost("Login")]
        public async Task<Cadastro> Login(Login login)
        {

            var consulta = _context.Cadastro.Where(p => p.Email == login.Email && p.Senha == login.Senha);

            var resultado = consulta.FirstOrDefault();

            if (resultado != null)
            {
                var resultadoLogin = await _context.Cadastro.FindAsync(resultado.CadastroId);
                return resultadoLogin;
            } else
            {
                return null;
            }

        }

        //[HttpPost("SetTipoCadastro")]
        //public void Task<Cadastro> SetTipoCadastro(int id)
        //{

        //    var consulta = _context.Cadastro.Where(p => p.Email == login.Email && p.Senha == login.Senha);

        //    var resultado = consulta.FirstOrDefault();

        //}

        [HttpPost("SetTipoCadastroCliente")]
        public async Task<IActionResult> SetTipoCadastroCliente(TipoCadastro tipo)
        {

            var consulta = _context.Cadastro.Where(x => x.CadastroId == tipo.Id);

            var resultado = consulta.FirstOrDefault();

            resultado.TipoCliente = tipo.Tipo;

            _context.Entry(resultado).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("CadastrarServicosMecanico")]
        public async Task<IActionResult> CadastrarServicosMecanico(CadastrarServicos[] servicos)
        {

            var consulta = _context.ServicosMecanico.Where(x => x.IdCadastro == servicos[0].IdCadastro);

            var resultado = consulta.FirstOrDefault();

            if (resultado == null)
            {
                foreach (var item in servicos)
                {
                    _context.ServicosMecanico.Add(item);
                    await _context.SaveChangesAsync();
                }

                return Ok("Servicos cadastrados!");
            }

            return Ok("Servicos já foram cadastrados!");
        }

        //[HttpPost("SetTipoCadastroCliente")]
        //public async Task<IActionResult> SetTipoCadastroCliente([FromBody] int id)
        //{

        //    var consulta = _context.Cadastro.Where(x => x.CadastroId == id);

        //    var resultado = consulta.FirstOrDefault();

        //    resultado.TipoCliente = 1;

        //    _context.Entry(resultado).State = EntityState.Modified;

        //    await _context.SaveChangesAsync();

        //    return Ok();
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Cadastro>> PegarCadastro(int id)
        //{
        //    var pagamentoDetalhe = await _context.Cadastro.FindAsync(id);

        //    if (pagamentoDetalhe == null)
        //    {
        //        return NotFound();
        //    }

        //    return pagamentoDetalhe;
        //}


        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPagamentoDetalhe(int id, Cadastro pagamentoDetalhe)
        //{
        //    if (id != pagamentoDetalhe.CadastroId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(pagamentoDetalhe).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PagamentoDetalheExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}


        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePagamentoDetalhe(int id)
        //{
        //    var pagamentoDetalhe = await _context.Cadastro.FindAsync(id);
        //    if (pagamentoDetalhe == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Cadastro.Remove(pagamentoDetalhe);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool PagamentoDetalheExists(int id)
        //{
        //    return _context.Cadastro.Any(e => e.CadastroId == id);
        //}

        //[HttpGet("Consulta")]
        //public async Task<ActionResult> GetAqui()
        //{
        //    var query = from Pag in _context.PagamentoDetalhe
        //                where Pag.CadastroId > 1
        //                //select new { Pagamento = Pag.NomeCartao, Validade = Pag.Validade };
        //                select Pag;

        //    var query2 = _context.PagamentoDetalhe.Where(p => p.NomeCartao != "Visaa");

        //    var resultado = await query.ToListAsync();

        //    var resultado2 = await query2.ToListAsync();

        //    return Ok(resultado2);
        //}
    }
}
