using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assentamento.Models
{
    public class Empresa
    {

        [Key]
        public int IdEmpresa { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cnpj { get; set; }    
    }
}
