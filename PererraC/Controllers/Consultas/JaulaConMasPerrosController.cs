using AutoMapper;
using PererraC.Models;
using PererraC.Models.ViewModels;
using PererraC.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PererraC.Controllers.Consultas
{
    public class JaulaConMasPerrosController : Controller
    {
        // GET: JaulaConMasPerros
        public ActionResult Index()
        {
            IPerrosRepository repositorio = new PerrosRepository();

            var lista = repositorio.JaulaConMasPerros();

            var configuration = new MapperConfiguration(
                cfg =>
                    cfg.CreateMap<Jaulas, JaulaConMasPerros>()
                        .ForMember(dest => dest.jaulaNombre, opt => opt.MapFrom(src => src.NombreJaula))
                        .ForMember(dest => dest.numeroPerros, opt => opt.MapFrom(src => src.Perros.Count))
                        //.ForMember(dest => dest.EventMinute, opt => opt.MapFrom(src => src.Date.Minute))
                    );
           

            // Perform mapping
            IMapper mapper = new Mapper(configuration);
            Jaulas jaula = lista.ToList().Last();
            JaulaConMasPerros form = mapper.Map<Jaulas, JaulaConMasPerros>(jaula);
            IEnumerable<JaulaConMasPerros> lista2 = new List<JaulaConMasPerros> { form};

            return View(lista2);
        }

        private object List<T>()
        {
            throw new NotImplementedException();
        }
    }
}