using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrphanageFinalEntity.Models;
using System.Text;

namespace OrphanageFinalEntity.Areas.Admin.Controllers
{
    public class SupervisorsController : Controller
    {
        private OrphanageDbContext db = new OrphanageDbContext();

        // GET: Admin/Supervisors
        public ActionResult Index()
        {
            return View(db.Supervisors.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supervisor supervisor = db.Supervisors.Find(id);
            if (supervisor == null)
            {
                return HttpNotFound();
            }
            return View(supervisor);
        }

        
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SupervisorViewModel supervisor)
        {
            if (ModelState.IsValid)
            {
                string a = CreatePassword();
                db.Supervisors.Add(new Supervisor()
                {
                    FirstName = supervisor.FirstName,
                    LastName = supervisor.LastName,
                    Email = supervisor.Email,
                    ContactNo = supervisor.ContactNo,
                    Address = supervisor.Address,
                   Password = a
                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supervisor);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supervisor supervisor = db.Supervisors.Find(id);
            if (supervisor == null)
            {
                return HttpNotFound();
            }
            return View(supervisor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Supervisor supervisor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supervisor).State = EntityState.Modified;
                string a = CreatePassword();
                db.Supervisors.Add(new Supervisor()
                {
                    FirstName = supervisor.FirstName,
                    LastName = supervisor.LastName,
                    Email = supervisor.Email,
                    ContactNo = supervisor.ContactNo,
                    Address = supervisor.Address,
                    Password = a
                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supervisor);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supervisor supervisor = db.Supervisors.Find(id);
            if (supervisor == null)
            {
                return HttpNotFound();
            }
            return View(supervisor);
        }

               [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supervisor supervisor = db.Supervisors.Find(id);
            db.Supervisors.Remove(supervisor);
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
        public string CreatePassword()
        {
            int length = 6;
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}
