using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PererraC.Models
{
    public class Jaula
    {
        public int Id { get; set; }
        public string NombreJaula { get; set; }

        public virtual ICollection<Perro> Perros { get; set; }
    }
}