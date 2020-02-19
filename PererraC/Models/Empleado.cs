using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PererraC.Models
{
    public class Empleado
    {
        private int IdEmpleado { get; set; }

        private string NombreEmpleado{ get; set; }

        private string TelefonoEmpleado { get; set; }

        private string CorreoEmpleado { get; set; }
            
        private string DNIEmpleado { get; set; }
        
        public virtual ICollection<Adopcion> Adopciones { get; set; }

    }
}