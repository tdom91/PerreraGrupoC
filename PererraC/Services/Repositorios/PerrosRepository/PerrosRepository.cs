using PererraC.DAL;
using PererraC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace PererraC.Services.Repository
{
    public class PerrosRepository : GenericRepository<Perros>, IPerrosRepository
    {
        public IQueryable<Perros> Incluye()
        {
            return _context.Perros.Include(p => p.Jaulas).Include(p => p.Razas);
        }

        public DbSet<Jaulas> ListaJaulas()
        {
            return _context.Jaulas; 
        }

        public DbSet<Razas> ListaRazas()
        {
            return _context.Razas;
        }
    }
}