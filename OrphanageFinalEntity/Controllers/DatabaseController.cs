using OrphanageFinalEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrphanageFinalEntity.Controllers
{
    public class DatabaseController : Controller
    {
        protected OrphanageDbContext db = new OrphanageDbContext();
       
    }
}