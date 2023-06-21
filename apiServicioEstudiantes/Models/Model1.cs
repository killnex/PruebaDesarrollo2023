using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace apiServicioEstudiantes.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<ListadoEstudiantes> ListadoEstudiantes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ListadoEstudiantes>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<ListadoEstudiantes>()
                .Property(e => e.Sexo)
                .IsUnicode(false);

            modelBuilder.Entity<ListadoEstudiantes>()
                .Property(e => e.Escolaridad)
                .IsUnicode(false);
        }
    }
}
