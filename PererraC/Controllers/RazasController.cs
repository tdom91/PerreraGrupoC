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
using PererraC.Services.Repository.RazasRepository;

namespace PererraC.Controllers
{
    public class RazasController : BaseController
    {
        private IRazasRepository repositorio = null;

        public RazasController()
        {
            this.repositorio = new RazasRepository();
        }

        public RazasController(IRazasRepository repositorio)
        {
            this.repositorio = repositorio;
        }

        // GET: Razas
        public async Task<ActionResult> Index()
        {
            return View(await repositorio.GetAll());
        }

        // GET: Razas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var razas = await repositorio.GetById(id);
            if (razas == null)
            {
                return HttpNotFound();
            }
            return View(razas);
        }

        // GET: Razas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Razas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nombre")] Razas razas)
        {
            if (ModelState.IsValid)
            {
                repositorio.Insert(razas);
                await repositorio.Save();
                return RedirectToAction("Index");
            }

            return View(razas);
        }

        // GET: Razas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var razas = await repositorio.GetById(id);
            if (razas == null)
            {
                return HttpNotFound();
            }
            return View(razas);
        }

        // POST: Razas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre")] Razas razas)
        {
            if (ModelState.IsValid)
            {
                repositorio.Update(razas);
                await repositorio.Save();
                return RedirectToAction("Index");
            }
            return View(razas);
        }

        // GET: Razas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var razas = await repositorio.GetById(id);
            if (razas == null)
            {
                return HttpNotFound();
            }
            return View(razas);
        }

        // POST: Razas/Delete/5
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
