using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PererraC.Models
{
    public class Razas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Perros> Perros { get; set; }
    }
}