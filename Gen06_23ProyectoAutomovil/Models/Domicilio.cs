using System;
using System.Collections.Generic;

namespace Gen06_23ProyectoAutomovil.Models
{
    public partial class Domicilio
    {
        public Domicilio()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Calle { get; set; }
        public string NoExterior { get; set; }
        public string NoInterior { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
        public string Cp { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
