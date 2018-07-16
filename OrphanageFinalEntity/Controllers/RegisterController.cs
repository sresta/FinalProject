using OrphanageFinalEntity.Models;
using OrphanageFinalEntity.Repository;
using OrphanageFinalEntity.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OrphanageFinalEntity.Controllers
{
    public class RegisterController :DatabaseController
    {
        private UserRepository userRepo = new UserRepository();
       
        
        public ActionResult Register()
        {
            
           
            return View();
            
        }
         [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                string code = Guid.NewGuid().ToString();
               
                userRepo.Insert(new Models.User()
                {
                    FirstName = register.FirstName,
                    LastName = register.LastName,
                    UserName = register.UserName,
                    Email = register.Email,
                    Password = register.Password,  
                    CreatedDate = DateTime.Now,
                    AuthCode = code,    
                    Status= false               
                });
                SendMail(register.UserName, register.Email, code);
                return RedirectToAction("Thankyou");
            }
            return View(register);
        }
        public ActionResult Thankyou()
        {
            return View();
        }
        public JsonResult checkUserName(string username)
        {
            User user = userRepo.GetByUserName(username);
            bool exists = (user != null);
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new { Exist =  exists };
            return result;
             
        }

        public JsonResult checkEmail(string email)
        {
            Models.User user = userRepo.GetByUserEmail(email);
            bool exists = (user != null);
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new { Exist = exists };
            return result;

        }
        private void SendMail(string user, string email, string code)
        {
            string url = Request.Url.Host;
            string message = "Dear" + user + "<br/> You have registered successfully" +"Please <a href=\""+url+"/login/activate?code="+code+"\">click here</a> to activate your account" +
                "<br/><br/>Regards<br/>Orphanage Management System ";
            Mailer mailer = new Mailer(email, "Registration Confirmed", message);
            mailer.Send();
        }

    }
}