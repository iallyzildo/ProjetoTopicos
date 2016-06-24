using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assentamento.Models
{
    public class Cargo
    {
        [Key]
        public int IdCargo { get; set; }

        [Required]
        public string Descricao { get; set; }
    }
}