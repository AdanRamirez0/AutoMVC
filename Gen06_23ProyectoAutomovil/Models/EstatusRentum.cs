using System;
using System.Collections.Generic;

namespace Gen06_23ProyectoAutomovil.Models
{
    public partial class EstatusRentum
    {
        public EstatusRentum()
        {
            Renta = new HashSet<Rentum>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Rentum> Renta { get; set; }
    }
}
