namespace apiServicioEstudiantes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ListadoEstudiantes
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }

        public int Edad { get; set; }

        [Required]
        [StringLength(10)]
        public string Sexo { get; set; }

        [Required]
        [StringLength(50)]
        public string Escolaridad { get; set; }
    }
}
