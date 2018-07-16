using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrphanageFinalEntity.Models;
using OrphanageFinalEntity.Repository;
using OrphanageFinalEntity.Provider;

namespace OrphanageFinalEntity.Areas.Admin.Controllers
{
   
    public class OrphanBackgroundsController : Controller
    {
        private OrphanBackgroundRepo repo = new OrphanBackgroundRepo();
        private OrphanageDbContext db = new OrphanageDbContext();

       
        public ActionResult Index()
        {
            
            return View(repo.GetAll());
           
        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrphanBackground orphanBackground = db.OrphanBackgrounds.Find(id);
            if (orphanBackground == null)
            {
                return HttpNotFound();
            }
            return View(orphanBackground);
        }

        
        public ActionResult Create()
        {
            ViewBag.OrphanId = new SelectList(db.Orphans, "Id", "Id");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrphanId,FatherName,MotherName,Relative,AddressDetail,ContactNo,BoardedDetail")] OrphanBackground orphanBackground)
        {
            
            if (ModelState.IsValid)
            {
                repo.Insert(orphanBackground);
                return RedirectToAction("Index");
            }

            ViewBag.OrphanId = new SelectList(db.Orphans, "Id", "FirstName", orphanBackground.OrphanId);
            return View(orphanBackground);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrphanBackground orphanBackground = db.OrphanBackgrounds.Find(id);
            if (orphanBackground == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrphanId = new SelectList(db.Orphans, "Id", "FirstName", orphanBackground.OrphanId);
            return View(orphanBackground);
        }
  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrphanId,FatherName,MotherName,Relative,AddressDetail,ContactNo,BoardedDetail")] OrphanBackground orphanBackground)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orphanBackground).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrphanId = new SelectList(db.Orphans, "Id", "FirstName", orphanBackground.OrphanId);
            return View(orphanBackground);
        }

     
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrphanBackground orphanBackground = db.OrphanBackgrounds.Find(id);
            if (orphanBackground == null)
            {
                return HttpNotFound();
            }
            return View(orphanBackground);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrphanBackground orphanBackground = db.OrphanBackgrounds.Find(id);
            db.OrphanBackgrounds.Remove(orphanBackground);
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
