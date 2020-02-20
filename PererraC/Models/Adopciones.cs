using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PererraC.Models
{
    public class Adopciones
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PerroId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClienteId { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmpleadoId { get; set; }

        public System.DateTime FechaEntrega { get; set; }

        [ForeignKey("PerroId")]
        public virtual Perros Perros { get; set; }
        [ForeignKey("ClienteId")]
        public virtual Clientes Clientes { get; set; }
        [ForeignKey("EmpleadoId")]
        public virtual Empleados Empleados { get; set; }
    }
}