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
using PererraC.Services.Repository.JaulasRepository;

namespace PererraC.Controllers
{
    public class JaulasController : BaseController
    {
        private IJaulasRepository repositorio = null;

        public JaulasController()
        {
            this.repositorio = new JaulasRepository();
        }

        public JaulasController(IJaulasRepository repositorio)
        {
            this.repositorio = repositorio;
        }

        // GET: Jaulas
        public async Task<ActionResult> Index()
        {
            return View(await repositorio.GetAll());
        }

        // GET: Jaulas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var jaulas = await repositorio.GetById(id);
            if (jaulas == null)
            {
                return HttpNotFound();
            }
            return View(jaulas);
        }

        // GET: Jaulas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jaulas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,NombreJaula")] Jaulas jaulas)
        {
            if (ModelState.IsValid)
            {
                repositorio.Insert(jaulas);
                await repositorio.Save();
                return RedirectToAction("Index");
            }

            return View(jaulas);
        }

        // GET: Jaulas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var jaulas = await repositorio.GetById(id);
            if (jaulas == null)
            {
                return HttpNotFound();
            }
            return View(jaulas);
        }

        // POST: Jaulas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,NombreJaula")] Jaulas jaulas)
        {
            if (ModelState.IsValid)
            {
                repositorio.Update(jaulas);
                await repositorio.Save();
                return RedirectToAction("Index");
            }
            return View(jaulas);
        }

        // GET: Jaulas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var jaulas = await repositorio.GetById(id);
            if (jaulas == null)
            {
                return HttpNotFound();
            }
            return View(jaulas);
        }

        // POST: Jaulas/Delete/5
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
