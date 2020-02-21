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
    public class PerrosController : BaseController
    {
        private IPerrosRepository repositorio = null;
        public PerrosController()
        {
            this.repositorio = new PerrosRepository();
        }

        public PerrosController(IPerrosRepository repositorio)
        {
            this.repositorio = repositorio;
        }

        // GET: Perros
        public async Task<ActionResult> Index()
        {
            return View(await repositorio.GetAll());
        }

        // GET: Perros/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perros perros = await repositorio.GetById(id);
            if (perros == null)
            {
                return HttpNotFound();
            }
            return View(perros);
        }

        // GET: Perros/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.IdJaula = new SelectList(await repositorio.ListaJaulas(), "Id", "NombreJaula");
            ViewBag.CodRazaId = new SelectList(await repositorio.ListaRazas(), "Id", "Nombre");
            return View();
        }

        // POST: Perros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nombre,Chip,FechaNacimiento,CodRazaId,IdJaula")] Perros perros)
        {
            if (ModelState.IsValid)
            {
                repositorio.Insert(perros);
                await repositorio.Save();
                return RedirectToAction("Index");
            }

            ViewBag.IdJaula = new SelectList(await repositorio.ListaJaulas(), "Id", "NombreJaula", perros.IdJaula);
            ViewBag.CodRazaId = new SelectList(await repositorio.ListaRazas(), "Id", "Nombre", perros.CodRazaId);
            return View(perros);
        }

        // GET: Perros/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perros perros = await repositorio.GetById(id);
            if (perros == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdJaula = new SelectList(await repositorio.ListaJaulas(), "Id", "NombreJaula", perros.IdJaula);
            ViewBag.CodRazaId = new SelectList(await repositorio.ListaRazas(), "Id", "Nombre", perros.CodRazaId);
            return View(perros);
        }

        // POST: Perros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre,Chip,FechaNacimiento,CodRazaId,IdJaula")] Perros perros)
        {
            if (ModelState.IsValid)
            {
                repositorio.Update(perros);
                await repositorio.Save();
                return RedirectToAction("Index");
            }
            ViewBag.IdJaula = new SelectList(await repositorio.ListaJaulas(), "Id", "NombreJaula", perros.IdJaula);
            ViewBag.CodRazaId = new SelectList(await repositorio.ListaRazas(), "Id", "Nombre", perros.CodRazaId);
            return View(perros);
        }

        // GET: Perros/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perros perros = await repositorio.GetById(id);
            if (perros == null)
            {
                return HttpNotFound();
            }
            return View(perros);
        }

        // POST: Perros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            //Perros perros = await repositorio.GetById(id);
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
