using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assentamento.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string CpfCnpj { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        public string Telefone { get; set; }


    }
}