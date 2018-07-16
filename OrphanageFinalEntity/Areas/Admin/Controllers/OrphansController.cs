using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrphanageFinalEntity.Models;
using OrphanageFinalEntity.Controllers;
using OrphanageFinalEntity.Repository;
using System.IO;

namespace OrphanageFinalEntity.Areas.Admin.Controllers
{
   
    public class OrphansController : DatabaseController
    {
        List<Models.Supervisor> supervisor   = new List<Models.Supervisor>();
        public SupervisorRepository supervisorRepo = new SupervisorRepository();
        
        public OrphansController()
        {
            supervisor = supervisorRepo.GetAll();
         }
        
        public ActionResult Index()
        {
            
            return View(db.Orphans.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orphan orphan = db.Orphans.Find(id);
            if (orphan == null)
            {
                return HttpNotFound();
            }
            return View(orphan);
        }

        
        public ActionResult Create()
        {
            ViewBag.Carers = from c in supervisor
                             select new SelectListItem()
                             {
                                 Text = c.FirstName,
                                 Value =c.Id.ToString(),
                             };
            return View();
        }      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrphanViewModel ovm)
        {
            string fileName = Path.GetFileNameWithoutExtension(ovm.ImageFile.FileName);
            string extension = Path.GetExtension(ovm.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
            ovm.Picture = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            ovm.ImageFile.SaveAs(fileName);

            if (ModelState.IsValid)
            {
                db.Orphans.Add(new Orphan()
                {
                    FirstName = ovm.FirstName,
                    LastName = ovm.LastName,
                    Age = ovm.Age,
                    Gender = ovm.Gender,
                    Disable = ovm.Disable,
                    JoinedDate = DateTime.Now,                   
                    SupervisorName = ovm.SupervisorName,
                    Picture = ovm.Picture
                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ovm);
        }

        // GET: Admin/Orphans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orphan orphan = db.Orphans.Find(id);
            if (orphan == null)
            {
                return HttpNotFound();
            }
            return View(orphan);
        }

        // POST: Admin/Orphans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Age,Gender,Disable,JoinedDate,LeaveDate")] Orphan orphan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orphan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orphan);
        }

        // GET: Admin/Orphans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orphan orphan = db.Orphans.Find(id);
            if (orphan == null)
            {
                return HttpNotFound();
            }
            return View(orphan);
        }

        // POST: Admin/Orphans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orphan orphan = db.Orphans.Find(id);
            db.Orphans.Remove(orphan);
            db.SaveChanges();
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
