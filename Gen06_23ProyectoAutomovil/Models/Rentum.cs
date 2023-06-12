using System;
using System.Collections.Generic;

namespace Gen06_23ProyectoAutomovil.Models
{
    public partial class Rentum
    {
        public int Id { get; set; }
        public int DatosPersonalesId { get; set; }
        public int PerfilId { get; set; }
        public int AutoId { get; set; }
        public int EstatusRentaId { get; set; }
        public int NumDias { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Observaciones { get; set; }

        public virtual Automovil Auto { get; set; }
        public virtual DatosPersonale DatosPersonales { get; set; }
        public virtual EstatusRentum EstatusRenta { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}
