using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Assentamento.Models
{
    public class AssentamentoContext : DbContext
    {
        public AssentamentoContext()
            : base("Assentamento")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Remover pluralização do nome das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();



        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<Visita> Visita { get; set; }
    }
}