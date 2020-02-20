﻿using System.Collections.Generic;

namespace PererraC.Models
{
    public class Razas: IEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Perros> Perros { get; set; }
    }
}