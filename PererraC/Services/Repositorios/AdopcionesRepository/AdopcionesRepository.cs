using PererraC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PererraC.Services.Repository
{
    public class AdopcionesRepository : GenericRepository<Adopciones>, IAdopcionesRepository
    {
        public IQueryable<Adopciones> Incluye()
        {
            return _context.Adopciones.Include(a => a.Clientes).Include(a => a.Empleados).Include(a => a.Perros);
        }

        public DbSet<Clientes> ListaClientes()
        {
            return _context.Clientes;
        }

        public DbSet<Empleados> ListaEmpleados()
        {
            return _context.Empleados;
        }

        public DbSet<Perros> ListaPerros()
        {
            return _context.Perros;
        }
    }
}