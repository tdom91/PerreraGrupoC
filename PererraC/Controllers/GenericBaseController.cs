using PererraC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using System.Net;

namespace PererraC.Controllers
{
    public abstract class GenericBaseController<T>:Controller where T: IEntity
    {
        protected T _entity;

        public GenericBaseController(T entity)
        {
            _entity = entity;
        }

        public async Task<ActionResult> Index()
        {
            return View( _entity.Id);
        }

        public async Task<ActionResult> Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var entity=  _entity.Id.ToString();
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }


        // GET: Base
        public ActionResult Create()
        {
            return View();
        }



        // POST: Base/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,NombreCompleto,Telefono,Correo,DNI")] Clientes clientes)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Clientes.Add(clientes);
            //    await db.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}

            return View(clientes);
        }


        // GET: Base/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Clientes clientes = await db.Clientes.FindAsync(id);
            //if (clientes == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }



        // POST: Base/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,NombreCompleto,Telefono,Correo,DNI")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(clientes).State = EntityState.Modified;
                //await db.SaveChangesAsync();
                //return RedirectToAction("Index");
            }
            return View();
        }


        // GET: Clientes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Clientes clientes = await db.Clientes.FindAsync(id);
            //if (clientes == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }


        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            //Clientes clientes = await db.Clientes.FindAsync(id);
            //db.Clientes.Remove(clientes);
            //await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}