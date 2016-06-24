using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assentamento.Models
{
    public class Visita
    {
        [Key]
        public int IdVisita { get; set; }


        public int IdVendedor { get; set; }

        [ForeignKey("IdVendedor")]
        public Vendedor Vendedor { get; set; }

        public int IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }

        [Required]
        public string Assunto { get; set; }

        [Required]
        public string Descricao { get; set; }
    }
}