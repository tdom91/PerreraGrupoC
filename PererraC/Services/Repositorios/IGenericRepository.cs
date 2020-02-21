using PererraC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PererraC.Services.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        Task Delete(object id);
        Task Save();

        Task<IEnumerable<Clientes>> ListaClientes();
        Task<IEnumerable<Empleados>> ListaEmpleados();
        Task<IEnumerable<Perros>> ListaPerros();
        Task<IEnumerable<Jaulas>> ListaJaulas();
        Task<IEnumerable<Razas>> ListaRazas();
        Task<IEnumerable<Adopciones>> ListaAdopciones();
    }
}
