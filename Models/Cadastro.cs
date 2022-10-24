using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MechTechAPI.Models
{
    public class Cadastro
    {
        [Key]
        public int CadastroId { get; set; }

        public int TipoCliente { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Telefone { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Senha { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Nome { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Sexo { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public int Idade { get; set; }
    }
}
