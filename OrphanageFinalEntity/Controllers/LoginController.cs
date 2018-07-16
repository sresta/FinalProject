using OrphanageFinalEntity.Models;
using OrphanageFinalEntity.Repository;
using System;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace OrphanageFinalEntity.Controllers
{
    public class LoginController :DatabaseController
    {
        private UserRepository userRepo = new UserRepository();

        User user = new User();
        

        public ActionResult Login()
        {
            if (Session["UserId"] == null)
            {
                return View();
            }
            else
                return Redirect("~/Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login  lvm, string ReturnUrl)
        {
          
            if (ModelState.IsValid)
            {               
                    var users = db.Users.Where(u => u.Email.Equals(lvm.Email) && u.Password.Equals(lvm.Password)).FirstOrDefault();                
                    if (users != null)
                    {
                        if (users.Status.Equals(true))
                        {
                            Session["UserId"] = users.Id.ToString();
                            Session["Email"] = users.Email;
                            if (ReturnUrl != null)
                            {
                                return Redirect(ReturnUrl);
                            }
                            return Redirect("~/Home");
                        }
                        else
                         {
                        return RedirectToAction("Thankyou","Register");
                        }

                    }
                    else
                    {
                       return Redirect("Login");
                    }
              
              
            }

            return View();
        }
        public ActionResult Logout()
        {
            Session["UserId"] = null;
            Session["Email"] = null;
            FormsAuthentication.SignOut();
            return Redirect("~/Home");

        }
        public ActionResult Activate(string code)
        {
            if (code == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Models.User user = userRepo.Activate(code);
            string Message = "";
            if (user == null)
            {
                Message = "Invalide code";
            }
            else
            {
                Message = "Dear " + user.UserName +" "+
                    "Your account has been activated" ;
            }
            ViewBag.Message = Message;
            return View();
        }


    }
}