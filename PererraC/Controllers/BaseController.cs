using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PererraC.Models;
using PererraC.Services.Repository;

namespace PererraC.Controllers
{
   public abstract class BaseController:Controller 

    {
        private IGenericRepository<IEntity> repositorio;
        

        protected BaseController(IGenericRepository<IEntity> repositorio)
        {
            this.repositorio = repositorio;
        }

        protected BaseController()
        {
            
        }


        // GET: Base Repository
        public async Task<ActionResult> BaseIndex()
        {
            return View(await repositorio.GetAll());
        }


        // GET: Base Entity/Details/5
        public async Task<ActionResult> BaseDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var entity = await repositorio.GetById(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }


        // GET: Base Repository/Create
        public ActionResult BaseCreate()
        {
            return View();
        }


        // POST: Base Repository/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> BaseCreate([Bind(Include = "")] IEntity entity)
        {
            if (ModelState.IsValid)
            {
                repositorio.Insert(entity);
                await repositorio.Save();
                //return RedirectToAction("Index");
            }

            return View(entity);
        }

        // GET: Base Repository/Edit/5
        public async Task<ActionResult> BaseEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var entity = await repositorio.GetById(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }


        // POST: Base Repository/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> BaseEdit([Bind(Include = "")] IEntity entity)
        {
            if (ModelState.IsValid)
            {
                repositorio.Update(entity);
                await repositorio.Save();
                //return RedirectToAction("Index");
            }
            return View(entity);
        }

        // GET: Base Repository/Delete/5
        public async Task<ActionResult> BaseDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var entity = await repositorio.GetById(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }


        // POST: Base Repository/Delete/5
        [HttpPost, ActionName("BaseDelete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> BaseDeleteConfirmed(int id)
        {
            
            await repositorio.Delete(id);
            await repositorio.Save();
            return RedirectToAction("Index");
           
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.aspx"
            };
            filterContext.ExceptionHandled = true;
        }

    }
}