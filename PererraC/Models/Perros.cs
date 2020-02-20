using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PererraC.Models
{
    public class Perros
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Chip { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        
        [ForeignKey("Razas")]
        public Nullable<int> CodRazaId { get; set; }

        [ForeignKey("Jaulas")]
        public Nullable<int> IdJaula { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adopciones> Adopciones { get; set; }
        public virtual Jaulas Jaulas { get; set; }
        public virtual Razas Razas { get; set; }
    }
}