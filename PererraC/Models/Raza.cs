﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PererraC.Models
{
    public class Raza
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Perro> Perros { get; set; }
    }
}