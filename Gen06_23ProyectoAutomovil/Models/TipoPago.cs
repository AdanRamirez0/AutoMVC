using System;
using System.Collections.Generic;

namespace Gen06_23ProyectoAutomovil.Models
{
    public partial class TipoPago
    {
        public TipoPago()
        {
            Pagos = new HashSet<Pago>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
