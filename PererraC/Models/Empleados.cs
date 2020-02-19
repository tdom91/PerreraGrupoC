using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PererraC.Models
{
    public class Empleados
    {
        private int Id { get; set; }

        private string NombreCompleto{ get; set; }

        private string Telefono { get; set; }

        private string Correo { get; set; }
            
        private string DNI { get; set; }
        
        public virtual ICollection<Adopcion> Adopciones { get; set; }

    }
}