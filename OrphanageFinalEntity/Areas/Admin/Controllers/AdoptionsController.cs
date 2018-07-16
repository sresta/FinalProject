using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrphanageFinalEntity.Models;
using OrphanageFinalEntity.Utility;

namespace OrphanageFinalEntity.Areas.Admin.Controllers
{
    public class AdoptionsController : Controller
    {
        private OrphanageDbContext db = new OrphanageDbContext();

       
        public ActionResult Index()
        {
            var adoptionRequests = db.AdoptionRequests.Include(a => a.User);
            return View(adoptionRequests.ToList());
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult SendMail(int? id)
        {

            if (id != null)
            {
                User user = db.Users.Find(id);
                if (user != null)
                {
                    string message = "Dear" + user.Email + "<br/> Please come to visit";
                    Mailer mailer = new Mailer(user.Email, "adoption", message);
                    mailer.Send();
                    return RedirectToAction("Index");

                }
            }
            return RedirectToAction("SendMail");
            
         
        }
    }
}
