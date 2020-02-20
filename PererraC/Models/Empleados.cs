using System.Collections.Generic;

namespace PererraC.Models
{
    public class Empleados
    {
        public int Id { get; set; }
        public string NombreCompleto{ get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string DNI { get; set; }
        
        public virtual ICollection<Adopciones> Adopciones { get; set; }
    }
}