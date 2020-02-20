using System.Collections.Generic;

namespace PererraC.Models
{
    public class Jaulas: IEntity
    {
        public int Id { get; set; }
        public string NombreJaula { get; set; }

        public virtual ICollection<Perros> Perros { get; set; }
    }
}