using System;
using System.Collections.Generic;

namespace Gen06_23ProyectoAutomovil.Models
{
    public partial class CostoAdicional
    {
        public CostoAdicional()
        {
            Pagos = new HashSet<Pago>();
        }

        public int Id { get; set; }
        public double MontoCostoAdicional { get; set; }

        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
