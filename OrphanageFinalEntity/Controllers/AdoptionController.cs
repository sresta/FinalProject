using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrphanageFinalEntity.Models;

namespace OrphanageFinalEntity.Controllers
{
    public class AdoptionController : Controller
    {
        private OrphanageDbContext db = new OrphanageDbContext();
      
        public ActionResult Create()
        {
            if (Session["UserId"] != null)
            {
                ViewBag.UserId = Session["UserId"];
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdoptionRequest adoptionRequest)
        {
            if (ModelState.IsValid)
            {
                db.AdoptionRequests.Add(new AdoptionRequest()
                {
                    UserId = adoptionRequest.UserId,
                    Gender = adoptionRequest.Gender,
                    Address=adoptionRequest.Address,
                    Married=adoptionRequest.Married,
                   Profession = adoptionRequest.Profession,
                    MonthlyIncome=adoptionRequest.MonthlyIncome,
                    ReasonOfAdoption=adoptionRequest.ReasonOfAdoption,
                    IfAnyChild = adoptionRequest.IfAnyChild
                });
                db.SaveChanges();
                return RedirectToAction("ThankYou");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", adoptionRequest.UserId);
            return View(adoptionRequest);
        }
        public ActionResult ThankYou()
        {
            ViewBag.message = "Your request is being processed";
            return View();
        }
        
    }
}
