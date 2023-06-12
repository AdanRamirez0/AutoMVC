using System;
using System.Collections.Generic;

namespace Gen06_23ProyectoAutomovil.Models
{
    public partial class Pago
    {
        public int Id { get; set; }
        public int DatosPersonalesId { get; set; }
        public int PerfiId { get; set; }
        public int NumPago { get; set; }
        public int AutoId { get; set; }
        public int EstatusPagoId { get; set; }
        public int TipoPagoId { get; set; }
        public double MontoTotal { get; set; }
        public DateTime FechaPago { get; set; }
        public int CostoAdicionalId { get; set; }
        public DateTime FechaCargo { get; set; }
        public double Monto { get; set; }

        public virtual Automovil Auto { get; set; }
        public virtual CostoAdicional CostoAdicional { get; set; }
        public virtual DatosPersonale DatosPersonales { get; set; }
        public virtual EstatusPago EstatusPago { get; set; }
        public virtual Perfil Perfi { get; set; }
        public virtual TipoPago TipoPago { get; set; }
    }
}
