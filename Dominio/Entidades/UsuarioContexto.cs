using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class UsuarioContexto : DbContext 
    {
        public UsuarioContexto() : base("name=ConexaoUsuarios")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<UsuarioContexto>(new CreateDatabaseIfNotExists<UsuarioContexto>());
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
