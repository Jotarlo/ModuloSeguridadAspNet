using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DesarrolloDocente.Mapper.SecurityModule;
using DesarrolloDocente.Models.SecurityModule;
using DesarrolloDocenteController.DTO.SecurityModule;
using DesarrolloDocenteController.Implementation.SecurityModule;

namespace DesarrolloDocente.Controllers.SecurityModule
{
    public class RoleController : Controller
    {
        private RoleImplController controller = new RoleImplController();

        // GET: Role
        public ActionResult Index(string filter = "")
        {
            return View(controller.RecordList(filter));
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Removed,Description")] RoleModel model)
        {
            if (ModelState.IsValid)
            {
                RoleModelMapper mapper = new RoleModelMapper();
                RoleDTO dto = mapper.MapperT2T1(model);
                int response = controller.RecordCreation(dto);
                return RedirectToAction("Index");
            }

            return View(model);
        }
        /*
        // GET: Role/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEC_ROLE sEC_ROLE = controller.SEC_ROLE.Find(id);
            if (sEC_ROLE == null)
            {
                return HttpNotFound();
            }
            return View(sEC_ROLE);
        }

        // POST: Role/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME,REMOVED,DESCRIPTION")] SEC_ROLE sEC_ROLE)
        {
            if (ModelState.IsValid)
            {
                controller.Entry(sEC_ROLE).State = EntityState.Modified;
                controller.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sEC_ROLE);
        }

        // GET: Role/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEC_ROLE sEC_ROLE = controller.SEC_ROLE.Find(id);
            if (sEC_ROLE == null)
            {
                return HttpNotFound();
            }
            return View(sEC_ROLE);
        }

        // POST: Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SEC_ROLE sEC_ROLE = controller.SEC_ROLE.Find(id);
            controller.SEC_ROLE.Remove(sEC_ROLE);
            controller.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                controller.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
