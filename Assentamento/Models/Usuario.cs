using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assentamento.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }

        public int IdPerfil { get; set; }

        [ForeignKey("IdPerfil")]
        public Perfil Perfil { get; set; }

        public int IdVendedor { get; set; }

        [ForeignKey("IdVendedor")]
        public Vendedor Vendedor { get; set; }
    }
}