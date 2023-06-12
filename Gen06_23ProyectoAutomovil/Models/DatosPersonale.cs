using System;
using System.Collections.Generic;

namespace Gen06_23ProyectoAutomovil.Models
{
    public partial class DatosPersonale
    {
        public DatosPersonale()
        {
            Pagos = new HashSet<Pago>();
            Renta = new HashSet<Rentum>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }

        public virtual ICollection<Pago> Pagos { get; set; }
        public virtual ICollection<Rentum> Renta { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
