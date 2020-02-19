﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PererraC.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string DNI { get; set; } 

        public virtual ICollection<Adopcion> Adopciones { get; set; }

     }
}