using Microsoft.EntityFrameworkCore;
using MechTechAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MechTechAPI.Context
{
    public class CadastroContext : DbContext
    {

        public CadastroContext(DbContextOptions<CadastroContext> options) : base(options)
        {

        }

        public DbSet<Cadastro> Cadastro { get; set; }

        public DbSet<Servicos> Servico { get; set; }

        public DbSet<CadastrarServicos> ServicosMecanico { get; set; }

    }
}
