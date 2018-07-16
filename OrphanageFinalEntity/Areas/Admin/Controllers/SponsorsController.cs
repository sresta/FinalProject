using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrphanageFinalEntity.Models;

namespace OrphanageFinalEntity.Areas.Admin.Controllers
{
    public class SponsorsController : Controller
    {
        private OrphanageDbContext db = new OrphanageDbContext();

       
        public ActionResult Index()
        {
            var sponsorDetails = db.SponsorDetails.Include(s => s.Orphan).Include(s => s.User);
            return View(sponsorDetails.ToList());
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
