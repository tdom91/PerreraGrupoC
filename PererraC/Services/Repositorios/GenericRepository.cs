using PererraC.DAL;
using PererraC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PererraC.Services.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public PerreraContext _context = null;
        public DbSet<T> table = null;

        public GenericRepository()
        {
            this._context = new PerreraContext();
            table = _context.Set<T>();
        }

        public GenericRepository(PerreraContext context)
        {
            this._context = context;
            table = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public virtual async Task<T> GetById(object id)
        {
            return await table.FindAsync(id);
        }

        public virtual void Insert(T obj)
        {
           table.Add(obj);
        }

        public virtual void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public virtual async Task Delete(object id)
        {
            T existing = await table.FindAsync(id);
            table.Remove(existing);
        }

        public virtual async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<Clientes>> ListaClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        public virtual async Task<IEnumerable<Empleados>> ListaEmpleados()
        {
            return await _context.Empleados.ToListAsync();
        }

        public virtual async Task<IEnumerable<Perros>> ListaPerros()
        {
            return await _context.Perros.ToListAsync();
        }

        public virtual async Task<IEnumerable<Jaulas>> ListaJaulas()
        {
            return await _context.Jaulas.ToListAsync();
        }

        public virtual async Task<IEnumerable<Razas>> ListaRazas()
        {
            return await _context.Razas.ToListAsync();
        }

        public virtual async Task<IEnumerable<Adopciones>> ListaAdopciones()
        {
            return await _context.Adopciones.ToListAsync();
        }
    }
}
    
