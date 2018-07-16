using OrphanageFinalEntity.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OrphanageFinalEntity.Areas.Admin.Controllers
{
    public class LoginsController : DatabaseController
    {       
       
        public ActionResult Login()
        {
            if (Session["AdminId"] == null && Session["Username"] == null)
            {
                return View();
            }
            else return RedirectToAction("Index", "Homes");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.Admin admin, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var admins = db.Admins.Single(u => u.Username == admin.Username && u.Password == admin.Password);
                if (admin != null)
                {
                    Session["AdminId"] = admins.Id.ToString();
                    Session["Username"] = admins.Username;
                    return RedirectToAction("Index", "Homes");
                }
                else
                {
                    return Redirect("Login");
                }
            }
            else
            {
                ModelState.AddModelError("", "Error");
            }
            return View();

                //    if (Membership.ValidateUser(admin.Username, admin.Password))
                //    {
                //        FormsAuthentication.SetAuthCookie(admin.Username, true);
                //        Session["AdminId"] = admin.Id.ToString();
                //        Session["Username"] = admin.Username;
                //        return RedirectToAction("Index", "Homes");
                //    }
                //    else
                //    {
                //        return RedirectToAction("Login");
                //    }
                //}
                //else
                //    {
                //    ModelState.AddModelError("", "Error");
                //}
                //return View();





            }
        public ActionResult Logout()
        {
            Session["AdminId"] = null;
            Session["Username"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Logins");

        }
    }
}