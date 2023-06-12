using System;
using System.Collections.Generic;

namespace Gen06_23ProyectoAutomovil.Models
{
    public partial class EstatusAutomovil
    {
        public EstatusAutomovil()
        {
            Automovils = new HashSet<Automovil>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Automovil> Automovils { get; set; }
    }
}
