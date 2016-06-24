using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assentamento.Models
{
    public class Vendedor
    {
        [Key]
        public int IdVendedor { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cpf { get; set; }

        public int IdCargo { get; set; }

        [ForeignKey("IdCargo")]
        public Cargo Cargo { get; set; }

        public int IdEmpresa { get; set; }

        [ForeignKey("IdEmpresa")]
        public Empresa Empresa { get; set; }

      
    }
}