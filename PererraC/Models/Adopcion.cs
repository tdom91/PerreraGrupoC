using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PererraC.Models
{
    public class Adopcion
    {

        public int PerroId { get; set; }
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public System.DateTime FechaEntrega { get; set; }

        public virtual Cliente Clientes { get; set; }
        public virtual Empleado Empleados { get; set; }
        public virtual Perro Perros { get; set; }
    }
}