using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PererraC.Models
{
    public class Adopciones
    {
        [Key]
        public int Id { get; set; }
        [Key]
        [ForeignKey("Perros")]
        public int PerroId { get; set; }
        [Key]
        [ForeignKey("Clientes")]
        public int ClienteId { get; set; }
        [Key]
        [ForeignKey("Empleados")]
        public int EmpleadoId { get; set; }
        public System.DateTime FechaEntrega { get; set; }
        
        
        public virtual Clientes Clientes { get; set; }
        public virtual Empleados Empleados { get; set; }
        public virtual Perros Perros { get; set; }
    }
}