using PererraC.DAL;
using PererraC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace PererraC.Services.Repository
{
    public class PerrosRepository : GenericRepository<Perros>, IPerrosRepository
    {
    }
}