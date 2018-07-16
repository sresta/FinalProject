using OrphanageFinalEntity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OrphanageFinalEntity.Controllers
{
   
    public class OrphanController : DatabaseController
    {
     
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
        public ActionResult Sponsor(int? id )
        {
            if (Session["UserId"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else
                {                    
                        ViewBag.OrphanId = id;
                        ViewBag.UserId = Session["UserId"];
                }
            }               
            else
            {
                return RedirectToAction("Login", "Login");
            }            
            return View();
        }
        [HttpPost]
        public ActionResult Sponsor(SponsorDetail sponsor,int? id)
        {
            if (ModelState.IsValid)
            {
                db.SponsorDetails.Add(new SponsorDetail()
                {
                    OrphanId = sponsor.OrphanId,
                    UserId=sponsor.UserId,
                    PaymentType = sponsor.PaymentType,
                    PaymentNo  =sponsor.PaymentNo,
                    Amount =sponsor.Amount,
                    DateOfReceipt = DateTime.Now

                });
                
db.SaveChanges();
                ViewBag.Message = "Successful";
                return RedirectToAction("Index");
            }
            ViewBag.OrphanId = new SelectList(db.Orphans, "Id", "FirstName",sponsor.OrphanId);
            return View(sponsor);
        }
    }
}