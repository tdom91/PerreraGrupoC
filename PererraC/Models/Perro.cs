using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PererraC.Models
{
    public class Perro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Chip { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public Nullable<int> CodRazaId { get; set; }
        public Nullable<int> IdJaula { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adopcion> Adopciones { get; set; }
        public virtual Jaula Jaulas { get; set; }
        public virtual Raza Razas { get; set; }
    }
}