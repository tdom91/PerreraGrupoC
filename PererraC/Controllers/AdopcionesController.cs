using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PererraC.DAL;
using PererraC.Models;
using PererraC.Services.Repository;

namespace PererraC.Controllers
{
    public class AdopcionesController : BaseController
    {
        private IAdopcionesRepository repositorio = null;
        public AdopcionesController()
        {
            this.repositorio = new AdopcionesRepository();
        }

        public AdopcionesController(IAdopcionesRepository repositorio)
        {
            this.repositorio = repositorio;
        }

        // GET: Adopciones
        public async Task<ActionResult> Index()
        {
            var adopciones = repositorio.Incluye();
            return View(await adopciones.ToListAsync());
        }

        // GET: Adopciones/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adopciones adopciones = await repositorio.GetById(id);
            if (adopciones == null)
            {
                return HttpNotFound();
            }
            return View(adopciones);
        }

        // GET: Adopciones/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(repositorio.ListaClientes(), "Id", "NombreCompleto");
            ViewBag.EmpleadoId = new SelectList(repositorio.ListaEmpleados(), "Id", "NombreCompleto");
            ViewBag.PerroId = new SelectList(repositorio.ListaPerros(), "Id", "Nombre");
            return View();
        }

        // POST: Adopciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PerroId,ClienteId,EmpleadoId,FechaEntrega")] Adopciones adopciones)
        {
            if (ModelState.IsValid)
            {
                repositorio.Insert(adopciones);
                await repositorio.Save();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(repositorio.ListaClientes(), "Id", "NombreCompleto", adopciones.ClienteId);
            ViewBag.EmpleadoId = new SelectList(repositorio.ListaEmpleados(), "Id", "NombreCompleto", adopciones.EmpleadoId);
            ViewBag.PerroId = new SelectList(repositorio.ListaPerros(), "Id", "Nombre", adopciones.PerroId);
            return View(adopciones);
        }

        // GET: Adopciones/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adopciones adopciones = await repositorio.GetById(id);
            if (adopciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(repositorio.ListaClientes(), "Id", "NombreCompleto", adopciones.ClienteId);
            ViewBag.EmpleadoId = new SelectList(repositorio.ListaEmpleados(), "Id", "NombreCompleto", adopciones.EmpleadoId);
            ViewBag.PerroId = new SelectList(repositorio.ListaPerros(), "Id", "Nombre", adopciones.PerroId);
            return View(adopciones);
        }

        // POST: Adopciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PerroId,ClienteId,EmpleadoId,FechaEntrega")] Adopciones adopciones)
        {
            if (ModelState.IsValid)
            {
                repositorio.Update(adopciones);
                await repositorio.Save();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(repositorio.ListaClientes(), "Id", "NombreCompleto", adopciones.ClienteId);
            ViewBag.EmpleadoId = new SelectList(repositorio.ListaEmpleados(), "Id", "NombreCompleto", adopciones.EmpleadoId);
            ViewBag.PerroId = new SelectList(repositorio.ListaPerros(), "Id", "Nombre", adopciones.PerroId);
            return View(adopciones);
        }

        // GET: Adopciones/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adopciones adopciones = await repositorio.GetById(id);
            if (adopciones == null)
            {
                return HttpNotFound();
            }
            return View(adopciones);
        }

        // POST: Adopciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await repositorio.Delete(id);
            await repositorio.Save();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
