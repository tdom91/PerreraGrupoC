using PererraC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PererraC.DAL
{
    public class PerreraContext:DbContext
    {
        public PerreraContext() : base("PerreraContext")
        { }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Perros> Perros { get; set; }
        public DbSet<Jaulas> Jaulas { get; set; }
        public DbSet<Razas> Razas { get; set; }
        public DbSet<Adopciones> Adopciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Adopciones>().HasKey(l => new { l.PerroId, l.ClienteId, l.EmpleadoId });
        }
    }
}