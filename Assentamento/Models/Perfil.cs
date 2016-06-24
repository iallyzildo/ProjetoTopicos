using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Assentamento.Models
{
    public class Perfil
    {
        private AssentamentoContext db = new AssentamentoContext();

        [Key]
        public int IdPerfil { get; set; }

        [Required]
        public string Descricao { get; set; }


        public List<Perfil> todosPerfil()
        {
            var lista = from a in db.Perfil
                        select a;
            return lista.ToList();
        }


        public Perfil obterPerfil(int idPefil)
        {
            var lista = from a in db.Perfil
                        where a.IdPerfil == IdPerfil
                        select a;
            return lista.ToList().FirstOrDefault();
        }
        public List<Perfil> listarPerfil(string pesquisa)
        {
            var lista = from a in db.Perfil
                        where a.Descricao.Contains(pesquisa)
                        select a;
            return lista.ToList();
        }


       
    }
}