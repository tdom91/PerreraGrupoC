﻿using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using PererraC.DAL;
using PererraC.Models;

namespace PererraC.Controllers
{
    public class AdopcionesController : Controller
    {
        private PerreraContext db = new PerreraContext();

        // GET: Adopciones
        public async Task<ActionResult> Index()
        {
            var adopciones = db.Adopciones.Include(a => a.Clientes).Include(a => a.Empleados).Include(a => a.Perros);
            return View(await adopciones.ToListAsync());
        }

        // GET: Adopciones/Details/5
        public async Task<ActionResult> Details(int? PerroId, int? EmpleadoId, int? ClienteId)
        {
            if (PerroId == null && EmpleadoId == null && ClienteId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adopciones adopciones = await Task.Run(()=> db.Adopciones.Where(p => p.ClienteId == ClienteId &&
                p.PerroId == PerroId && p.EmpleadoId == EmpleadoId).FirstOrDefault());
            if (adopciones == null)
            {
                return HttpNotFound();
            }
            return View(adopciones);
        }

        // GET: Adopciones/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "NombreCompleto");
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "Id", "NombreCompleto");
            ViewBag.PerroId = new SelectList(db.Perros, "Id", "Nombre");
            return View();
        }

        // POST: Adopciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PerroId,ClienteId,EmpleadoId,FechaEntrega")] Adopciones adopciones)
        {
            if (ModelState.IsValid)
            {
                db.Adopciones.Add(adopciones);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "NombreCompleto", adopciones.ClienteId);
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "Id", "NombreCompleto", adopciones.EmpleadoId);
            ViewBag.PerroId = new SelectList(db.Perros, "Id", "Nombre", adopciones.PerroId);
            return View(adopciones);
        }

        // GET: Adopciones/Edit/5
        public async Task<ActionResult> Edit(int? PerroId, int? EmpleadoId, int? ClienteId)
        {
            if (PerroId == null && EmpleadoId == null && ClienteId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adopciones adopciones = await Task.Run(() => db.Adopciones.Where(p => p.ClienteId == ClienteId &&
                 p.PerroId == PerroId && p.EmpleadoId == EmpleadoId).FirstOrDefault());
            if (adopciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "NombreCompleto", adopciones.ClienteId);
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "Id", "NombreCompleto", adopciones.EmpleadoId);
            ViewBag.PerroId = new SelectList(db.Perros, "Id", "Nombre", adopciones.PerroId);
            return View(adopciones);
        }

        // POST: Adopciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PerroId,ClienteId,EmpleadoId,FechaEntrega")] Adopciones adopciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adopciones).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "NombreCompleto", adopciones.ClienteId);
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "Id", "NombreCompleto", adopciones.EmpleadoId);
            ViewBag.PerroId = new SelectList(db.Perros, "Id", "Nombre", adopciones.PerroId);
            return View(adopciones);
        }

        // GET: Adopciones/Delete/5
        public async Task<ActionResult> Delete(int? PerroId, int? EmpleadoId, int? ClienteId)
        {
            if (PerroId == null && EmpleadoId == null && ClienteId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adopciones adopciones = await Task.Run(() => db.Adopciones.Where(p => p.ClienteId == ClienteId &&
                 p.PerroId == PerroId && p.EmpleadoId == EmpleadoId).FirstOrDefault());
            if (adopciones == null)
            {
                return HttpNotFound();
            }
            return View(adopciones);
        }

        // POST: Adopciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int? PerroId, int? EmpleadoId, int? ClienteId)
        {
            Adopciones adopciones = await Task.Run(()=> db.Adopciones.Where(p => p.ClienteId == ClienteId &&
                p.PerroId == PerroId && p.EmpleadoId == EmpleadoId).FirstOrDefault());
            db.Adopciones.Remove(adopciones);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
