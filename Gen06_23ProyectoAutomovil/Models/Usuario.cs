using System;
using System.Collections.Generic;

namespace Gen06_23ProyectoAutomovil.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Correo { get; set; }
        public string Pass { get; set; }
        public int PerfilId { get; set; }
        public int DomicilioId { get; set; }
        public int DatosPersonalesId { get; set; }

        public virtual DatosPersonale DatosPersonales { get; set; }
        public virtual Domicilio Domicilio { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}
