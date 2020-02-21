using PererraC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PererraC.Services.Repository
{
    public interface IPerrosRepository: IGenericRepository<Perros>
    {
        IQueryable<Jaulas> JaulaConMasPerros();
    }

}
