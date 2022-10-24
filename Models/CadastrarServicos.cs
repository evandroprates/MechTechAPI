using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MechTechAPI.Models
{
    public class CadastrarServicos
    {
        public int Id { get; set; }
        public int IdCadastro { get; set; }
        public string Servico { get; set; }
        public string Valor { get; set; }
    }
}
