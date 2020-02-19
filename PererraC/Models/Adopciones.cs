using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PererraC.Models
{
    public class Adopciones
    {

        public int PerroId { get; set; }
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public System.DateTime FechaEntrega { get; set; }

        public virtual Clientes Clientes { get; set; }
        public virtual Empleados Empleados { get; set; }
        public virtual Perros Perros { get; set; }
    }
}