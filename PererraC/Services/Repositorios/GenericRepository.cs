using PererraC.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PererraC.Services.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
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
        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }
        public async Task<T> GetById(object id)
        {
            return await table.FindAsync(id);
        }
        public void  Insert(T obj)
        {
           table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public async Task Delete(object id)
        {
            T existing = await table.FindAsync(id);
            table.Remove(existing);
        }
        public async Task Save()
        {
           await _context.SaveChangesAsync();
        }


    }
}
    
