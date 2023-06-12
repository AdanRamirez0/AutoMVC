using System;
using System.Collections.Generic;

namespace Gen06_23ProyectoAutomovil.Models
{
    public partial class Automovil
    {
        public Automovil()
        {
            Pagos = new HashSet<Pago>();
            Renta = new HashSet<Rentum>();
        }

        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public double CostoPorDia { get; set; }
        public int EstatusAutomovilId { get; set; }

        public virtual EstatusAutomovil EstatusAutomovil { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
        public virtual ICollection<Rentum> Renta { get; set; }
    }
}
