using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DesarrolloDocente.Helpers;
using DesarrolloDocente.Mapper.SecurityModule;
using DesarrolloDocente.Models.SecurityModule;
using DesarrolloDocenteController.DTO.SecurityModule;
using DesarrolloDocenteController.Implementation.SecurityModule;

namespace DesarrolloDocente.Controllers.SecurityModule
{
    public class RoleController : BaseController
    {
        private RoleImplController capaNegocio = new RoleImplController();

        // GET: Role
        public ActionResult Index(string filter = "")
        {
            RoleModelMapper mapper = new RoleModelMapper();

            IEnumerable<RoleModel> roleList = mapper.MapperT1T2(capaNegocio.RecordList(filter));
            return View(roleList);
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
        public ActionResult Create([Bind(Include = "Name,Description")] RoleModel model)
        {
            if (ModelState.IsValid)
            {
                RoleModelMapper mapper = new RoleModelMapper();
                RoleDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordCreation(dto);
                return this.ProcessResponse(response, model);
            }

            return View(model);
        }
        
        // GET: Role/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            RoleModelMapper mapper = new RoleModelMapper();
            RoleModel model = mapper.MapperT1T2(dto);
            return View(model);
        }
        
        // POST: Role/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Removed,Description")] RoleModel model)
        {
            if (ModelState.IsValid)
            {
                RoleModelMapper mapper = new RoleModelMapper();
                RoleDTO dto = mapper.MapperT2T1(model);
                int response = capaNegocio.RecordUpdate(dto);
                return this.ProcessResponse(response, model);
            }
            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private ActionResult ProcessResponse(int response, RoleModel model)
        {
            switch (response)
            {
                case 1:
                    return RedirectToAction("Index");
                case 2:
                    ViewBag.Message = Messages.ExceptionMessage;
                    return View(model);
                case 3:
                    ViewBag.Message = Messages.alreadyExistMessage;
                    return View(model);
            }
            return RedirectToAction("Index");
        }

        
        // GET: Role/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            RoleModelMapper mapper = new RoleModelMapper();
            RoleModel model = mapper.MapperT1T2(dto);
            return View(model);
        }

        // POST: Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id,Name,Removed,Description")] RoleModel model)
        {
            RoleModelMapper mapper = new RoleModelMapper();
            RoleDTO dto = mapper.MapperT2T1(model);
            int response = capaNegocio.RecordRemove(dto);
            return this.ProcessResponse(response, model);
        }

        public ActionResult Forms(int? id)
        {
            if (!this.VerifySession())
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IEnumerable<FormDTO> dtoList = capaNegocio.RecordFormListByRole(id.Value);
            if (dtoList == null)
            {
                return HttpNotFound();
            }
           FormModelMapper mapper = new FormModelMapper();
            IEnumerable<FormModel> formList = mapper.MapperT1T2(dtoList);
            var selectedList = formList.Where(x => x.IsSelectedByUser).Select(x => x.Id).ToList();

            FormsRoleModel model = new FormsRoleModel()
            {
                RoleId= id.Value,
                FormsList = formList,
                SelectedForms = String.Join(",", selectedList)
            };
            return View(model);
        }

        [HttpPost, ActionName("Forms")]
        [ValidateAntiForgeryToken]
        public ActionResult Forms([Bind(Include = "RoleId,SelectedForms")] FormsRoleModel model)
        {
            List<int> formsList = new List<int>();
            foreach (string formId in model.SelectedForms.Split(','))
            {
                formsList.Add(int.Parse(formId));
            }

            bool response = capaNegocio.AssignForms(formsList, model.RoleId);
            if (response)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
